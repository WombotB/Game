using UnityEngine;
using Enums;
using System.Collections.Generic;
using System;

public class Player
{
    public CardTeam Team;

    public Deck Deck;

    public List<CardInstance> Hand = new();

    public Player (CardTeam team, Deck deck)
    {
        Team = team;
        Deck = deck;
    }

    public void Draw()
    {
        if (Hand.Count < 3 && Deck.Count > 0)
        {
            Hand.Add(Deck.Draw());
        }
    }
}
