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
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "arrow"){
            isInZone = false;
        }
    }
}
