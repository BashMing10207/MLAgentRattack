using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttachedUI : MonoBehaviour
{
    [SerializeField]
    private Vector3 _minScale = Vector3.one, _maxScale = Vector3.one;
    [SerializeField]
    float _minDistance = 0f, _maxDistance = 100f;

    //void FixedUpdate()
    //{
    //    transform.localScale = Vector3.Lerp(_minScale, _maxScale, Mathf.SmoothStep(_minDistance, _maxDistance, Vector3.Distance(Camera.main.transform.position, transform.position)));  
    //}
}
