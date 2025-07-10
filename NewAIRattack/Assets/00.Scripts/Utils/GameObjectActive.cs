using UnityEngine;

public class GameObjectActive : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameObject;

    public void SetActive (bool enable)
   {
        _gameObject.SetActive (enable);
    }
}
