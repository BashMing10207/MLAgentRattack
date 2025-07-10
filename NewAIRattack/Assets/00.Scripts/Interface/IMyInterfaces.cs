using UnityEngine;

public class IMyInterfaces
{
    
}

public interface IGetTagable
{
    void AddTag(string tag);

    void RemoveTag(string tag);

    bool HasTag(string tag);

}

public interface IInventoryable
{
    public bool AddItem(ActSO act);
    public bool AddSkill(ActSO act);
    public void RemoveSkill(ActSO act);
    public void RemoveItem(ActSO act);

    public void RemoveSkillorItem(ActSO act);
}