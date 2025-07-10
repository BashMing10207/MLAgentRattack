using UnityEngine;
using UnityEngine.InputSystem;

public class TestMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerInputSO _playerInputSO;


    [SerializeField]
    private Rigidbody _rigidbody;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Keyboard.current.qKey.IsPressed())
        {
            RaycastHit hit;
            
            if(Physics.Raycast(Camera.main.ScreenPointToRay(_playerInputSO.MousePos),out hit))
            {
                _rigidbody.AddForce((hit.point- transform.position)/3, ForceMode.Impulse);
            }

        }
    }
}
