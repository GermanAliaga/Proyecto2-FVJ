using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtalPhysicEngine : MonoBehaviour
{
    public static List<UtalCollider> allColliders = new List<UtalCollider>();
    public static List<UtalRigidbody> allRigidbodies = new List<UtalRigidbody>();

    public static Vector3 StaticGravity = new Vector3(0, -9.8f, 0);

    public Vector3 Gravity = new Vector3(0, -9.8f, 0);
    // Update is called once per frame
    void Update()
    {
        StaticGravity = Gravity;
        for(int i=0; i < allColliders.Count; i++)
        {
            for(int j=i+1; j < allColliders.Count; j++)
            {
                if (allColliders[i].UtalCheckCollision(allColliders[j]))
                {
                    allColliders[i].UtalOnCollisionEnter(null);
                    allColliders[j].UtalOnCollisionEnter(null);
                }
            }
        }
        foreach(UtalRigidbody urg in allRigidbodies)
        {
            if (!urg.dontUseGravity)
            {
                urg.AddForce(Gravity * urg.mass);
            }
            urg.ProcessForceAndVelocity();
        }
    }
}
