using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityStorage : MonoBehaviour
{
    [SerializeField] private AbilityConfig[] abilityConfigs;
    private List<Ability> _abilities = new List<Ability>();
    public void Initialize()
    {
        for (int i = 0; i < abilityConfigs.Length; ++i)
        {
            var builder = abilityConfigs[i].GetBuilder();
            builder.Make();
            _abilities.Add(builder.GetResult());
        }
    }
    public Ability[] GetAbilities() => _abilities.ToArray();
}
