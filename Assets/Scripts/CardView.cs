using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Enums;

public class CardView : MonoBehaviour
{
    [SerializeField] private float hoverScale = 1.1f;
    [SerializeField] private float selectedYOffset = 30f;

    [SerializeField] private bool isSelected = false;
    private Vector2 originalPosition;
    private Quaternion originalRotation;

    private Transform originalParent;
    private RectTransform rectTransform;

    [SerializeField] private Canvas canvas;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Outline outline;

    public Image cardImage;
    public Text nameText;
    public Text descriptionText;
    public Text healthText;
    public Text damageText;

    public CardInstance Card { get; private set; }

    public System.Action<CardView> OnCardClicked;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = FindObjectOfType<Canvas>();

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
        //пусто
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnCardClicked?.Invoke(this);
    }

}