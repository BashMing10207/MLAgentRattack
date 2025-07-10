using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour    
{
    [SerializeField]
    private TextMeshProUGUI _description;

    public void Init(Vector3 pos, string s)
    {
        transform.position = pos;
        _description.text = s;
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
