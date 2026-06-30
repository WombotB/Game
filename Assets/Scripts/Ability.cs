using UnityEngine;
using Enums;

public class Ability
{
    private CardInstance Card;

    public Ability(CardInstance card) {  this.CardInstance = card; }

    public virtual void OnSpawn(GameManager game)  { }

    public virtual void OnTurn(GameManager game)   
    {
        switch(cardClass)
        {
            case cardClass.Melee:
                if (game.Match.Board.GetCol(Card.col) )
            case cardClass.Ranged:
        }
    }

    public virtual void OnAttack(GameManager game) 
    {
        
    }

    public virtual void OnMove(GameManager game)   
    {
        
    }

    public virtual void OnDamage(GameManager game) 
    {
        
    }

    public virtual void OnDeath(GameManager game)  { }
}
