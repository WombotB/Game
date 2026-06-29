using UnityEngine;
using System.Collections.Generic;
using System;

#nullable enable

public class DeckInstance
{
    public DeckData Deck;

    private Queue<CardInstance> Cards = new();
    private List<CardInstance> BaseCards = new();

    public int Count => Cards.Count;

    public DeckInstance(DeckData deck)
    {
        Deck=deck;
    }

    public CardInstance Draw()
    {
        return Cards.Dequeue();
    }

    public void Return(CardInstance card)
    {
        Cards.Enqueue(card);
    }

    public void AddCard(CardInstance card) { BaseCards.Add(card); }
    public void RemoveCard(CardInstance card) { BaseCards.Remove(card); }

    public void Reset()
    {
        Cards.Clear();

        foreach (CardInstance card in BaseCards)
        {
            Cards.Enqueue(card);
        }
    }
}
