using UnityEngine;
using System.Collections.Generic;
using System;

#nullable enable

public class Deck
{
    private Queue<CardInstance> cards = new();

    private List<CardData> initialCards;

    public int Count => cards.Count;

    public Deck(List<CardData> cards)
    {
        initialCards = new List<CardData>(cards);
    }

    public CardInstance Draw()
    {
        return cards.Dequeue();
    }

    public void Return(CardInstance card)
    {
        cards.Enqueue(card);
    }

    public void AddCard(CardData card) {initialCards.Add(card);}

    public void RemoveCard(CardData card) {initialCards.Remove(card);}

    public void Reset()
    {
        cards.Clear();

        foreach (CardData data in initialCards)
        {
            cards.Enqueue(new CardInstance(data));
        }
    }
}
