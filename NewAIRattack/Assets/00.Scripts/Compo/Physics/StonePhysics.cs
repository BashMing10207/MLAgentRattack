using UnityEngine;

public class StonePhysics : MonoBehaviour, IGetCompoable
{
    private Rigidbody _rbCompo;
    private Collider _collider;
    private Unit _agent;

    [SerializeField] protected float _limitStepHeight = 0.5f, _maxRayDIstance = 10f, _bodyHeightOffset = 0.42f;
    [SerializeField] protected Vector3 _rayOffset = new(0f, 6f, 0.5f);
    [SerializeField] protected LayerMask _gDCheckRayLM; // Ground Check Raycast Layer Mask !
    public void Initialize(GetCompoParent entity)
    {
        _rbCompo = entity.GetComponentInChildren<Rigidbody>();
    }

    public void AddForce(Vector3 dir)
    {
        _rbCompo.AddForce(dir,ForceMode.Impulse);
    }
    
    public void AddForceAt(Vector3 hitpoint, Vector3 dir)
    {
        _rbCompo.AddForceAtPosition(dir, hitpoint, ForceMode.Impulse);
    }

}
