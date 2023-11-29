using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private float initY;
    private float deltaD;

    // Start is called before the first frame update
    void Start()
    {
        initY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        deltaD = target.transform.position.y - transform.position.y;

        transform.position = new Vector3 (transform.position.x, initY + deltaD / 2, transform.position.x);
    }
}
