using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour,IGetCompoable,IAfterInitable
{
    private Agent _agent;
    private Health _health;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private TextMeshProUGUI _textMeshPro;

    public void AfterInit()
    {
        _health = _agent.GetCompo<Health>(true);
    }

    public void Initialize(GetCompoParent entity)
    {
        _agent = entity as Agent;

    }

    public void OnHurt()
    {
        
        _image.fillAmount = _health.CurrentHealth/_health.MaxHealth;
        _textMeshPro.text = (_health.CurrentHealth/ _health.MaxHealth*100).ToString()+"%";
    }
}
