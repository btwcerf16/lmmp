using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class AbilityBuilder
{
    private AbilityConfig _config;
    protected Ability _ability;
    public AbilityBuilder(AbilityConfig config)
    {
        _config = config;
    }
    public virtual void Make()
    {
        if (_ability == null)
        {
            _ability.SetDescriprion(_config.title, _config.description, _config.displayImage);
            _ability.SetCooldownTime(_config.cooldownTime);
            _ability.SetManaCost(_config.manaCost);
            _ability.SetKey(_config.HotKey);
        }
    }
    public virtual Ability GetResult() => _ability;
}
