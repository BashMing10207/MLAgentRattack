using UnityEngine;

public class Stone : MonoBehaviour
{
}
//    public float maxhp = 10, hp = 10, mass = 1, power = 10;
//    public Rigidbody rb;
//    void Start()
//    {
//        hp = maxhp;
//    }
//    public virtual void damage(float damage)
//    {
//        hp -= damage;
//        hp = Mathf.Clamp(hp, 0.05f, maxhp);

//        rb.mass = mass * hp / maxhp;
//    }
//    public virtual void damage(AttackSorce atsource)
//    {
//        damage(atsource.damage);
//        rb.AddForce(atsource.accelDir * atsource.power);
//        print("mmm");
//    }

//    public virtual void damage(AttackSorce atsource, Vector3 hitPos)
//    {
//        damage(atsource.damage);
//        rb.AddForceAtPosition(atsource.accelDir * atsource.power, hitPos);
//    }

//    public abstract void die();

//    public void Damage(float damage)
//    {

//    }
//}