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
        //transform.rotation = Quaternion.Euler(new Vector3(-leftController.transform.eulerAngles.x * 0.7f - 90f, leftController.transform.eulerAngles.y - 180f, leftController.transform.eulerAngles.z - 90f));
        transform.rotation = leftController.transform.rotation;

        
    }
}
