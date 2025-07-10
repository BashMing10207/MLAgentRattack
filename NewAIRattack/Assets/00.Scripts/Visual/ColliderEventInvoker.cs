using UnityEngine;
using UnityEngine.Events;

public class ColliderEventInvoker : MonoBehaviour
{
    public UnityEvent OnEnter, OnExit,OnStay;

    private void OnCollisionEnter(Collision collision)
    {
        OnEnter?.Invoke();
    }
    private void OnCollisionExit(Collision collision)
    {
        OnExit?.Invoke();
    }
    private void OnCollisionStay(Collision collision)
    {
        OnStay?.Invoke();
    }
}
