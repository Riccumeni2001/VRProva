using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PointsManager : MonoBehaviour{

    [SerializeField]
    public GameObject text;

    int points = 0;

    void OnTriggerExit(){
        points++;
        text.GetComponent<TextMeshProUGUI>().text = "Points: \n" + points;
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
