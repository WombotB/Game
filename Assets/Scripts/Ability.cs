using UnityEngine;
using Enums;

public class Ability
{
    private CardInstance Card;

    public Ability(CardInstance card) {  Card = card; }

    public virtual void OnSpawn(GameManager game)  { }

    //При расширении лучше сделать отдельный метод GetTargets() чтобы не заморачиваться с новыми способностями.
    public virtual void OnTurn(GameManager game)   
    {
        var Board = game.Match.Board;

        switch (Card.Data.cardClass)
        {
            case CardClass.Melee:
                var FrontCard = Board.GetFrontCard(Card);
                if (FrontCard != null && FrontCard.Team != Card.Team) { OnAttack(game, new CardInstance[] { FrontCard }); }
                else { OnMove(game); }
                break;
            case CardClass.Ranged:
                var ClosestEnemy = Board.GetClosestEnemy(Card);
                if (ClosestEnemy != null && ClosestEnemy.Team != Card.Team) { OnAttack(game, new CardInstance[] { ClosestEnemy }); }
                else { OnMove(game); }
                break;
        }
    }

    public virtual void OnAttack(GameManager game, CardInstance[] targets) 
    {
        foreach (CardInstance target in targets) { target.Data.Ability.OnDamage(game, Card.CurrentDamage); }
    }

    public virtual void OnMove(GameManager game)   
    {
        var Board = game.Match.Board;
    }

    public virtual void OnDamage(GameManager game, int damage) 
    {
        
    }

    public virtual void OnDeath(GameManager game)  { }

}
