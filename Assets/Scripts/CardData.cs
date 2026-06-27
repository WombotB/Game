using UnityEngine;
using Enums;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardData : ScriptableObject
{
    public string Name;

    public int MaxHealth;
    public int MaxDamage;

    public CardWeight Weight;
    public CardClass cardClass;

    //public AbilityType Ability;
}
