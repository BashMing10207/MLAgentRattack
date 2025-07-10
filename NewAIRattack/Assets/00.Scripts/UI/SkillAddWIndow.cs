using UnityEngine;
using UnityEngine.Events;

public class SkillAddWIndow : MonoBehaviour
{
    private int _addSkillcount = 0;
    public UnityEvent OnAddSkill;

    public void AddSkill()
    {
        if (_addSkillcount <= 0)
            return;
        gameObject.SetActive(true);
        _addSkillcount--;
        OnAddSkill.Invoke();
    }

    public void AddSkillCount()
    {
        _addSkillcount++;
    }

    private void OnDisable()
    {
        Invoke(nameof(AddSkill), 0.1f);
    }
}
