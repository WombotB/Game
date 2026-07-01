using UnityEngine;

namespace AbilityDatas
{
    [CreateAssetMenu(menuName = "Abilities/None")]
    public class NoneData : AbilityData { public override Ability Create(CardInstance card) { return new Ability(card); } }




}
