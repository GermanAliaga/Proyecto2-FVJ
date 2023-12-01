using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    private int points = 0;
    public UtalSphereCollider bullet;
    public UtalSphereCollider nodo1;
    public UtalSphereCollider nodo2;
    public UtalSphereCollider nodo3;

    public Node nodito1;
    public Node nodito2;
    public Node nodito3;

    public void Update()
    {
        if(nodo1.UtalCheckCollision(bullet))
        {
            addPoints(nodito1.score);
        }
        if (nodo2.UtalCheckCollision(bullet))
        {
            addPoints(nodito2.score);
        }
        if (nodo3.UtalCheckCollision(bullet))
        {
            addPoints(nodito3.score);
        }
    }

    public void addPoints(int p)
    {
        points += p;
    }

    public int getPoints()
    {
        return points;
    }
}
