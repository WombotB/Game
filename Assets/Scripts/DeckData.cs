using UnityEngine;
using System.Collections.Generic;
using System;

#nullable enable

[CreateAssetMenu(fileName = "DeckData", menuName = "Scriptable Objects/DeckData")]
public class DeckData : ScriptableObject
{
    private List<CardData> initialCards;

    public int Count => initialCards.Count;

    public DeckData (List<CardData> cards)
    {
        initialCards = new List<CardData>(cards);
    }

    //public void AddCard(CardData card) { initialCards.Add(card); }
    //public void RemoveCard(CardData card) { initialCards.Remove(card); }
}
