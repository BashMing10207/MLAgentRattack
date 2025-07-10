using UnityEngine;
using UnityEngine.Events;

public class TurnManager : MonoBehaviour,IGetCompoable
{
    public int TurnCount = 0; //직렬화 되어야 디버그가 편하고 가져다 써야하니까 퍼블릭.(public set 하면 직렬화가 안디 ㅠㅠ)

    public UnityEvent OnTurnEndEvent;

    private GetCompoParent _parent;

    private void Start()
    {
        GameManager.Instance.OnTurnEndEvent += TurnAdd;
    }

    public void TurnAdd()
    {
        TurnCount++;
        OnTurnEndEvent?.Invoke();
    }

    public void Initialize(GetCompoParent entity)
    {
        _parent = entity;
    }
}
