using UnityEngine;

public class GetableCoponentBase : MonoBehaviour, IGetCompoable
{
    public GetCompoParent Parent;
    public virtual void Initialize(GetCompoParent entity)
    {
        Parent = entity;
    }
}
