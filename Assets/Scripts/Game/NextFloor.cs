using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextFloor : MonoBehaviour
{
    public LevelLoader levelLoader;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            NextFloorLoad();
        }
    }

    private void NextFloorLoad()
    {
        levelLoader.NextFloorLoading();
    }
}
