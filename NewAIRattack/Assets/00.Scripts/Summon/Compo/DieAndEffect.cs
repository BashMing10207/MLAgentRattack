using UnityEngine;

public class DieAndEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject _deadEffect;
    [SerializeField]
    private float _delayTime = 0;
    [SerializeField]
    private Vector3 _offset,_direction;
    public virtual void OnDead()
    {
        OnDead(transform,transform.forward, 1);
    }

    public virtual void OnDead(Transform targetTrm, Vector3 direction, float scale)
    {
        if (_deadEffect != null)
        {
            Transform instance;
            if (_direction != Vector3.zero)
            {
                instance = Instantiate(_deadEffect, targetTrm.position + _offset, Quaternion.LookRotation(_direction,Vector3.up)).transform;
            }
            else
            {
                instance = Instantiate(_deadEffect, targetTrm.position + _offset, Quaternion.LookRotation(direction)).transform;
            }

            instance.localScale *= scale;

        }
        Destroy(gameObject,_delayTime);
    }
}
