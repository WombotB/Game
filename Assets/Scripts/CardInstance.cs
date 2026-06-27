using UnityEngine;
using Enums;

public class CardInstance
{
    public CardData Data;

    public CardTeam Team;

    public int CurrentHealth;
    public int CurrentDamage;

    public Vector2Int Position;

    public bool IsDead => CurrentHealth <= 0;

    public CardInstance (CardData Data, CardTeam Team)
    {
        CurrentHealth = Data.Health;
        CurrentDamage = Data.Damage;
    }
}
