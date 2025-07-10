using UnityEngine;

public class Billboard : MonoBehaviour
{
    private void Update()
    {
        //transform.forward = Camera.main.transform.forward;
        transform.rotation = Camera.main.transform.rotation;
    }
}
