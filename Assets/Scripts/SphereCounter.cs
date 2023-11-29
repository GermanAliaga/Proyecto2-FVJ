using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCounter : UtalGameObject
{
    public TMPro.TextMeshProUGUI scoreText;
    public int scoreCount;


    // Update is called once per frame
    void Update()
    {
        
    }

    public override void UtalOnCollisionEnter(UtalCollision collision)
    {
        scoreCount++;
        scoreText.text = "Score: " + scoreCount.ToString();
    }
}
