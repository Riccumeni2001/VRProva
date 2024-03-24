using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsTextManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PointsManager.onPointsAdded += assignPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void assignPoints(int points){
        GetComponent<TextMeshProUGUI>().text = "Points: \n" + points;
    }
}
