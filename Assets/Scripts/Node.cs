using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public float mass = 5f;
    public float position;
    public float vel;

    // Start is called before the first frame update
    public void Start()
    {
        position = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, position, transform.position.z);
    }
}
