using System;
using Unity.VisualScripting;
using UnityEngine;

public enum VelocityCase{
    NONE,
    BASE,
    MEDIUM,
    DIFFICULT
}

public class TargetController : MonoBehaviour
{
    public static event Action<float, VelocityCase> onTargetTrigger;
    private bool reverse = false;
    public float start = 0f;
    public float end = 0f;

    public VelocityCase difficulty = VelocityCase.BASE;

    private float velocity = 0.005f;
    
    void OnCollisionEnter(Collision collision){
        if(collision.collider.tag == "arrow"){
            Debug.Log("Collisione");
            Rigidbody rbColl = collision.collider.GetComponent<Rigidbody>();
            rbColl.velocity = Vector3.zero;
            rbColl.angularVelocity = Vector3.zero;

            Destroy(rbColl);
            Destroy(collision.collider.GetComponent<BoxCollider>());

            int totalContacts = collision.GetContacts(collision.contacts);

            Vector3 collisionPoint = collision.GetContact(0).point;

            collisionPoint = transform.InverseTransformPoint(collisionPoint);

            // Da 1 a 1,1
            float distance = Vector3.Distance(new Vector3(0, 0, 0), collisionPoint);

            Debug.Log("distance: " + distance);
            
            collision.collider.transform.parent = transform;
            collision.collider.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            collision.collider.transform.localPosition = new Vector3(collisionPoint.x, -1, collisionPoint.z);
            collision.collider.transform.localScale = new Vector3(0.1f, 0.2f, 0.1f);
            collision.collider.GetComponent<Renderer>().material.color = Color.red;
            
            onTargetTrigger?.Invoke(distance, difficulty);
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
        if(difficulty != VelocityCase.NONE){
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, reverse ? transform.position.y - 0.01f : transform.position.y + 0.01f, transform.position.z), 50f * velocity);
        }

        if(transform.position.y > end){
            reverse = true;
        }else if(transform.position.y < start){
            reverse = false;
        }

    }
}
