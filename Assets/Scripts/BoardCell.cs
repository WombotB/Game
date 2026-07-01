using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoardCell : MonoBehaviour, IPointerClickHandler
{
    public int Row;
    public int Col;

    [SerializeField] private Image highlightImage;

    public System.Action<int, int> OnCellClicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnCellClicked?.Invoke(Row, Col);
    }

    public void SetHighlight(bool on)
    {
        if (highlightImage != null)
            highlightImage.enabled = on;
    }
}