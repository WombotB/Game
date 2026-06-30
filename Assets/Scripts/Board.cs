using UnityEngine;
using Enums;
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

    public CardInstance? GetFrontCard (CardInstance card)
    {
        int row = card.Row + card.Direction;

        //Проверка на замок
        if (IsCastleOnLine(card.Col) && card.Team == CardTeam.Reflection && row == -1) { } //Заготовка для замка

        else if (row <0 || row >= 5) {  return null; }

        return Board[row, card.Col];
    }

    public CardInstance? GetClosestEnemy (CardInstance card)
    {
        CardTeam Team = card.Team;

        CardInstance?[] Column = GetCol(card.Col);

        for (int row = card.Row + card.Direction; row<5 && row>=0; row += card.Direction)
        {
            if (Column[row] != null && Column[row].Team != Team) { return Column[row]; }

            //Проверка на замок
            else if (IsCastleOnLine(card.Col) && Team == CardTeam.Reflection) { } //Заготовка для замка
        }

        return null;
    }

    public bool IsCellFree(int row, int col)
    {
        if (Board[row, col] == null) { return true; }
        return false;
    }

    public bool IsCastleOnLine(int col)
    {
        return col > 0 && col < 4;
    }
}
