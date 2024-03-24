using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils.Datums;
using UnityEngine;

public enum VelocityCase{
    BASE,
    MEDIUM,
    DIFFICULT
}

public class TargetController : MonoBehaviour
{
    public static event Action<VelocityCase> onTargetTrigger;
    private float time = 0f;
    private bool reverse = false;

    public float start = 0f;
    public float end = 0f;

    public VelocityCase difficulty = VelocityCase.BASE;

    private float velocity = 0.005f;

    void OnTriggerEnter(Collider other){
        if(other.tag == "arrow"){
            onTargetTrigger?.Invoke(difficulty);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        switch(difficulty){
            case VelocityCase.BASE:
            break;
            case VelocityCase.MEDIUM:
            velocity = 0.01f;
            break;
            case VelocityCase.DIFFICULT:
            velocity = 0.02f;
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, reverse ? transform.position.y - 0.01f : transform.position.y + 0.01f, transform.position.z), 50f * velocity);

        if(transform.position.y > end){
            reverse = true;
        }else if(transform.position.y < start){
            reverse = false;
        }

    }
}
