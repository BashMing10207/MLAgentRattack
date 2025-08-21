using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatSO", menuName = "SO/Stat/StatSO")]
[Serializable]
public class StatSO : ScriptableObject, ICloneable //SO를 생성할때마다 인스턴스 되게 하는거?
{
    public string StatName;
    public string Description;

    public float Value => _baseValue * GetModifierValue(); //람다식 :D
    public float BaseValue => _baseValue;

    [SerializeField]
    protected float _baseValue = 1;
    public List<StatModifierSO> Modifiers = new List<StatModifierSO>();
    //public List<SetablePair<StatModifierSO, int>> TempModifilerAndRemain = new List<SetablePair<StatModifierSO, int>>();
    public virtual object Clone()
    {
        return Instantiate(this); //SO를 만들 때 호출하여 기존 값을 복제하는 역할. https://learn.microsoft.com/en-us/dotnet/api/system.icloneable?view=net-9.0 <- (dd)
    }

    //public void SetBaseValue(float value)
    //{
    //    _baseValue = value; 
    //}

    //protected virtual float GetModifierValue()
    //{
    //    float a = 0;
    //    List<float> b = new List<float>();

    //    if (Modifiers.Count > 0)
    //    {
    //        foreach (var modifier in Modifiers)
    //        {
    //            switch (modifier.IsMultiply)
    //            {
    //                case ModifierType.Multiply:
    //                    b.Add(modifier.ModifierValue);
    //                    break;

    //                case ModifierType.MultiplyAdd:
    //                    a += modifier.ModifierValue;
    //                    break;

    //                case ModifierType.Add:

    //                    break;
    //            }
    //        }
    //    }

    //    a += 1; //((1 + add)*multi) * baseStat
    //    if (Modifiers.Count > 0)
    //    {
    //        foreach (var c in b)
    //        {
    //            a *= c;
    //        }
    //    }

    //        return a;
    //}
    //public void TryAddModifier(StatModifierSO mod)
    //{
    //    //foreach (var modifier in Modifiers)
    //    //{
    //    //    //if (modifier == mod)
    //    //    //{
    //    //    //    modifier.Second = Mathf.Min(modifier.Second+1,mod.MaxStack);
    //    //    //    return;
    //    //    //}
    //    //}
    //    Modifiers.Add(mod);
    //}
    //public void TryRemoveModifier(StatModifierSO mod)
    //{
    //    //foreach (var modifier in Modifiers)
    //    //{
    //    //    //if (modifier == mod)
    //    //    //{
    //    //    //    modifier.Second = Mathf.Min(modifier.Second+1,mod.MaxStack);
    //    //    //    return;
    //    //    //}
    //    //}
    //    Modifiers.Remove(mod);
    //}
    ////public void TryAddTemponaryModifiler(StatModifierSO mod)
    ////{
    ////    //TryAddModifier(mod);
    ////    TempModifilerAndRemain.Add(new SetablePair<StatModifierSO, int>(mod, mod.RemainingTurn));
    ////}

    //public void ModifierTurnLoss()
    //{
    //    for (int i = Modifiers.Count; i >0; i--) 
    //    {
    //        if (Modifiers[i].RemainingTurn > 0)
    //            Modifiers[i].RemainingTurn--;
    //        if(Modifiers[i].RemainingTurn == 0)
    //            Modifiers.Remove(Modifiers[i]);
    //    }
    //}

}
