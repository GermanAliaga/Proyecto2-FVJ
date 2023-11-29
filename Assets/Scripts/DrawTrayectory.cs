using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrayectory : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int N = 120;
    public int framesPerSecond = 20;
    public UtalRigidbody utalRBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] futurePositions = new Vector3[N];
        Vector3[] futureVelocity = new Vector3[N];
        futurePositions[0] = transform.position;
        futureVelocity[0] = utalRBody.velocity;
        for(int i=1; i < N; i++)
        {
            futurePositions[i] = futurePositions[i - 1] + futureVelocity[i-1] * (1f / framesPerSecond);
            Vector3 acceleration = UtalPhysicEngine.StaticGravity;
            futureVelocity[i] = futureVelocity[i - 1] + acceleration * (1f / framesPerSecond);
        }
        //You must set the amount of positions of the linerenderer in Unity before using this.
        lineRenderer.SetPositions(futurePositions);        
    }
}
