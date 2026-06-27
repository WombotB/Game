using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardData : ScriptableObject
{
    public string Name;

    public int Health;
    public int Damage;

    public CardTeam Team;

    public CardWeight Weight;
    public CardClass cardClass;

    public AbilityType Ability;

    public Vector2Int Position;

}
