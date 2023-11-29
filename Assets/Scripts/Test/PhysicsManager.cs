using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    public Node nodeHigh;
    public Node nodeLow;
    public Spring spring;

    public float g = 9.8f;

    public enum integration
    {
        ExplicitEuler = 0,
        SymplecticEuler = 1,
    }

    public integration integrationMethod;
    public float h = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        nodeHigh.Start();
        nodeLow.Start();
        spring.lengthIni = nodeHigh.position - nodeLow.position;
        spring.length = spring.lengthIni;
        spring.position = (nodeHigh.position - nodeLow.position) / 2f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        switch(integrationMethod)
        {
            case integration.ExplicitEuler:
                integrateExplicitEuler();
                break;

            case integration.SymplecticEuler:
                integrateSymplecticEuler();
                break;

           default:
                print("error lol");
                break;
        }

         spring.length = nodeHigh.position - nodeLow.position;
         spring.position = (nodeHigh.position + nodeLow.position) / 2f;
    }

    void integrateExplicitEuler()
    {
        float force;
        nodeLow.position = nodeLow.position + h * nodeLow.vel;
        force = -nodeLow.mass * g + spring.k * (spring.length - spring.lengthIni);
        nodeLow.vel += h * force / nodeLow.mass;
    }
    void integrateSymplecticEuler()
    {
        float force;
        force = -nodeLow.mass * g + spring.k * (spring.length - spring.lengthIni);
        nodeLow.vel += h * force / nodeLow.mass;
        nodeLow.position = nodeLow.position + h * nodeLow.vel;
    }
}
