
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GroupSO", menuName = "SO/GroupSO")]
public class GroupSO : ScriptableObject
{
    public string GroupName = "Ming";

    public List<SetablePair<GroupSO, int>> RealationLV = new(); //Dictionary�� ����ȭ�� ����ġ ����. ���� ��ȸ�� ���ƾ� �ϴ� ��찡 ���⿡ ��ũ�� ����Ʈ��

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
