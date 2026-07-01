using UnityEngine;
using Enums;
using System.Linq;

public class TurnManager
{
    private GameManager _game;
    private bool _waitingForPlayer = false;

    public TurnManager (GameManager game)
    {
        _game = game;
    }

    public void OnPlayerPlacedCard(CardInstance card, int row, int col)
    {
        if (!_waitingForPlayer) return;
        _waitingForPlayer = false;

        Player player = _game.Match.Player;

        _game.Match.Board.SetCard(row, col, card);
        player.Hand.Remove(player.Hand.Cards.IndexOf(card));
        player.Hand.Draw(player.Deck);

        P2_OpponentPlace();
    }

    public void P1_StartTurn()
    {
        _game.Match.Turn++;

        // Ждём ход игрока через инпут
        _waitingForPlayer=true;
    }

    protected void P2_OpponentPlace()
    {
        // Воспроизведение записи
        P3_Ranged();
    }

    protected void P3_Ranged()
    {
        var toAct = _game.Match.Board.ActiveCards
            .Where(c => c.Data.CardClass == CardClass.Ranged)
            .ToList();

        foreach (var card in toAct)
            if (!card.IsDead) card.Ability.OnTurn(_game);

        P4_Melee();
    }

    protected void P4_Melee()
    {
        var toAct = _game.Match.Board.ActiveCards
            .Where(c => c.Data.CardClass == CardClass.Melee)
            .ToList();

        foreach (var card in toAct)
            if (!card.IsDead) card.Ability.OnTurn(_game);

        P5_CheckWin();
    }

    protected void P5_CheckWin()
    {
        _game.CheckWin();
        P6_EndTurn();
    }

    protected void P6_EndTurn()
    {
        P1_StartTurn();
    }
}
