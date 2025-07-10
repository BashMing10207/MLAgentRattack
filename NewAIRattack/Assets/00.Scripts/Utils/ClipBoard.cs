using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class ClipBoard : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _tmpro;
    public void Copy()
    {
        GUIUtility.systemCopyBuffer = _tmpro.text;
    }
}
