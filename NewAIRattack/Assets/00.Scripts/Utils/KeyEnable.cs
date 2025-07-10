using UnityEngine;

public class KeyEnable : MonoBehaviour
{
    [SerializeField]
    private PlayerInputSO _playerInput;

    public void OnActive()
    {
        _playerInput.ActiveInput();
    }

    public void OnDisActive()
    {
        _playerInput.DisActivePlayerInput();
    }
}
