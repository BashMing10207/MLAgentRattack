using UnityEngine;
using UnityEngine.Events;

public class GameOverEvent : MonoBehaviour,IGetCompoable
{
    private GetCompoParent _parent;
    public UnityEvent OnGameOverEvt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Initialize(GetCompoParent entity)
    {
        _parent = entity;
    }

    public void GameOver()
    {
        OnGameOverEvt?.Invoke();
    }


}
