using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsoluteRotate : MonoBehaviour
{
    [SerializeField]
    bool _isBlack;
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, _isBlack ? 0:180, 0f);
    }
}
