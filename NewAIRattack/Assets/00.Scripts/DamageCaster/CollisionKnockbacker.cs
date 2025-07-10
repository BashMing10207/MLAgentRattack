using UnityEngine;

public class CollisionKnockbacker : Knockbacker
{
    [SerializeField]
    private float _damage = 1, _power = 20;

    public void Attack(GameObject gam)
    {
        Vector3 attackdir = (gam.transform.position - transform.position).normalized * _power;
        KnockbackCast(gam, attackdir);
    }

    private void OnTriggerStay(Collider other)
    {
        Attack(other.gameObject);
    }
}
