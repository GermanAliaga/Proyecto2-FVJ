using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private int k;

    private float initY;
    private float initScale;
    private float deltaD;
    private float deltaF;
    private float deltaScale;
    private float aproxScale;

    private float max;
    private float min;

    // Start is called before the first frame update
    void Start()
    {
        initY = transform.position.y;
        initScale = transform.localScale.y;

        max = target.transform.position.y;
        min = this.GetComponent<CapsuleCollider>().bounds.min.y;
    }

    // Update is called once per frame
    void Update()
    {
        deltaD = target.transform.position.y - initY;

        deltaF = target.transform.position.y - max;
        
        
        //Debug.Log(max + " - " + min + " = " + aproxScale + " ||| " + deltaD + " / " + aproxScale + " = " + deltaScale);

        aproxScale = max - min;

        deltaScale = 1 - (deltaD / aproxScale);

        Debug.Log(initY + " " + deltaF);

        transform.position = new Vector3 (transform.position.x, initY + (deltaF / 2), transform.position.z);

        //target.GetComponent<UtalRigidbody>().AddForce(new Vector3(0, -k * deltaF, 0));
        target.GetComponent<UtalRigidbody>().velocity = new Vector3(0, -k * deltaF, 0);

        //Debug.Log((-k * deltaF) + " " + deltaF);


        //if(deltaD > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, initScale - deltaScale, transform.localScale.z);
        }
        /*else
        {
            transform.localScale = new Vector3(transform.localScale.x, initScale - deltaScale, transform.localScale.z);
        }*/
    }
}
