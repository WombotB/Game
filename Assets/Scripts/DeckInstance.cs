using UnityEngine;
using System.Collections.Generic;
using System;

#nullable enable

public class DeckInstance
{
    public DeckData Deck;

    private Queue<CardInstance> cards = new();

    public int Count => cards.Count;

    public DeckInstance(DeckData deck)
    {
        Deck=deck;
    }

    public CardInstance Draw()
    {
        return cards.Dequeue();
    }

    public void Return(CardInstance card)
    {
        cards.Enqueue(card);
    }

    public void AddCard(CardData card) { Deck.initialCards.Add(card); }
    public void RemoveCard(CardData card) { Deck.initialCards.Remove(card); }

    public void Reset()
    {
        cards.Clear();

        foreach (CardData data in Deck.initialCards)
        {
            cards.Enqueue(new CardInstance(data));
        }
    }
}
