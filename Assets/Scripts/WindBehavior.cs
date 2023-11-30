using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBehavior : UtalGameObject
{
    public float windForceMagnitude = 0;

    private float actTime;
    private float maxTime = 5;

    private void Update()
    {
        if (actTime >= maxTime)
        {
            windForceMagnitude = Random.Range(-100, 100);
            actTime = 0;
        }

        actTime += Time.deltaTime;
    }
    public override void UtalOnTriggerStay(UtalCollider collider)
    {
        //Debug.Log(collider.utalRigidbody.gameObject.name);
        collider.utalRigidbody.AddForce(-Vector3.right * windForceMagnitude);
    }
}
