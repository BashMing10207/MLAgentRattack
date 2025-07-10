using System.Collections.Generic;
using UnityEngine;

public class OverlapDamageCaster : DamageCaster,IAttackable
{
    [SerializeField]
    private LayerMask _whatisTarget;
    [SerializeField]
    private float _size = 5f, _damage = 1;
    private Collider[] colliders = new Collider[35];
    private List<Rigidbody> _rigidbodies = new List<Rigidbody>();

    private void OnEnable()
    {
        Attack(_damage);
    }
    public void Attack(float damage)
    {
        if (Physics.OverlapSphereNonAlloc(transform.position, _size, colliders, _whatisTarget) > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] == null)
                    break;
                DamageCast(colliders[i].gameObject, _damage);
            }

        }
    }

}
