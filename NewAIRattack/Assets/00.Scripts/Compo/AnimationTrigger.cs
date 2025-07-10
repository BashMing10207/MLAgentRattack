using UnityEngine;

public class AnimationTrigger : MonoBehaviour, IGetCompoable
{
    private Agent _agnet;
    public void Initialize(GetCompoParent entity)
    {
        _agnet = entity as Agent;
    }

    public void InvokeAnimationEvent()
    {

    }
}
