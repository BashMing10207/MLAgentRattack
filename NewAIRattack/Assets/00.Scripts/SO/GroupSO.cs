
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GroupSO", menuName = "SO/GroupSO")]
public class GroupSO : ScriptableObject
{
    public string GroupName = "Ming";

    public List<SetablePair<GroupSO, int>> RealationLV = new(); //Dictionary는 직렬화를 지원치 않음. 또한 순회를 돌아야 하는 경우가 많기에 링크드 리스트로

    public void AddRealabtionLV(GroupSO group,int value)
    {
        bool bisfound = false;
        for(int i =0; i < RealationLV.Count;i++)
        {
            if (RealationLV[i].First == group)
            {
                int value2 = RealationLV[i].Second;

            }
        }
    }

}
