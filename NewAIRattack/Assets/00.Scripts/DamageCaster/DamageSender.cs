using UnityEngine;

public class DamageSender : MonoBehaviour, IGetDamageable,IGetCompoable,IAfterInitable
{
    public Health Target { get; private set; }
    private GetCompoParent _parent;
    public void AfterInit()
    {
        Target = _parent.GetCompo<Health>(true);
    }
    private void Start()
    {
        Target = _parent.GetCompo<Health>(true);
    }

    public void GetDamage(float damage)
    {
        Target.GetDamage(damage);
    }
    public void Initialize(GetCompoParent entity)
    {
        _parent = entity;
    }
}
