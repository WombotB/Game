using UnityEngine;
using UnityEngine.EventSystems;

public class BoardCell : MonoBehaviour, IPointerClickHandler
{
    public int Row;
    public int Col;

    public System.Action<int, int> OnCellClicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnCellClicked?.Invoke(Row, Col);
    }
}
