using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public LaunchScript launchScript;
    public WindBehavior windBehavior;

    public TextMeshProUGUI vector;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI mass;
    public TextMeshProUGUI wind;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vector.text = "Vector de lanzamiento: (" + launchScript.getVSpeed().x + ", " + launchScript.getVSpeed().y + ", " + launchScript.getVSpeed().z + ")";
        speed.text = "Fuerza de lanzamiento: " + launchScript.speed.ToString("0");
        mass.text = "Masa del projectil: " + launchScript.mass.ToString("0");
        wind.text = "Velocidad del viento: " + windBehavior.windForceMagnitude.ToString("0"); ;
    }
}
