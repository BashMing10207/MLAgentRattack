using UnityEngine;

public class NoSuperJump : MonoBehaviour,IGetCompoable
{
    private Rigidbody _rbCompo;
    private Collider _collider;
    private Unit _agent;

    [SerializeField] protected float _limitStepHeight = 0.5f,_maxRayDIstance=10f,_bodyHeightOffset = 0.42f;
    [SerializeField] protected Vector3 _rayOffset = new (0f, 6f, 0.5f);
    [SerializeField] protected LayerMask _gDCheckRayLM; // Ground Check Raycast Layer Mask !
    [SerializeField] protected bool _isSnapEnable = true;
    //[SerializeField]
    //private float _limitVelocity=5f,_divimod=1.5f,_maxDistance=0.41f;

    public void Initialize(GetCompoParent entity)
    {
        _agent = entity as Unit;
        _rbCompo = _agent.GetComponent<Rigidbody>();
    }

    //private void FixedUpdate()
    //{
    //    if(_agent.IsSelected)
    //    if (!Physics.Raycast(transform.position,Vector3.down,_maxDistance))
    //    {
    //        if (_rbCompo.velocity.y > _limitVelocity)
    //        {
    //            _rbCompo.velocity -= new Vector3(0, _rbCompo.velocity.y / _divimod, 0);
    //        }
    //    }
    //}

    public void ToggleSnapGround()
    {
        _isSnapEnable = !_isSnapEnable;
    }

    public void EnableSnapGround(bool isSnapEnabled)
    {
        _isSnapEnable=isSnapEnabled;
    }

    //private void FixedUpdate()
    //{
    //    if(_isSnapEnable)
    //    {
    //        Quaternion velocityRot = BashUtils.QuatFromV3AndV3(Vector3.forward, _rbCompo.linearVelocity);

    //        if (Physics.Raycast(_agent.transform.position + _rbCompo.linearVelocity * Time.fixedDeltaTime + _rayOffset, Vector3.down, out RaycastHit hit, _maxRayDIstance, _gDCheckRayLM))
    //        {

    //            float stepHeight = hit.point.y + _bodyHeightOffset - _agent.transform.position.y;
    //            if (stepHeight < _limitStepHeight)
    //            {
    //                _agent.transform.position = new(_agent.transform.position.x, hit.point.y + _bodyHeightOffset, _agent.transform.position.z);
    //            }
    //            //_rbCompo.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;


    //        }
    //        else
    //        {
    //            //_rbCompo.constraints = RigidbodyConstraints.FreezeRotation;
    //        }
    //    }

    //}
}
