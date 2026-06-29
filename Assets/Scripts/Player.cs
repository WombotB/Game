using UnityEngine;
using Enums;
using System.Collections.Generic;
using System;

public class Player
{
    public CardTeam Team;

    public Deck Deck;

    public Hand Hand = new Hand();

    public Player (CardTeam team, Deck deck)
    {
        Team = team;
        Deck = deck;
    }

}
