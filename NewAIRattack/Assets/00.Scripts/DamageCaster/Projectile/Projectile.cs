using UnityEngine;
using UnityEngine.Events;

public class Projectile : SummonedObject
{
    RaycastHit _hit;
    
    protected float _speedMulti = 1, _sizeModify=1,_sizeModifyMulti=1;
    [SerializeField]
    protected float _maxTime = 40;
    [SerializeField]
   protected LayerMask _targetLayer;
    [SerializeField]
    protected ProjectileSO _soData;

    public UnityEvent<GameObject,float> OnAttackEvent;
    public UnityEvent<GameObject,Vector3> OnKnockbackEvent;
    public UnityEvent OnDeadEvent;

    protected float _time = 0;

    protected float _currentSpeed => _soData.Speed + _speedMulti;

    public override void Init(Vector3 startPos, Vector3 forwardDirection, float speedMultif)
    {
        transform.forward = forwardDirection;
        transform.position = startPos;
        _time = 0;
        _speedMulti = speedMultif;
    }

    public virtual void Update()
    {
        if (Physics.SphereCast(transform.position,_soData.Radius,transform.forward,out _hit,_soData.Speed*Time.deltaTime*_speedMulti,_targetLayer))
        {
               OnAttackEvent?.Invoke(_hit.transform.gameObject,_soData.Damage);
               OnKnockbackEvent?.Invoke(_hit.transform.gameObject, transform.forward * _soData.Power * _soData.Speed*_speedMulti);
                Die();
        }

        transform.position = transform.position + transform.forward*_soData.Speed*Time.deltaTime*_speedMulti;
        _time += Time.deltaTime;

        if(_time > _maxTime)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        OnDeadEvent?.Invoke();
    }

    public void BeDisable()
    {
        this.enabled = false;
    }
}
