using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetValuesFromPrefab : MonoBehaviour
{

    public GameObject Prefab;
    public UtalRigidbody URPrefab;
    public UtalSphereCollider USPrefab;

    public float newMass = 10;
    public float newRadius = 3;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Masa: " + URPrefab.mass);
        Debug.Log("Radio: " + USPrefab.Radius);
    }

    // Update is called once per frame
    void Update()
    {
        //This only happens when we instantiate
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //We instantiate the Prefab (we create the game object)
            GameObject go = Instantiate(Prefab, transform.position, transform.rotation);
            //We get the components
            UtalRigidbody ur = go.GetComponent<UtalRigidbody>();
            UtalSphereCollider us = go.GetComponent<UtalSphereCollider>();

            //We set the values, we need to have them set before
            ur.mass = newMass;
            us.Radius = newRadius;
        }
    }
}
