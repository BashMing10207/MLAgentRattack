using UnityEngine;

[CreateAssetMenu(fileName = "StatModifierSO", menuName = "SO/Stat/StatModifierSO")]
public class StatModifierSO : ScriptableObject
{
    public Texture2D Icon;

    public string Name = "";

    public int MaxStack = 5;

    public int RemainingTurn = 2;

    public StatSO TargetStat;
    public ModifierType IsMultiply = ModifierType.Multiply; // true: multiply false: plus

    public float ModifierValue = 0.05f;
    public virtual object Clone()
    {
        return Instantiate(this); //(아마도)SO를 만들 때 호출하여 기존 값을 복제하는 역할. https://learn.microsoft.com/en-us/dotnet/api/system.icloneable?view=net-9.0 <- (dd)
    }
}

public enum ModifierType
{
    Add,
    Multiply,
    MultiplyAdd
}