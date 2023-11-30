using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] private LaunchScript launchScript;
    [SerializeField] private WindBehavior windBehavior;
    [SerializeField] private PointManager pointManager;

    [SerializeField] private TextMeshProUGUI vector;
    [SerializeField] private TextMeshProUGUI speed;
    [SerializeField] private TextMeshProUGUI mass;
    [SerializeField] private TextMeshProUGUI wind;
    [SerializeField] private TextMeshProUGUI points;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vector.text = "Vector de lanzamiento: (" + launchScript.getVSpeed().x.ToString("0.00") + ", " + launchScript.getVSpeed().y.ToString("0.00") + ", " + launchScript.getVSpeed().z.ToString("0.00") + ")";
        speed.text = "Fuerza de lanzamiento: " + launchScript.speed.ToString("0");
        mass.text = "Masa del projectil: " + launchScript.mass.ToString("0");
        wind.text = "Velocidad del viento: " + windBehavior.windForceMagnitude.ToString("0"); ;
        points.text = "Puntaje: " + pointManager.getPoints().ToString("0");
    }
}
