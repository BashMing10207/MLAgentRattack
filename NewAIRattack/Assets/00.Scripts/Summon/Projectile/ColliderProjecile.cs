using UnityEngine;
using UnityEngine.Events;

public class ColliderProjecile : Projectile
{

    [SerializeField]
    private Rigidbody _rigidCompo;

    [SerializeField]
    private Vector3 _offset, _gravity;

    public override void Init(Vector3 startPos, Vector3 forwardDirection, float speedMultif)
    {
        transform.forward = forwardDirection;
        transform.position = startPos+_offset;
        _time = 0;
        _speedMulti = speedMultif;

        _rigidCompo.AddForce(transform.forward*(_speedMulti*_soData.SpeedModifyMulti +_soData.Speed),ForceMode.Impulse);
        //_rigidCompo.AddTorque(new Vector3(1, 0, 0), ForceMode.Impulse);
        //_rigidCompo.AddTorque(new Vector3(Random.Range(-1,1), Random.Range(-1, 1), Random.Range(-1, 1)),ForceMode.Impulse);
    }

    public override void Update()
    {
        _time += Time.deltaTime;
        if (_time > _maxTime)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        _rigidCompo.AddForce(_gravity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnAttackEvent?.Invoke(collision.gameObject,_soData.Damage);
    }
}
