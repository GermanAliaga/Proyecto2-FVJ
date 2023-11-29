using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UtalCollider;

public class UtalGameObject : MonoBehaviour
{
    public UtalCollider myCollider;

    public MeshRenderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<UtalCollider>();
        myCollider.UtalOnCollisionEnterListener = UtalOnCollisionEnter;
        myCollider.UtalOnTriggerStayListener = UtalOnTriggerStay;
        myRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    public virtual void UtalOnCollisionEnter(UtalCollision collision)
    {
        myRenderer.material.color = Color.green;
    }
    public virtual void UtalOnTriggerStay(UtalCollider collider)
    {

    }
}
