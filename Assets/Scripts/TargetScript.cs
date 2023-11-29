using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private float x;
    private float z;

    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(x, transform.position.y, z);
    }
}
