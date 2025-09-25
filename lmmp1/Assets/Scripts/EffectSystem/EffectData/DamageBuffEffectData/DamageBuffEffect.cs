
public class DamageBuffEffect : Effect
{

    public override void EffectEnd(ActorStats owner)
    {
        owner.attackDamage -= ((DamageBuffEffectData)EffectData).DamageBuff;
    }

    public override void EffectStart(ActorStats owner)
    {
        owner.attackDamage += ((DamageBuffEffectData)EffectData).DamageBuff;
    }
}
