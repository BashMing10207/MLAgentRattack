using UnityEngine;

public class BuffTickHeal : BuffSO
{
    [SerializeField]
    protected float _healAmount = 1f;
    public override void TurnEffect(GetCompoParent entity)
    {
        entity.GetCompo<Health>().GetDamage(-_healAmount);
        base.TurnEffect(entity);
    }
}
