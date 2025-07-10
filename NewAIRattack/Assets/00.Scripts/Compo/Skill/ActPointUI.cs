using TMPro;
using UnityEngine;

public class ActPointUI : MonoBehaviour
{
    [SerializeField]
    private AgentActCommander _actCommander;
    [SerializeField]
    private TextMeshProUGUI _textMeshProUGUI;

    private int ActionPointPointer;

    [SerializeField]
    private string _frontTxt;
    [SerializeField]
    private string _backTxt;

    private void Start()
    {
        SetUI();
    }

    public void SetUI()
    {
        int ap = _actCommander.ActPoint;
        string backtxt = "";

        for (int i = 0; i < ap; i++)
        {
            backtxt += _backTxt;
        }
        _textMeshProUGUI.text = _frontTxt + backtxt;
    }
}
