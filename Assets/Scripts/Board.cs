using UnityEngine;
using Enums;
using System.Collections.Generic;
using System;

#nullable enable


public class GameBoard
{
    public CardInstance?[,] Board;
    public List<CardInstance> ActiveCards = new();

    // Events for UI synchronization
    public Action<CardInstance, int, int>? OnCardPlaced;
    public Action<CardInstance, int, int>? OnCardRemoved;
    public Action<CardInstance, int, int, int, int>? OnCardMoved;

    public GameBoard()
    {
        Board = new CardInstance?[5, 5];
    }

    public bool HasCard (int row, int col) => Board[row, col] != null;

    public CardInstance GetCard(int row, int col) => Board[row, col]!;

    public void SetCard (int row, int col, CardInstance card) 
    { 
        Board[row, col] = card; 
        card.Row = row;
        card.Col = col;
        ActiveCards.Add(card);
        OnCardPlaced?.Invoke(card, row, col);
    }

    public void ClearCell(int row, int col) 
    {
        var card = Board[row, col];
        if (card != null)
        {
            ActiveCards.Remove(card);
            OnCardRemoved?.Invoke(card, row, col);
        }
        Board[row, col] = null; 
    }

    public void MoveCard(int row, int col, CardInstance card)
    {
        int oldRow = card.Row;
        int oldCol = card.Col;
        ClearCell(card.Row, card.Col);
        SetCard(row, col, card);
        OnCardMoved?.Invoke(card, oldRow, oldCol, row, col);
    }

    public CardInstance?[] GetCol(int col)
    {
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
            var currentCard = Column[row];

            if (currentCard != null && currentCard.Team != Team) { return currentCard; }

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
