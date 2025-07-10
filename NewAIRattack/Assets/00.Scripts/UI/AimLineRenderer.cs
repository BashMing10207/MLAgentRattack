using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimLineRenderer : MonoBehaviour, IGetCompoable,IAfterInitable
{
    private UserPlayer _playerManager;
    private PlayerAgentManager _agentManager;
    [SerializeField]
    private LineRenderer _lineRenderer;
    [SerializeField]
    private float _sizeMulti=15;
    public void Initialize(GetCompoParent entity)
    {
        _playerManager = entity as UserPlayer;
    }
    public void AfterInit()
    {
        _agentManager = _playerManager.GetCompo<PlayerAgentManager>();
    }

    //private void Update()
    //{
    //    _lineRenderer.enabled = false;
    //    if (GameManager.Instance.IsPlayerturn)
    //    {
    //        if (_agentManager.IsHolding)
    //        {
    //            LineRender();

    //        }
    //    }
    //}

    public void DisableLinRender()
    {
        _lineRenderer.enabled = false;
    }

    public void LineRender()
    {
        //if(Physics.Raycast(Camera.main.ViewportPointToRay(_playerManager.PostMousePos),out RaycastHit hit))
        //{
        //    Vector3 point1 =hit.point;
        //    Vector3[] arr = { };
        //}
        _lineRenderer.enabled=true;
        Vector3 stonepos = _agentManager.SelectedUnit().transform.position;
        Vector3 rot = _playerManager.GetCompo<CameraManager>().MainCamera1.transform.eulerAngles;
        Vector3 dir = Quaternion.Euler(0, rot.y, 0)*(BashUtils.V2ToV3(Mouse.current.position.value - _agentManager.PostMousePos) / Screen.width*_sizeMulti);
        Vector3[] arr = {stonepos, stonepos + dir.magnitude *(dir+ new Vector3(0,_agentManager.Upward,0)).normalized};
        _lineRenderer.SetPositions(arr);
    }


}
