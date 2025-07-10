using UnityEngine;

public class CamFollower : MonoBehaviour
{
    [SerializeField]
    private Transform _trm;
    private void OnEnable()
    {
        GameManager.Instance.PlayerManagerCompos[0].GetCompo<CameraManager>().SetVCamTarget(_trm);

        //GameManager.Instance.PlayerManagerCompo.GetCompo<CameraManager>().SetVCamTarget(_trm);
    }

    private void OnDisable()
    {
        //Invoke(nameof(ResetCam), 0.5f);
        ResetCam();
    }

    private void ResetCam()
    {
        GameManager.Instance.CurrentClientPlayerManagerCompo.GetCompo<CameraManager>().SetVCamTarget(GameManager.Instance.CurrentClientPlayerManagerCompo.GetCompo<AgentManager>(true).SelectedUnit().ViewPivot); //겟콤포 트루로 가져오는 것은 매우 비윤리적인....
    }
}
