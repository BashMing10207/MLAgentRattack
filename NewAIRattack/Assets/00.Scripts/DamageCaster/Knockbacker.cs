using UnityEngine;

public abstract class Knockbacker : MonoBehaviour
{
    public virtual void KnockbackCast(GameObject target, Vector3 dir)
    {
        //if (target.TryGetComponent<IGetDamageable>(out IGetDamageable healthcompo))
        //{
        //    (healthcompo as DamageSender).Target.Owner.GetCompo<StonePhysics>(true).AddForce(dir);
        //}
        Rigidbody rb = target.GetComponentInParent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(dir, ForceMode.Impulse);
        }
    }
    public virtual void KnockbackCast(GameObject target, Vector3 dir,Vector3 hitPoint)
    {
        //if (target.TryGetComponent<IGetDamageable>(out IGetDamageable healthcompo))
        //{
        //    (healthcompo as DamageSender).Target.Owner.GetCompo<StonePhysics>(true).AddForceAt(hitPoint,dir);
        //}
        Rigidbody rb = target.GetComponentInParent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForceAtPosition(dir, hitPoint,ForceMode.Impulse);
        }
    }

}

