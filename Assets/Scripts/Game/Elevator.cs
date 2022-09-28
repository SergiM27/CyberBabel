using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Material elevatorOff;
    public Material elevatorOn;
    public ParticleSystem particles;
    public GameObject trigger;
    // Start is called before the first frame update
    void Start()
    {
        trigger.SetActive(false);
        particles.gameObject.SetActive(false);
        this.gameObject.GetComponent<Renderer>().material = elevatorOff;
    }

    public void NextFloor()
    {
        trigger.SetActive(true);
        particles.gameObject.SetActive(true);
        particles.Play();
        this.gameObject.GetComponent<Renderer>().material = elevatorOn;
    }
}
