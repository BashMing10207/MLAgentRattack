using UnityEngine;

public class DeadZone : DamageCaster
{
    [SerializeField]
    private float damage = 9999;
    private void OnCollisionStay(Collision collision)
    {
        DamageCast(collision.gameObject, damage);
    }
}
