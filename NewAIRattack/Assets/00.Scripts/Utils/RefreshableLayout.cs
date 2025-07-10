using UnityEngine;
using UnityEngine.UI;

public class RefreshableLayout : GridLayoutGroup
{
    public void Refresh()
    {
        SetDirty();
    }
}
