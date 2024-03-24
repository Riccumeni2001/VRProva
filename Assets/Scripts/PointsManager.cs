using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PointsManager : MonoBehaviour{
    int points = 0;

    public static event Action<int> onPointsAdded;

    // Start is called before the first frame update
    void Start()
    {
        TargetController.onTargetTrigger += addPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addPoints(VelocityCase difficulty){

        switch(difficulty){
            case VelocityCase.BASE:
            points++;
            break;
            case VelocityCase.MEDIUM:
            points+=3;
            break;
            case VelocityCase.DIFFICULT:
            points+=5;
            break;
        }

        onPointsAdded?.Invoke(points);
    }
}
