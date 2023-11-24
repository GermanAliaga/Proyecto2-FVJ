using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("destroy", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void destroy()
    {
        Destroy(this.gameObject);
    }
}
