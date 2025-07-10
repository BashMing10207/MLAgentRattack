using UnityEngine;

public class CollisonDamageCaster : DamageCaster, IGetCompoable
{
    private Agent _agent;
    private Rigidbody _rbCompo;


    public void Initialize(GetCompoParent entity)
    {
        _agent = entity as Agent;
        _rbCompo = _agent.GetComponentInChildren<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float damage = Vector3.Project(_rbCompo.linearVelocity, (transform.position - collision.transform.position)).magnitude; //* damageMultifieler

        DamageCast(collision.gameObject,  damage);
    }
}
