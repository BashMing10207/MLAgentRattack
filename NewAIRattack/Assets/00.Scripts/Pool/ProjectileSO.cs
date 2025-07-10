using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ming/Projectile")]
public class ProjectileSO : ScriptableObject
{
    public float Speed, Damage,Power,Radius,Down,SpeedModifyMulti=0.1f;
    public GameObject GameObj,DieEffect;
    
}
