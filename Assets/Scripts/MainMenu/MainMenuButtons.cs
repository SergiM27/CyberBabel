using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitInGame : MonoBehaviour
{

    public GameObject exit;
    public Material green;
    public Material red;
    // Start is called before the first frame update

    public void Enter()
    {
        exit.gameObject.GetComponent<Renderer>().material = red;
    }
    public void Exit()
    {
        exit.gameObject.GetComponent<Renderer>().material = green;
    }
}
