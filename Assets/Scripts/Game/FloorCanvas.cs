using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloorCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Planta " + GameObject.FindObjectOfType<FloorController>().floors[GameManager.currentFloor].ToString();   
    }
}
