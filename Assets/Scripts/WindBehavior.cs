using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBehavior : UtalGameObject
{
    public float windForceMagnitude = 10;
    public override void UtalOnTriggerStay(UtalCollider collider)
    {
        //Debug.Log(collider.utalRigidbody.gameObject.name);
        collider.utalRigidbody.AddForce(-Vector3.right * windForceMagnitude);
    }
}
