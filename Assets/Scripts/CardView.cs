using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Enums;

public class CardView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private float hoverScale = 1.1f;
    [SerializeField] private float selectedYOffset = 30f;

    [SerializeField] private bool isSelected = false;
    private Vector2 originalPosition;
    private Quaternion originalRotation;

    private Transform originalParent;
    private RectTransform rectTransform;
    
    private bool inHand = false;
    private bool isHovering = false;
    private float currentScale = 1.0f;
    private float targetScale = 1.0f;
    private const float scaleTransitionSpeed = 6.67f; // 1/0.15 ≈ 6.67 for 0.15s transition

    [SerializeField] private Canvas canvas;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Outline outline;

    [SerializeField] private Image cardImage;
    [SerializeField] private Text nameText;
    [SerializeField] private Text descriptionText;
    [SerializeField] private Text healthText;
    [SerializeField] private Text damageText;

    public CardInstance Card { get; private set; }

    public System.Action<CardView> OnCardClicked;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponent<Canvas>();
        
        if (canvas == null)
        {
            canvas = gameObject.AddComponent<Canvas>();
            canvas.enabled = false; // Disabled by default, enabled during drag
        }

        if (outline == null)
            outline = GetComponent<Outline>();
    }

    public void Initialize(CardInstance card)
    {
        Card = card;
        UpdateView();
    }

    public void UpdateView()
    {
        if (Card == null || Card.Data == null) return;

        if (nameText != null)
            nameText.text = Card.Data.Name;

        if (healthText != null)
            healthText.text = Card.CurrentHealth.ToString();

        if (damageText != null)
            damageText.text = Card.CurrentDamage.ToString();

        if (cardImage != null && Card.Data.Icon != null)
            cardImage.sprite = Card.Data.Icon;

        if (descriptionText != null)
            descriptionText.text = Card.Data.Description;
    }

    public void Select()
    {
        isSelected = true;
        rectTransform.localPosition = new Vector2(0, selectedYOffset);

        if (outline != null)
        {
            outline.enabled = true;
            outline.effectColor = Color.yellow;
            outline.effectDistance = new Vector2(5, 5);
        }
    }
    public void Deselect()
    {
        isSelected = false;
        rectTransform.localPosition = Vector2.zero;

        if (outline != null)
            outline.enabled = false;
    }

    public void SetInHand(bool inHand)
    {
        this.inHand = inHand;
        
        // Reset hover state when removed from hand
        if (!inHand)
        {
            isHovering = false;
            targetScale = 1.0f;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (inHand)
        {
            isHovering = true;
            targetScale = hoverScale;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (inHand)
        {
            isHovering = false;
            targetScale = 1.0f;
        }
    }

    private void Update()
    {
        // Smoothly animate scale towards target over 0.15 seconds
        if (Mathf.Abs(currentScale - targetScale) > 0.001f)
        {
            currentScale = Mathf.Lerp(currentScale, targetScale, Time.deltaTime * scaleTransitionSpeed);
            rectTransform.localScale = Vector3.one * currentScale;
        }
    }

    public void BeginDrag()
    {
        // Store original position and rotation for return-to-hand behavior
        originalPosition = rectTransform.anchoredPosition;
        originalRotation = rectTransform.localRotation;

        // Set CanvasGroup alpha to 0.8 for visual feedback during drag
        if (canvasGroup != null)
            canvasGroup.alpha = 0.8f;

        // Enable Canvas component for independent sorting
        if (canvas != null)
        {
            canvas.enabled = true;
            canvas.overrideSorting = true;
            canvas.sortingOrder = 100; // Render above all other UI elements
        }
    }

    public void EndDrag()
    {
        // Restore CanvasGroup alpha to 1.0
        if (canvasGroup != null)
            canvasGroup.alpha = 1.0f;

        // Disable Canvas component
        if (canvas != null)
        {
            canvas.enabled = false;
            canvas.overrideSorting = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnCardClicked?.Invoke(this);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Store initial position for return-to-hand behavior
        originalPosition = rectTransform.anchoredPosition;
        originalRotation = rectTransform.localRotation;
        originalParent = rectTransform.parent;

        // Call BeginDrag to set visual state
        BeginDrag();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Convert screen point to local point in parent's RectTransform
        if (rectTransform.parent != null)
        {
            RectTransform parentRect = rectTransform.parent as RectTransform;
            if (parentRect != null)
            {
                Vector2 localPoint;
                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    parentRect, 
                    eventData.position, 
                    eventData.pressEventCamera, 
                    out localPoint))
                {
                    rectTransform.anchoredPosition = localPoint;
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Call EndDrag to restore visual state
        EndDrag();

        // Detect drop target using EventSystem raycast
        var raycastResults = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);

        // Look for a BoardCell component in the raycast results
        BoardCell targetCell = null;
        foreach (var result in raycastResults)
        {
            targetCell = result.gameObject.GetComponent<BoardCell>();
            if (targetCell != null)
                break;
        }

        // If valid BoardCell detected, trigger placement flow via OnCardClicked
        if (targetCell != null && inHand)
        {
            OnCardClicked?.Invoke(this);
        }
        else
        {
            // Return to hand position - animate using coroutine for smooth return
            StartCoroutine(ReturnToHandCoroutine());
        }
    }

    private System.Collections.IEnumerator ReturnToHandCoroutine()
    {
        float elapsed = 0f;
        float duration = 0.25f;
        Vector2 startPos = rectTransform.anchoredPosition;
        Quaternion startRot = rectTransform.localRotation;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, originalPosition, t);
            rectTransform.localRotation = Quaternion.Lerp(startRot, originalRotation, t);
            
            yield return null;
        }

        // Ensure final position is exact
        rectTransform.anchoredPosition = originalPosition;
        rectTransform.localRotation = originalRotation;
    }

}