 
using UnityEngine;

public class EnemyManager : AgentManager
{

    //적 스테이트:
    //1.전진배치(뒤에있는 돌을 전선으로) (적과 플레이어 사이에 장애물이 있거나 가장 먼 적이 이동)
    //2.원거리 공격 (플레이어와 적 사이에 장애물이 없을 때).
    //3.근접공격 (플레이어와 가장 가깝고 사거리 내에 있는 경우 사용
    //4.임팩트 (제자리 폭발 등) (근접공격과 동일)
    //5.돌진(들이받기) 위 어느것도 해당되지 않지만, 움직이기만 있을 때.

    protected override void Start()
    {
        base.Start();
        //MultiGameManager.Instance.PlayerManagerCompo.Add(this);
    }
}
