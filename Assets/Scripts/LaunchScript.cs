using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LaunchScript : MonoBehaviour
{
    public UtalGameObject apuntado;

    public UtalGameObject proyectil;
    public UtalGameObject newP;

    public float speed;
    public float rotSpeed;

    public float mass;

    // Start is called before the first frame update
    void Start()
    {
        createNewP();
    }

    // Update is called once per frame
    void Update()
    {

        if (newP.GetComponent<UtalRigidbody>().isStatic)
        {
            newP.transform.position = apuntado.transform.position;
            newP.transform.rotation = apuntado.transform.rotation;
            newP.GetComponent<UtalRigidbody>().mass = mass;
            newP.GetComponent<UtalRigidbody>().velocity = (apuntado.transform.position - transform.position) * speed;
        }


        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (newP.GetComponent<UtalRigidbody>().isStatic)
            {
                Invoke("createNewP", 3);
            }

            newP.GetComponent<UtalRigidbody>().isStatic = false;
            newP.GetComponent<UtalRigidbody>().enabled = true;
            newP.GetComponent<MeshRenderer>().enabled = true;

            //Invoke("destroy", 3);
        }


        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
        {
            transform.Rotate(Vector3.forward, rotSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down, rotSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.back, rotSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime, Space.World);
        }



        if (Input.GetKey(KeyCode.J))
        {
            if(speed <= 100)
            {
                speed += .2f;
            }
            else { speed = 100; }
        }

        if (Input.GetKey(KeyCode.L))
        {
            if (speed >= 10)
            {
                speed -= .2f;
            }else { speed = 10; }
        }

        if (Input.GetKey(KeyCode.I))
        {
            if (mass <= 100)
            {
                mass += .2f;
            }
            else
            {
                mass = 100;
            }
        }

        if (Input.GetKey(KeyCode.K))
        {
            if (mass >= 10)
            {
                mass -= .2f;
            }
            else
            {
                mass = 10;
            }
        }
    }

    public Vector3 getVSpeed()
    {
        return (apuntado.transform.position - transform.position) * speed;
    }

    private void createNewP()
    {
        newP = Instantiate(proyectil, apuntado.transform.position, apuntado.transform.rotation);

        //newP.GetComponent<UtalSphereCollider>
        newP.GetComponent<UtalRigidbody>().isStatic = true;
        newP.GetComponent<UtalRigidbody>().enabled = false;
        newP.GetComponent<MeshRenderer>().enabled = false;
    }

    private void destroy()
    {
        Destroy(newP);
    }
}
