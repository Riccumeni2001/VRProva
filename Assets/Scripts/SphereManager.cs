using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SphereScript : MonoBehaviour{

    [SerializeField]
    public GameObject audioManager;

    void OnTriggerEnter(Collider other){
        if(other.tag == "Terrain"){
            audioManager.GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody>().useGravity = false;
            transform.position = new Vector3(0.2438f, 1.017f, 0.382f);
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

    public void setIsGravity(){
        GetComponent<Rigidbody>().useGravity = true;
    }

    public void setIsNotGravity(){
        GetComponent<Rigidbody>().useGravity = false;
    }
    
}
