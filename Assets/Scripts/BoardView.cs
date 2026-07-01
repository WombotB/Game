using UnityEngine;
using System.Collections.Generic;

public class BoardView : MonoBehaviour
{
    [Header("Префабы")]
    [SerializeField] private BoardCell cellPrefab;
    [SerializeField] private CardView cardPrefab;

    [Header("Раскладка")]
    [SerializeField] private RectTransform cellsParent;
    [SerializeField] private Vector2 cellSize = new Vector2(100f, 100f);
    [SerializeField] private Vector2 spacing = new Vector2(10f, 10f);

    [Header("Правила расстановки")]
    [Tooltip("Ряды, куда игрок (Люди) может ставить карты из руки. По ТЗ это верхний ряд поля.")]
    [SerializeField] private int[] humanPlacementRows = { 0 };
    [Tooltip("Ряды, куда ставит карты Монстр/запись. Не используется для кликов игрока, но пригодится для подсветки/дебага.")]
    [SerializeField] private int[] monsterPlacementRows = { 4 };
    [Tooltip("Рисовать 3 серые клетки замка над рядом 0 (колонки 1-3)")]
    [SerializeField] private bool showCastle = true;

    // Подписывайся сюда, чтобы узнавать о клике по клетке доски.
    public System.Action<int, int> OnCellClicked;

    private GameBoard board;
    private readonly Dictionary<(int row, int col), BoardCell> cells = new();
    private readonly Dictionary<CardInstance, CardView> cardViews = new();

    private CardView selectedCard;

    void Start()
    {
        board = GameManager.Instance.Match.Board;

        board.OnCardPlaced += HandleCardPlaced;
        board.OnCardRemoved += HandleCardRemoved;
        board.OnCardMoved += HandleCardMoved;

        BuildGrid();
    }

    void OnDestroy()
    {
        if (board == null) return;

        board.OnCardPlaced -= HandleCardPlaced;
        board.OnCardRemoved -= HandleCardRemoved;
        board.OnCardMoved -= HandleCardMoved;
    }

    private void BuildGrid()
    {
        if (showCastle)
        {
            for (int col = 1; col < 4; col++)
            {
                var castleCell = Instantiate(cellPrefab, cellsParent);
                castleCell.Row = -1;
                castleCell.Col = col;
                castleCell.name = $"CastleCell_{col}";
                PositionCell(castleCell.GetComponent<RectTransform>(), -1, col);
            }
        }

        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                var cell = Instantiate(cellPrefab, cellsParent);
                cell.Row = row;
                cell.Col = col;
                cell.name = $"Cell_{row}_{col}";
                PositionCell(cell.GetComponent<RectTransform>(), row, col);

                cell.OnCellClicked += HandleCellClicked;

                cells[(row, col)] = cell;
            }
        }
    }

    private void HandleCellClicked(int row, int col)
    {
        OnCellClicked?.Invoke(row, col);
    }

    private void PositionCell(RectTransform rt, int row, int col)
    {
        float x = (col - 2) * (cellSize.x + spacing.x);
        float y = (1 - row) * (cellSize.y + spacing.y);

        rt.sizeDelta = cellSize;
        rt.anchoredPosition = new Vector2(x, y);
    }

    private void HandleCardPlaced(CardInstance card, int row, int col)
    {
        if (!cells.TryGetValue((row, col), out var cell)) return;

        var view = Instantiate(cardPrefab, cell.transform);
        var rt = view.GetComponent<RectTransform>();
        rt.anchoredPosition = Vector2.zero;

        view.Initialize(card);
        view.OnCardClicked += HandleBoardCardClicked;

        cardViews[card] = view;
    }

    private void HandleCardRemoved(CardInstance card, int row, int col)
    {
        if (!cardViews.TryGetValue(card, out var view)) return;

        cardViews.Remove(card);
        if (selectedCard == view) selectedCard = null;

        Destroy(view.gameObject);
    }

    private void HandleCardMoved(CardInstance card, int oldRow, int oldCol, int newRow, int newCol)
    {
        if (!cardViews.TryGetValue(card, out var view)) return;
        if (!cells.TryGetValue((newRow, newCol), out var cell)) return;

        view.transform.SetParent(cell.transform, false);
        view.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        view.UpdateView();
    }

    private void HandleBoardCardClicked(CardView view)
    {
        // Заготовка на будущее, показать подробное описание карты на доске.
    }

    public void SelectCard(CardView card)
    {
        if (selectedCard != null)
            selectedCard.Deselect();

        selectedCard = card;
        selectedCard.Select();
    }

    public void DeselectCard()
    {
        if (selectedCard != null)
            selectedCard.Deselect();

        selectedCard = null;
    }

    public bool IsValidPlacementCell(int row, int col)
    {
        if (board == null || !board.IsCellFree(row, col)) return false;

        foreach (var r in humanPlacementRows)
            if (r == row) return true;

        return false;
    }

    public void HighlightPlacementCells(bool on)
    {
        foreach (var row in humanPlacementRows)
        {
            for (int col = 0; col < 5; col++)
            {
                if (cells.TryGetValue((row, col), out var cell) && board.IsCellFree(row, col))
                    cell.SetHighlight(on);
            }
        }
    }
}