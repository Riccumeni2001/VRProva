using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowZoneController : MonoBehaviour
{

    public static bool isInZone = true;

    void OnTriggerEnter(Collider other){
        if(other.tag == "arrow"){
            isInZone = true;
            Debug.Log("Is in zone");
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "arrow"){
            isInZone = false;
            Debug.Log("Is not in zone");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
