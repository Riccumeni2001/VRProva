using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PointsManager : MonoBehaviour{

    [SerializeField]
    public GameObject text;
    public GameObject ball;

    int points = 0;

    void OnTriggerExit(){
        points++;
        text.GetComponent<TextMeshProUGUI>().text = "Points: \n" + points;
        StartCoroutine(ExecuteAfterTime(1));
        ball.transform.position = new Vector3(0.422f, 1.150f, 0.414f);
    }

    IEnumerator ExecuteAfterTime(float time){
        yield return new WaitForSeconds(time);
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
