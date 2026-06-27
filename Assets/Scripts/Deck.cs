using UnityEngine;
#nullable enable

public class Deck
{
    private Queue<CardInstance> cards;

    private CardData[] initialCards;

    public int Count;

    public Deck(List<CardData> cards)
    {
        initialCards = cards;
    }

    public CardInstance Draw()
    {
        Count -= 1;
        return cards.Dequeue();
    }

    public void Return(CardInstance card)
    {
        Count += 1;
        cards.Enqueue(card);
    }

    public void AddCard(CardData card) {initialCards.Add(card);}

    public void RemoveCard(CardData card) {initialCards.Remove(card);}

    public void Reset()
    {
        foreach (CardData data in initialCards)
        {
            Count += 1;
            cards.Enqueue(new CardInstance(data));
        }
    }
}
