using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UtalCollider : MonoBehaviour
{
    public Transform myTransform;
    public UtalRigidbody utalRigidbody;
    public bool isTrigger = false;

    public delegate void UtalOnCollisionEnterDelegate(UtalCollision collision);
    public UtalOnCollisionEnterDelegate UtalOnCollisionEnterListener;

    public delegate void UtalOnTriggerStayDelegate(UtalCollider otherCollider);
    public UtalOnTriggerStayDelegate UtalOnTriggerStayListener;

    private void Start()
    {
        UtalPhysicEngine.allColliders.Add(this);
    }
    public void UtalTriggerStay(UtalCollider otherCollider)
    {
        UtalOnTriggerStayListener(otherCollider);
    }
    public void UtalOnCollisionEnter(UtalCollision collision)
    {
        UtalOnCollisionEnterListener?.Invoke(collision);
    }

    public abstract bool UtalCheckCollision(UtalCollider other);

    public void CheckTrigger(UtalCollider other)
    {
        if (isTrigger || other.isTrigger)
        {
            if (UtalOnTriggerStayListener != null)
            {
                UtalOnTriggerStayListener(other);
            }
            if (other.UtalOnTriggerStayListener != null)
            {
                other.UtalOnTriggerStayListener(this);
            }
        }
    }
}
