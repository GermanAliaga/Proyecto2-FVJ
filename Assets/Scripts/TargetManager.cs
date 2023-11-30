using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : UtalGameObject
{

    [SerializeField] private PointManager pointManager; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void UtalOnCollisionEnter(UtalCollision collision)
    {
        Debug.Log("aaaaaaaaa");

        if(collision != null)
        {
            if(collision.other.tag == "Target")
            {
                pointManager.addPoints(collision.other.GetComponent<Node>().score);
            }
        }
    }
}
