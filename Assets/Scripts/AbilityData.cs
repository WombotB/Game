using UnityEngine;

[CreateAssetMenu(fileName = "AbilityData", menuName = "Scriptable Objects/AbilityData")]
public abstract class AbilityData : ScriptableObject
{
    public abstract Ability Create(CardInstance card);
}
