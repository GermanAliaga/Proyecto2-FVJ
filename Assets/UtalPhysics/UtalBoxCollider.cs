using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtalBoxCollider : UtalCollider
{
    //public Vector3 size;
    public Vector3 size { get { return transform.localScale; } set { transform.localScale = value; } }
    List<Vector3> lastCalculatedCorners;
    Vector3 lastPosition;

    public override bool UtalCheckCollision(UtalCollider other)
    {
        UtalBoxCollider otherBox = other as UtalBoxCollider;
        if (otherBox != null)
        {
            List<Vector3> MyCorners = GetAllCorners();
            foreach (Vector3 mC in MyCorners)
            {
                if (otherBox.CheckPointInVolume(mC))
                {
                    if (isTrigger || other)
                    {
                        CheckTrigger(other);
                        return false;
                    }
                    else
                    {
                        TriggerCollisions(mC, otherBox);
                        return true;
                    }
                }
            }
            if (CheckProjectedX(otherBox) || otherBox.CheckProjectedX(this))
            {
                return true;
            }
            List<Vector3> TheirCorners = otherBox.GetAllCorners();
            foreach (Vector3 tC in TheirCorners)
            {
                if (CheckPointInVolume(tC))
                {
                    if (isTrigger || other)
                    {
                        CheckTrigger(other);
                        return false;
                    }
                    else { 
                        TriggerCollisions(tC, otherBox);
                        return true;
                    }
                }
            }
        }
        UtalSphereCollider sphereCollider = other as UtalSphereCollider;
        if (sphereCollider != null)
        {
            return sphereCollider.UtalCheckCollision(this);
        }
        return false;
    }
    public bool CheckProjectedX(UtalBoxCollider otherBox)
    {
        List<Vector3> MyCorners = GetAllCorners();
        List<Vector3> ProjectedCornersInX = new List<Vector3>();
        List<Vector3> ProjectedCornersInY = new List<Vector3>();
        foreach (Vector3 v in MyCorners)
        {
            ProjectedCornersInX.Add(new Vector3(v.x, v.y, v.z));
            ProjectedCornersInY.Add(new Vector3(v.x, v.y, v.z));
        }
        
        Vector3 minVector, maxVector;
        otherBox.GetMaxMinVectors(out minVector, out maxVector);
        List<Vector3> All = new List<Vector3>();
        for (int i = 0; i < ProjectedCornersInX.Count; i++)
        {
            Vector3 v = ProjectedCornersInX[i];
            v.x = (maxVector.x+minVector.x)/2;
            ProjectedCornersInX[i] = v;
            All.Add(v);
        }
        
        for (int i = 0; i < ProjectedCornersInY.Count; i++)
        {
            Vector3 v = ProjectedCornersInY[i];
            v.y = (maxVector.y + minVector.y) / 2;
            ProjectedCornersInY[i] = v;
            All.Add(v);
        }
        
        foreach (Vector3 v in All)
        {
            //print(gameObject.name + " proX " + v);
            if (CheckPointInVolume(v) && otherBox.CheckPointInVolume(v))
            {
                if (isTrigger || otherBox)
                {
                    CheckTrigger(otherBox);
                    return false;
                }
                else
                {
                    TriggerCollisions(v, otherBox);
                    return true;
                }
            }
        }
        return false;
    }
    void TriggerCollisions(Vector3 collisionPoint, UtalCollider other)
    {
        UtalCollision theirCollision = new UtalCollision();
        UtalCollision myCollision = new UtalCollision();
        theirCollision.collisionPoint = myCollision.collisionPoint = collisionPoint;
        theirCollision.other = this;
        myCollision.other = other;
        utalRigidbody?.UtalOnCollisionEnter(myCollision);
        other.utalRigidbody?.UtalOnCollisionEnter(theirCollision);
    }
    public void GetMaxMinVectors(out Vector3 min, out Vector3 max)
    {
        List<Vector3> allCorners = GetAllCorners();
        Vector3 minVector, maxVector;
        minVector = maxVector = allCorners[0];
        foreach (Vector3 v in allCorners)
        {
            if (minVector.x > v.x)
            {
                minVector.x = v.x;
            }
            if (minVector.y > v.y)
            {
                minVector.y = v.y;
            }
            if (minVector.z > v.z)
            {
                minVector.z = v.z;
            }

            if (maxVector.x < v.x)
            {
                maxVector.x = v.x;
            }
            if (maxVector.y < v.y)
            {
                maxVector.y = v.y;
            }
            if (maxVector.z < v.z)
            {
                maxVector.z = v.z;
            }
        }
        //Debug.Log(gameObject.name + "- min " + minVector);
        //Debug.Log(gameObject.name + "- max " + maxVector);
        max = maxVector;
        min = minVector;
    }
    public bool CheckSphereOnCorners(UtalSphereCollider sphereColl, out UtalCollision coll)
    {
        Vector3 CornerPos = transform.position - Vector3.up * transform.localScale.y / 2 + Vector3.right * transform.localScale.x / 2 + Vector3.forward * transform.localScale.z/2;
        Vector3 CornerPos2 = transform.position - Vector3.up * transform.localScale.y / 2 - Vector3.right * transform.localScale.x / 2 - Vector3.forward * transform.localScale.z/2;
        Vector3 CornerPos3 = transform.position + Vector3.up * transform.localScale.y / 2 - Vector3.right * transform.localScale.x / 2 + Vector3.forward * transform.localScale.z/2;
        Vector3 CornerPos4 = transform.position + Vector3.up * transform.localScale.y / 2 + Vector3.right * transform.localScale.x / 2 - Vector3.forward * transform.localScale.z/2;

        List<Vector3> AllCornerPos = new List<Vector3>();
        List<Vector3> AllCornerVector = new List<Vector3>();
        List<Vector3> AllCornerVector2 = new List<Vector3>();
        AllCornerPos.Add(CornerPos);
        AllCornerPos.Add(CornerPos);
        AllCornerPos.Add(CornerPos);
        AllCornerPos.Add(CornerPos2);
        AllCornerPos.Add(CornerPos2);
        AllCornerPos.Add(CornerPos2);
        AllCornerPos.Add(CornerPos3);
        AllCornerPos.Add(CornerPos3);
        AllCornerPos.Add(CornerPos3);
        AllCornerPos.Add(CornerPos4);
        AllCornerPos.Add(CornerPos4);
        AllCornerPos.Add(CornerPos4);

        AllCornerVector.Add(Vector3.up);
        AllCornerVector.Add(Vector3.right);
        AllCornerVector.Add(Vector3.forward);
        AllCornerVector.Add(Vector3.up);
        AllCornerVector.Add(Vector3.right);
        AllCornerVector.Add(Vector3.forward);
        AllCornerVector.Add(Vector3.up);
        AllCornerVector.Add(Vector3.right);
        AllCornerVector.Add(Vector3.forward);
        AllCornerVector.Add(Vector3.up);
        AllCornerVector.Add(Vector3.right);
        AllCornerVector.Add(Vector3.forward);

        AllCornerVector2.Add(Vector3.right);
        AllCornerVector2.Add(Vector3.forward);
        AllCornerVector2.Add(Vector3.up);
        AllCornerVector2.Add(Vector3.right);
        AllCornerVector2.Add(Vector3.forward);
        AllCornerVector2.Add(Vector3.up);
        AllCornerVector2.Add(Vector3.right);
        AllCornerVector2.Add(Vector3.forward);
        AllCornerVector2.Add(Vector3.up);
        AllCornerVector2.Add(Vector3.right);
        AllCornerVector2.Add(Vector3.forward);
        AllCornerVector2.Add(Vector3.up);
        for (int i = 0; i < AllCornerPos.Count; i++)
        {
            Plane face1 = new Plane(AllCornerVector[i], AllCornerPos[i]);
            Vector3 point = face1.ClosestPointOnPlane(sphereColl.transform.position);
            Plane face2 = new Plane(AllCornerVector2[i], AllCornerPos[i]);
            point = face2.ClosestPointOnPlane(point);
            if (Vector3.Distance(point, sphereColl.transform.position) < sphereColl.Radius)
            {
                Debug.Log("Inside Sphere");
            } 
            if (Vector3.Distance(point, sphereColl.transform.position) < sphereColl.Radius && CheckPointInVolume(point))
            {
                coll = new UtalCollision();
                coll.collisionPoint = point;
                coll.other = this;
                return true;
            }
        }
        coll = null;
        return false;
    }
    public bool CheckPointInVolume(Vector3 point)
    {
        //Debug.Log(gameObject.name + "- Point " + point);
        Vector3 minVector;
        Vector3 maxVector;
        GetMaxMinVectors(out minVector, out maxVector);


        if (point.x < minVector.x || point.x > maxVector.x)
        {
            return false;
        }
        if (point.y < minVector.y || point.y > maxVector.y)
        {
            return false;
        }
        if (point.z < minVector.z || point.z > maxVector.z)
        {
            return false;
        }
        return true;
    }
    public List<Vector3> GetAllCorners()
    {
        if(myTransform.position == lastPosition)
        {
            return lastCalculatedCorners;
        }
        List<Vector3> cornerList = new List<Vector3>();
        cornerList.Add(myTransform.position - size/2);
        cornerList.Add(myTransform.position + size / 2);
        Vector3 sizeAux = size;
        sizeAux.x *= -1;
        cornerList.Add(myTransform.position + sizeAux / 2);
        cornerList.Add(myTransform.position - sizeAux / 2);
        sizeAux = size;
        sizeAux.y *= -1;
        cornerList.Add(myTransform.position + sizeAux / 2);
        cornerList.Add(myTransform.position - sizeAux / 2);
        sizeAux = size;
        sizeAux.z *= -1;
        cornerList.Add(myTransform.position + sizeAux / 2);
        cornerList.Add(myTransform.position - sizeAux / 2);
        lastCalculatedCorners = cornerList;
        lastPosition = myTransform.position;
        return cornerList;
    }

   
}
