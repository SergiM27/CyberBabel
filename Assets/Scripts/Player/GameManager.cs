using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int maxHealth;
    public static int playerHealth;
    public static int currentFloor;
    public static int floorList;
    public static int currentWave;
    public static int currentFloorNumberOfWaves;

    public static GameManager instance;

    //Player Levels
    public static int currentPlayerMaxHPLevel;
    public static int currentPlayerAttackLevel;
    public static int currentPlayerMovementSpeed;
    public static int currentPlayerCadency;
    public static int currentPlayerBulletSize;

    //Enemy Levels
    public static int currentEnemyMaxHPLevel;
    public static int currentEnemyAttackLevel;
    public static int currentEnemyMovementSpeed;
    public static int currentEnemyCadency;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        maxHealth = 100;
        playerHealth = 100;
        currentFloor = 0;
        currentWave = 0;
        floorList = 0;
        currentFloorNumberOfWaves = 0;
        currentPlayerMaxHPLevel = 0;
        currentPlayerAttackLevel = 0;
        currentPlayerMovementSpeed = 0;
        currentPlayerCadency = 0;
        currentPlayerBulletSize = 0;
        currentEnemyMaxHPLevel = 0;
        currentEnemyAttackLevel = 0;
        currentEnemyMovementSpeed = 0;
        currentEnemyCadency = 0;

    }
}
