using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloorMaterial : MonoBehaviour
{
    public Material[] floorMaterials;
    public GameObject sceneLight;
    public AudioClip[] musics;
    public GameObject controlGuide;
    public ParticleSystem particlesFloor;

    // Start is called before the first frame update
    void Start()
    {
        ChangeFloor();   
    }

    private void ChangeFloor()
    {
        if (GameManager.currentFloor == 0)
        {
            gameObject.GetComponent<Renderer>().material = floorMaterials[0];
            sceneLight.GetComponent<Light>().color = Color.white;
            particlesFloor.startColor = Color.white;
            controlGuide.gameObject.SetActive(true);
            ChangeMusic();
        }
        else if(GameManager.currentFloor == 1 || GameManager.currentFloor == 2)
        {
            gameObject.GetComponent<Renderer>().material = floorMaterials[1];
            sceneLight.GetComponent<Light>().color = new Color32(69,255,99,255);
            particlesFloor.startColor = new Color32(0, 255, 0, 255);
            ChangeMusic();
        }
        else if (GameManager.currentFloor == 3 || GameManager.currentFloor == 4)
        {
            gameObject.GetComponent<Renderer>().material = floorMaterials[2];
            sceneLight.GetComponent<Light>().color = new Color32(249, 255, 81, 255);
            particlesFloor.startColor = new Color32(255, 255, 0, 255);
            ChangeMusic();
        }
        else if (GameManager.currentFloor == 5 || GameManager.currentFloor == 6)
        {
            gameObject.GetComponent<Renderer>().material = floorMaterials[3];
            sceneLight.GetComponent<Light>().color = new Color32(243, 52, 211, 255);
            particlesFloor.startColor = new Color32(255, 0, 255, 255);
            ChangeMusic();
        }
        else if (GameManager.currentFloor == 7 || GameManager.currentFloor == 8)
        {
            gameObject.GetComponent<Renderer>().material = floorMaterials[4];
            sceneLight.GetComponent<Light>().color = new Color32(107, 152, 255, 255);
            particlesFloor.startColor = new Color32(0, 0, 255, 255);
            ChangeMusic();
        }
        else if (GameManager.currentFloor == 9)
        {
            gameObject.GetComponent<Renderer>().material = floorMaterials[5];
            sceneLight.GetComponent<Light>().color = new Color32(255, 153, 71, 255);
            particlesFloor.startColor = new Color32(255, 0, 0, 255);
            ChangeMusic();
        }
        else if (GameManager.currentFloor == 10)
        {
            gameObject.GetComponent<Renderer>().material = floorMaterials[6];
            sceneLight.GetComponent<Light>().color = new Color32(255, 45, 30, 255);
            particlesFloor.startColor = new Color32(255, 45, 30, 255);
            ChangeMusic();
        }
    }

    void ChangeMusic()
    {
        if (GameManager.currentFloor == 0)
        {
            AudioManager.instance.PlayMusic(musics[0].name);
        }
        else if (GameManager.currentFloor == 4)
        {
            AudioManager.instance.PlayMusic(musics[1].name);
        }
        else if (GameManager.currentFloor == 7)
        {
            AudioManager.instance.PlayMusic(musics[2].name);
        }
        else if (GameManager.currentFloor == 10)
        {
            AudioManager.instance.PlayMusic(musics[3].name);
        }
    }
}
