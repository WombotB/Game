using UnityEngine;
using Enums;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardData : ScriptableObject
{
    public string Name;
    public string Description;

    public Sprite Icon;

    public int MaxHealth;
    public int MaxDamage;

    public CardWeight Weight;
    public CardClass cardClass;

    //public AbilityType Ability;
}
