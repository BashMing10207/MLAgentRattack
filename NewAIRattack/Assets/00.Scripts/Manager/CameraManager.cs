using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour,IGetCompoable,IAfterInitable
{
    public Camera MainCamera1;
    public CinemachineVirtualCamera VirtualCamera;

    private GetCompoParent _entity;
    private PlayerInputSO _playerInputSO;
    private Vector3 _camposOffset = new Vector3(0, 35, 0.01f);


    private float _stoneRotate=0;
    [SerializeField]
    private float _sensitive=5;//감도나 관리등과 같은 기능은 다른 스크립트로 뺴기(1월 이후)

    public void Initialize(GetCompoParent entity)
    {
        _entity = entity;
        
    }
    public void AfterInit()
    {
        _entity.GetCompo<AgentManager>(true).OnSwapUnit += ChangeTargetProcess;
    }

    private void ChangeTargetProcess(Unit unit)
    {
        SetVCamTarget(unit.ViewPivot);
    }

    public void SetVCamTarget(Transform target)
    {
        VirtualCamera.Follow = target;
        VirtualCamera.LookAt = target;
    }

    private void Start()
    {
        _playerInputSO = GameManager.Instance.PlayerInputSO;
        _playerInputSO.OnMouseScroll += Scrol;
    }

    private void Scrol(float a)
    {
        if (_playerInputSO.IsPressing2)
        {
            _camposOffset.z += a*Time.deltaTime*_sensitive;
        }
        
    }

    private void Update()
    {
        if (_playerInputSO.IsPressing2)
        {
            SetView(_playerInputSO.MouseDelta*Time.deltaTime);
        }

        float angle = Vector2.SignedAngle(new Vector2(0, 1), new Vector2(-_camposOffset.y, -_camposOffset.z));

        VirtualCamera.Follow.rotation = Quaternion.Euler(angle, _stoneRotate, 0f);

        var transposer = VirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = _camposOffset;
    }

    public void SetView(Vector2 mouseMov)
    {
        _stoneRotate += mouseMov.x * _sensitive;
        _camposOffset = new Vector3(0,Mathf.Clamp(_camposOffset.y + -mouseMov.y * _sensitive,0,35),Mathf.Clamp(_camposOffset.z - mouseMov.y, -25,0.01f));


    }


}
