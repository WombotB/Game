using UnityEngine;
using System.Collections.Generic;
using System;

public class Hand
{
    public List<CardInstance> Cards = new();

    public int MaxNumberOfCards;
    public int Count => Cards.Count;

    public Hand (int maxNumberOfCards)
    {
        MaxNumberOfCards = maxNumberOfCards;
    }

    public void Draw(DeckInstance deck)
    {
        if (!IsFull() && deck.Count > 0)
        {
            Cards.Add(deck.Draw());
        }
    }

    public void Remove(int order)
    {
        Cards.RemoveAt(order);
    }

    public List<CardInstance> Contains()
    {
        return Cards;
    }

    public bool IsFull() => Cards.Count == MaxNumberOfCards;
}
