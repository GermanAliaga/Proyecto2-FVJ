using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UtalCollider : MonoBehaviour
{
    public Transform myTransform;
    public UtalRigidbody utalRigidbody;

    public delegate void UtalOnCollisionEnterDelegate(UtalCollision collision);
    public UtalOnCollisionEnterDelegate UtalOnCollisionEnterListener;

    private void Start()
    {
        UtalPhysicEngine.allColliders.Add(this);
    }

    public void UtalOnCollisionEnter(UtalCollision collision)
    {
        UtalOnCollisionEnterListener?.Invoke(collision);
    }

    public abstract bool UtalCheckCollision(UtalCollider other);
}
