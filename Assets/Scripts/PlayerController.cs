using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private HandView handView;
    [SerializeField] private BoardView boardView;

    private CardView selectedCardView;

    void Start()
    {
        if (handView == null) handView = FindObjectOfType<HandView>();
        if (boardView == null) boardView = FindObjectOfType<BoardView>();

        handView.OnCardClicked += OnHandCardClicked;
        boardView.OnCellClicked += OnBoardCellClicked;
    }

    private void OnHandCardClicked(CardView cardView)
    {
        // Повторный клик по уже выбранной карте — снимаем выбор
        if (selectedCardView == cardView)
        {
            Deselect();
            return;
        }

        selectedCardView = cardView;
        boardView.SelectCard(cardView);
        boardView.HighlightPlacementCells(true);
    }

    private void OnBoardCellClicked(int row, int col)
    {
        if (selectedCardView == null) return;
        if (!boardView.IsValidPlacementCell(row, col)) return;

        var cardInstance = selectedCardView.Card;

        // Синхронный вызов: TurnManager сам уберёт карту из руки, выдаст новую
        // и прогонит фазы Ranged/Melee/CheckWin/EndTurn. BoardView сама обновит
        // визуал доски через события GameBoard — здесь нужно только обновить руку.
        GameManager.Instance.TurnManager.OnPlayerPlacedCard(cardInstance, row, col);

        Deselect();
        handView.RefreshCards();
    }

    private void Deselect()
    {
        boardView.HighlightPlacementCells(false);
        boardView.DeselectCard();
        selectedCardView = null;
    }

    void Update()
    {

    }
}