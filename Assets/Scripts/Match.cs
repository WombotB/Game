using UnityEngine;
using Enums;

public class Match
{
    public Player Player;// = new Player(CardTeam.Human, new DeckInstance(HumanDeck));
    public Player Reflection;// = new Player(CardTeam.Reflection, ;

    public int Turn;

    public GameBoard Board;

    public Match(DeckData humanDeck, DeckData reflectionDeck)
    {
        Player = new Player(CardTeam.Human, new DeckInstance(humanDeck));
        Reflection = new Player(CardTeam.Reflection, new DeckInstance(reflectionDeck));
        Board = new GameBoard();
    }

    public Player GetPlayer (CardTeam team)
    {
        if (Player.Team == team) { return Player; }

        return Reflection;
    }
}
