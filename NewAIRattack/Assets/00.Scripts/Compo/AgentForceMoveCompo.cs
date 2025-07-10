using UnityEngine;

public class AgentForceMoveCompo : MonoBehaviour,IGetCompoable
{
    private GetCompoParent _parent;

    private Vector3 _targetPos = Vector3.zero;

    private Rigidbody _rbCompo;

    private float _moveTime;
    public void Initialize(GetCompoParent entity)
    {
        _parent = entity;
        _rbCompo = _parent.GetComponent<Rigidbody>();
    }


    public void SetTargetPos(Vector3 pos)
    {
        _targetPos = pos;
    }

    public void SetMoveTime(float time)
    {
        _moveTime = time;
        _rbCompo.isKinematic = true;
    }

    private void EndMove()
    {
        _rbCompo.isKinematic = false;
    }

    private void Update()
    {
        if(_moveTime > 0)
        {
            _parent.transform.position = Vector3.Lerp(_parent.transform.position, _targetPos, Time.deltaTime*20);
            _moveTime -= Time.deltaTime;

            if (_moveTime > 0)
            {
                EndMove();
            }
        }
    }
}
