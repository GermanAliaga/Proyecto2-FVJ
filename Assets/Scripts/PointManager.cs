using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    private int points = 0;

    public void Update()
    {
       // Debug.Log(points);
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
