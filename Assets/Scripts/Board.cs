using UnityEngine;
#nullable enable


public class GameBoard
{
    public CardInstance?[,] Board;

    public bool HasCard (int row, int col) => Board[row, col] != null;

    public CardInstance GetCard(int row, int col) => Board[row, col]!;

    public void SetCard (int row, int col, CardInstance card) { Board[row, col] = card; }

    public void ClearCell(int row, int col) { Board[row, col] = null; }

    public GameBoard()
    {
        Board = new CardInstance?[5, 5];
    }

    public CardInstance?[] GetCol(int col)
    {
        col--; // col starts from 1, but array index starts from 0
        CardInstance?[] result = new CardInstance?[5];
        for (int row = 0; row < 5; row++)
        {
            result[row] = Board[row, col];
        }
        return result;
    }

    public CardInstance?[] GetRow(int row)
    {
        row--;
        CardInstance?[] result = new CardInstance?[5];
        for (int col = 0; col < 5; col++)
        {
            result[col] = Board[row, col];
        }
        return result;
    }

    public CardInstance? GetFrontCard
}
