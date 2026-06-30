using UnityEngine;
using Enums;
using System.Collections.Generic;
using System;

public class Player
{
    public CardTeam Team;

    public DeckInstance Deck;

    public Hand Hand = new Hand(3);

    public Player (CardTeam team, DeckInstance deck)
    {
        Team = team;
        Deck = deck;
    }

}
