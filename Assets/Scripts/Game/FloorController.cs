using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public int[] floors;
    public int[] numberOfWaves;
    public int[] numberOfEnemiesPerWave;

    public void ChangeFloor()
    {
        GameManager.floorList++;
        GameManager.currentFloor = floors[GameManager.floorList];
        GameManager.currentWave = 0;
    }

    public int NumberOfEnemiesThisFloorPerWave()
    {
        return numberOfEnemiesPerWave[GameManager.floorList];
    }
}
