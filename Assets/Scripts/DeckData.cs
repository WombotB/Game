using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "DeckData", menuName = "Scriptable Objects/DeckData")]
public class DeckData : ScriptableObject
{
    [SerializeField]
    private List<CardData> initialCards;

    public string Name;
    public string Description;

    public int Count => initialCards.Count;

    //public void AddCard(CardData card) { initialCards.Add(card); }
    //public void RemoveCard(CardData card) { initialCards.Remove(card); }
}
