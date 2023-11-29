using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtalSphereCollider : UtalCollider
{
    public float Radius { get { return transform.localScale.x/2; } set { transform.localScale = Vector3.one * value*2; } }
    public override bool UtalCheckCollision(UtalCollider other)
    {
        UtalSphereCollider otherSphere = other as UtalSphereCollider;
        if(otherSphere != null)
        {
            if (Radius + otherSphere.Radius > Vector3.Distance(myTransform.position, otherSphere.myTransform.position))
            {
                UtalCollision utalCollision = new UtalCollision();
                Vector3 Direction = otherSphere.transform.position - transform.position;
                float prop = Radius / (Radius + otherSphere.Radius);
                utalCollision.collisionPoint = transform.position + prop * Direction;
                utalCollision.other = otherSphere;

                UtalCollision utalCollisionOther = new UtalCollision();
                utalCollisionOther.collisionPoint = utalCollision.collisionPoint;
                utalCollisionOther.other = this;

                utalRigidbody?.UtalOnCollisionEnter(utalCollision);
                other.utalRigidbody?.UtalOnCollisionEnter(utalCollisionOther);
                if (isTrigger || other.isTrigger)
                {
                    CheckTrigger(other);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        UtalBoxCollider otherBoxCollider = other as UtalBoxCollider;
        if (otherBoxCollider != null)
        {
            Vector3[] sphereBoxPoints = new Vector3[6];
            sphereBoxPoints[0] = transform.position + new Vector3(Radius, 0, 0);
            sphereBoxPoints[1] = transform.position + new Vector3(-Radius, 0, 0);
            sphereBoxPoints[2] = transform.position + new Vector3(0, Radius, 0);
            sphereBoxPoints[3] = transform.position + new Vector3(0, -Radius, 0);
            sphereBoxPoints[4] = transform.position + new Vector3(0,0, Radius);
            sphereBoxPoints[5] = transform.position + new Vector3(0, 0, -Radius);

            foreach(Vector3 point in sphereBoxPoints)
            {
                if (otherBoxCollider.CheckPointInVolume(point))
                {
                    UtalCollision utalCollision = new UtalCollision();
                    utalCollision.collisionPoint = point;
                    utalCollision.other = otherBoxCollider;

                    UtalCollision utalCollisionOther = new UtalCollision();
                    utalCollisionOther.collisionPoint = utalCollision.collisionPoint;
                    utalCollisionOther.other = this;

                    if (isTrigger || other.isTrigger)
                    {
                        CheckTrigger(other);
                        return false;
                    }
                    else
                    {
                        utalRigidbody?.UtalOnCollisionEnter(utalCollision);
                        other.utalRigidbody?.UtalOnCollisionEnter(utalCollisionOther);
                        return true;
                    }
                }
                UtalCollision coll = null;
                if(otherBoxCollider.CheckSphereOnCorners(this, out coll))
                {
                    UtalCollision utalCollisionOther = new UtalCollision();
                    utalCollisionOther.collisionPoint = coll.collisionPoint;
                    utalCollisionOther.other = this;
                    if(isTrigger || other.isTrigger)
                    {
                        CheckTrigger(other);
                        return false;
                    }
                    else
                    {
                        utalRigidbody?.UtalOnCollisionEnter(coll);
                        other.utalRigidbody?.UtalOnCollisionEnter(utalCollisionOther);
                        return true;
                    }
                }
            }
        }
        return false;
    }
    
}
