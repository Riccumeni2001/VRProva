using System;
using UnityEngine;

public class Points{
    public VelocityCase difficulty;
    public int basePoints;

    public int points;

    public Points(float distance, VelocityCase difficulty){
        int gainedPoints = calculatePoints(distance);

        int pointsMultiplier = getPointsMultiplierByDifficulty(difficulty);

        points = gainedPoints * pointsMultiplier;
    }
    
    private int calculatePoints(float distance){
        int value = 0;

        switch(distance){
            case > 1.1f:
            break;

            case > 1.09f:
            points = 1;
            break;

            case > 1.08f:
            value = 2;
            break;

            case > 1.07f:
            value = 3;
            break;

            case > 1.06f:
            value = 4;
            break;

            case > 1.05f:
            value = 5;
            break;

            case > 1.04f:
            value = 6;
            break;

            case > 1.03f:
            value = 7;
            break;

            case > 1.02f:
            value = 8;
            break;

            case > 1.01f:
            value = 9;
            break;

            case > 1.0f:
            value = 10;
            break;
        }

        return value;
    }

    private int getPointsMultiplierByDifficulty(VelocityCase difficulty){

        switch(difficulty){
            case VelocityCase.NONE:
            return 1;
            case VelocityCase.BASE:
            return 2;
            case VelocityCase.MEDIUM:
            return 3;
            case VelocityCase.DIFFICULT:
            return 4;
        }

        return 0;
    }
}

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

    void addPoints(float distance, VelocityCase difficulty){

        Points points = new Points(distance, difficulty);

        this.points += points.points;

        onPointsAdded?.Invoke(this.points);
    }
}
