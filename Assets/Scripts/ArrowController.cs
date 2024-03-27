using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArrowController : MonoBehaviour
{
    public GameObject bow;
    public GameObject rightHand;

    public GameObject arrowPivotPrefab;

    private GameObject arrowPivot;

    private bool isShoot = false; 

    // Start is called before the first frame update
    void Start()
    {
        arrowPivot = Instantiate(arrowPivotPrefab, bow.transform);

        arrowPivot.GetComponent<XRSimpleInteractable>().onSelectExited.AddListener(shoot);

        Debug.Log(arrowPivot);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isShoot){
            if(arrowPivot != null){
                if(arrowPivot.GetComponent<XRSimpleInteractable>().isSelected){
                    arrowPivot.transform.position = new Vector3(rightHand.transform.position.x , rightHand.transform.position.y, rightHand.transform.position.z);
                    arrowPivot.transform.rotation = rightHand.transform.rotation;
                }else{
                    arrowPivot.transform.position = new Vector3(bow.transform.position.x, bow.transform.position.y, bow.transform.position.z);
                    arrowPivot.transform.rotation = bow.transform.rotation;
                }
            }
        }
    }

    public void shoot(XRBaseInteractor interactor){

        if(ThrowZoneController.isInZone){
            isShoot = true;

            Transform child = arrowPivot.transform.Find("BowArrow").transform;
            
            Rigidbody rb = arrowPivot.transform.Find("BowArrow").GetComponent<Rigidbody>();

            rb.AddForce(child.forward * 200f);
            rb.useGravity = true;

            StartCoroutine(respawn());
        }
    }

    private IEnumerator respawn(){
        Destroy(arrowPivot, 3);

        yield return new WaitForSeconds(.5f);

        GameObject newArrowPivot = Instantiate(arrowPivotPrefab, bow.transform);
        arrowPivot = newArrowPivot;
        arrowPivot.GetComponent<XRSimpleInteractable>().onSelectExited.AddListener(shoot);

        isShoot = false;
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
