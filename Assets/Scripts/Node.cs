using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public float mass = 5f;
    public Vector3 positionV;
    public float position;
    public float vel;
    public int score;

    private UtalRigidbody rb2D;

    // Start is called before the first frame update
    public void Start()
    {
        rb2D = GetComponent<UtalRigidbody>();
        position = transform.position.y;
        positionV = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position.y;
        transform.position = new Vector3(positionV.x, transform.position.y, positionV.z);

        if(rb2D != null )
        {
            rb2D.velocity = new Vector3(0, rb2D.velocity.y, 0);

        }
    }
}
