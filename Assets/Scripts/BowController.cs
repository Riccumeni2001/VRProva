using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class BowController : MonoBehaviour
{
    public GameObject leftController;
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = leftController.transform.position;
        transform.rotation = leftController.transform.rotation;
    }
}
