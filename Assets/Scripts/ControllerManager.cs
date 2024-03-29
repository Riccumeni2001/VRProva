using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerManager : MonoBehaviour
{
    [SerializeField]
    public GameObject leftController, rightController;

    public void SendHapticImpulse(){
        rightController.GetComponent<XRDirectInteractor>().SendHapticImpulse(1.0f, 5f);
    }

    public void StopHapticImpulse(){
        // rightController.GetComponent<XRDirectInteractor>().Impulse;
    }
}
