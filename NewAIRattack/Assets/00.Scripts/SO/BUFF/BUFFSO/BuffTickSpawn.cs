using UnityEngine;

public class BuffTickSpawn : BuffSO
{
    public GameObject GameObject;
    public override void TurnEffect(GetCompoParent entity)
    {
        Instantiate(GameObject,entity.transform.position,entity.transform.rotation);
        base.TurnEffect(entity);
    }
}
