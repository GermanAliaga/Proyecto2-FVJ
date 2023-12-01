using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    public Node nodeHigh;
    public Node nodeLow;
    public SpringScript spring;
    public bool arriba;

    public float g = -9.8f;

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
    void FixedUpdate()
    {
        spring.length = nodeHigh.position - nodeLow.position;
        spring.position = (nodeHigh.position + nodeLow.position) / 2f;

        float force;
        force = spring.k * (spring.length - spring.lengthIni) + nodeLow.GetComponent<UtalRigidbody>().mass * g;
        nodeLow.GetComponent<UtalRigidbody>().AddForce(new Vector3(0, force, 0));
    }
}