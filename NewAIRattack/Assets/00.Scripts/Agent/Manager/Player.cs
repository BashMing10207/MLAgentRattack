using UnityEngine;

public class Player : GetCompoParent
{
    protected override void Awake()
    {
        base.Awake();

    }
   protected virtual void Start()
    {
        GameManager.Instance.PlayerManagerCompos.Add(this);
    }
}
