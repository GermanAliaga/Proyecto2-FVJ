using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtalRigidbody : MonoBehaviour
{
    public Vector3 velocity;
    private Vector3 force;
    public bool dontUseGravity = false;
    public float mass = 1;
    public bool isStatic = false;

    public UtalCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<UtalCollider>();
        collider.utalRigidbody = this;
        UtalPhysicEngine.allRigidbodies.Add(this);
    }
    public void UtalOnCollisionEnter(UtalCollision collision)
    {
        UtalSphereCollider mySphereCollider = collider as UtalSphereCollider;
        UtalSphereCollider otherSphereCollider = collision.other as UtalSphereCollider;
        if(collision.other.utalRigidbody!= null && mySphereCollider!=null && otherSphereCollider != null)
        {
            
            
            Vector3 inNormal = collision.collisionPoint - collision.other.transform.position;
            Plane plane = new Plane(inNormal, collision.collisionPoint);
            Vector3 proyection = Vector3.ProjectOnPlane(velocity, inNormal);
            if (collision.other.utalRigidbody.isStatic)
            {
                velocity *= -1;
                velocity += proyection * 2;
            }
            else
            {
                Vector3 MyStaticVelocity = velocity * -1 + proyection * 2;
                collision.other.utalRigidbody.force += mass*velocity / 2;
                velocity = MyStaticVelocity / 2;
                float distance = otherSphereCollider.Radius + mySphereCollider.Radius;
                float dif = distance - Vector3.Distance(otherSphereCollider.transform.position, mySphereCollider.transform.position);
                if (dif > 0)
                {
                    Vector3 dirOtherToMe = transform.position - otherSphereCollider.transform.position;
                    dirOtherToMe.Normalize();
                    transform.position += dirOtherToMe * (dif / 2);
                    otherSphereCollider.transform.position -= dirOtherToMe * (dif / 2);
                }
            }
            
        }

    }
    public void AddForce(Vector3 newForce)
    {
        this.force += newForce;
    }
    public void ProcessForceAndVelocity()
    {
        if (isStatic)
        {
            force = Vector3.zero;
            return;
        }
        Vector3 lastVelocity = velocity;
        Vector3 acceleration = force / mass;
        //Debug.Log(acceleration);
        velocity += acceleration * Time.deltaTime;
        force = Vector3.zero;
        transform.position += (lastVelocity +velocity)*0.5f * Time.deltaTime;

    }

    // Update is called once per frame
        void Update()
    {
        
    }
}
