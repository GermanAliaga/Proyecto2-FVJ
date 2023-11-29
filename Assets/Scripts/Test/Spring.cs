using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float k = 100f;
    public float lengthIni;
    public float length;
    public float position;
    public float size = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, position, transform.position.z);
        transform.localScale = new Vector3(transform.localScale.x, length / size, transform.localScale.z);
    }
}
