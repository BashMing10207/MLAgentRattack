using UnityEngine;

public class DamageCaster : MonoBehaviour
{
    public virtual void DamageCast(GameObject target, float damage)
    {
        if (target.TryGetComponent<IGetDamageable>(out IGetDamageable healthcompo))
        {
            healthcompo.GetDamage(damage);
        }
    }
}
