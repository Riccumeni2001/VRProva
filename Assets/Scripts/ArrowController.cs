using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArrowController : MonoBehaviour
{
    public GameObject bow;
    public GameObject rightHand;

    private bool isShoot = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isShoot){
            if(GetComponent<XRSimpleInteractable>().isSelected){
                transform.position = new Vector3(rightHand.transform.position.x , rightHand.transform.position.y, rightHand.transform.position.z);
                transform.rotation = rightHand.transform.rotation;
            }else{
                transform.position = new Vector3(bow.transform.position.x, bow.transform.position.y, bow.transform.position.z);
                transform.rotation = bow.transform.rotation;
            }
        }
    }

    public void shoot(){

        if(ThrowZoneController.isInZone){
            isShoot = true;

            Transform child = transform.Find("BowArrow").transform;
            
            Rigidbody rb = transform.Find("BowArrow").GetComponent<Rigidbody>();

            rb.AddForce(child.forward * 150f);

            StartCoroutine(wait());
        }
    }

    private IEnumerator wait(){
        yield return new WaitForSeconds(1.5f);

        Rigidbody rb = transform.Find("BowArrow").GetComponent<Rigidbody>();

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        isShoot = false;

        transform.Find("BowArrow").transform.position = transform.position;
        transform.Find("BowArrow").transform.rotation = transform.rotation;

    }
}
