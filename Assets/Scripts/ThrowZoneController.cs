
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.OpenXR.Input;

public class ThrowZoneController : MonoBehaviour
{

    public static bool isInZone = true;
    public UnityEvent sendHapticImpulse;

    void OnTriggerEnter(Collider other){
        if(other.tag == "arrow"){
            isInZone = true;
            sendHapticImpulse.Invoke();
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "arrow"){
            isInZone = false;
            
        }
    }
}
