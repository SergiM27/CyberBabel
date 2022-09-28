using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UpgradeList : MonoBehaviour
{
    // Start is called before the first frame update

    public Upgrade[] upgradesLevel1;
    public Upgrade[] upgradesLevel2;
    public Upgrade[] upgradesLevel3;
    public int upgrade1int;
    public int upgrade2int;
    public Upgrade upgrade1;
    public Upgrade upgrade2;
    public Upgrade upgrade3;

    //UpgradesCanvas
    public TextMeshProUGUI level_1;
    public TextMeshProUGUI descriptionPlayer_1;
    public TextMeshProUGUI descriptionEnemy_1;
    public TextMeshProUGUI level_2;
    public TextMeshProUGUI descriptionPlayer_2;
    public TextMeshProUGUI descriptionEnemy_2;
    public TextMeshProUGUI level_3;
    public TextMeshProUGUI descriptionPlayer_3;
    public TextMeshProUGUI descriptionEnemy_3;

    public GameObject upgradeCanvas;
    public GameObject gameCanvas;
    public EventSystem eventSystem;
    public PlayerController player;



    void Start()
    {
        upgrade1int = 0;
        upgrade2int = 0;
        if (GameManager.currentFloor == 0)
        {
            eventSystem.SetSelectedGameObject(null);
            upgradeCanvas.gameObject.SetActive(false);
            player.isUpgrading = false;
            StartWaves();
        }
        else
        {
            player.isUpgrading = true;
            gameCanvas.SetActive(false);
            if (GameManager.currentFloor == 1)
            {
                SelectRandomLevel1Upgrades(3);
            }
            else if (GameManager.currentFloor == 2)
            {
                SelectRandomUpgrades(3);
            }
            else if (GameManager.currentFloor == 3)
            {
                SelectRandomUpgrades(3);
            }
            else if (GameManager.currentFloor == 4)
            {
                SelectRandomUpgrades(3);
            }
            else if (GameManager.currentFloor == 5)
            {
                SelectRandomUpgrades(3);
            }
            else if (GameManager.currentFloor == 6)
            {
                SelectRandomUpgrades(3);
            }
            else if (GameManager.currentFloor == 7)
            {
                SelectRandomUpgrades(3);
            }
            else if (GameManager.currentFloor == 8)
            {
                SelectRandomUpgrades(3);
            }
            else if (GameManager.currentFloor == 9)
            {
                SelectRandomUpgrades(3);
            }
            else if (GameManager.currentFloor == 10)
            {
                SelectRandomUpgrades(3);
            }
        }
    }

    void SetUpgrade(int upgradeNumber)
    {
        if (upgradeNumber == 1)
        {
            level_1.text = upgrade1.levelOfUpgrade.ToString();
            descriptionPlayer_1.text = upgrade1.playerText.ToString();
            descriptionEnemy_1.text = upgrade1.enemyText.ToString();
        }
        else if (upgradeNumber == 2)
        {
            level_2.text = upgrade2.levelOfUpgrade.ToString();
            descriptionPlayer_2.text = upgrade2.playerText.ToString();
            descriptionEnemy_2.text = upgrade2.enemyText.ToString();
        }
        else
        {
            level_3.text = upgrade3.levelOfUpgrade.ToString();
            descriptionPlayer_3.text = upgrade3.playerText.ToString();
            descriptionEnemy_3.text = upgrade3.enemyText.ToString();
        }
    }

    public void Upgrade1Selected()
    {
        UpdatePlayerLevel(upgrade1.variableToChangePlayer1, upgrade1.variableToChangePlayer2, upgrade1.levelsToUpgradePlayer1, upgrade1.levelsToUpgradePlayer2);
        UpdateEnemyLevel(upgrade1.variableToChangeEnemy1, upgrade1.variableToChangeEnemy2, upgrade1.levelsToUpgradeEnemy1, upgrade1.levelsToUpgradeEnemy2);
        eventSystem.SetSelectedGameObject(null);
        upgradeCanvas.gameObject.SetActive(false);
        player.isUpgrading = false;
        StartWaves();
        AudioManager.instance.PlaySFX("Upgrade");
    }

    public void Upgrade2Selected()
    {
        UpdatePlayerLevel(upgrade2.variableToChangePlayer1, upgrade2.variableToChangePlayer2, upgrade2.levelsToUpgradePlayer1, upgrade2.levelsToUpgradePlayer2);
        UpdateEnemyLevel(upgrade2.variableToChangeEnemy1, upgrade2.variableToChangeEnemy2, upgrade2.levelsToUpgradeEnemy1, upgrade2.levelsToUpgradeEnemy2);
        eventSystem.SetSelectedGameObject(null);
        upgradeCanvas.gameObject.SetActive(false);
        player.isUpgrading = false;
        AudioManager.instance.PlaySFX("Upgrade");
        StartWaves();
    }
    public void Upgrade3Selected()
    {
        UpdatePlayerLevel(upgrade3.variableToChangePlayer1, upgrade3.variableToChangePlayer2, upgrade3.levelsToUpgradePlayer1, upgrade3.levelsToUpgradePlayer2);
        UpdateEnemyLevel(upgrade3.variableToChangeEnemy1, upgrade3.variableToChangeEnemy2, upgrade3.levelsToUpgradeEnemy1, upgrade3.levelsToUpgradeEnemy2);
        eventSystem.SetSelectedGameObject(null);
        upgradeCanvas.gameObject.SetActive(false);
        player.isUpgrading = false;
        AudioManager.instance.PlaySFX("Upgrade");
        StartWaves();
    }

    public void StartWaves()
    {
        gameCanvas.SetActive(true);
        GameObject.FindObjectOfType<Spawner>().StartCoroutine("StartWave");
    }

    public void UpdatePlayerLevel(int variableToChange1, int variableToChange2, int amount1, int amount2)
    {
        if (variableToChange1 == 1)
        {
            GameManager.currentPlayerMaxHPLevel += amount1;
            GameManager.maxHealth += (amount1 * 10);
            GameManager.playerHealth += (amount1 * 10);
        }
        else if (variableToChange1 == 2)
        {
            GameManager.currentPlayerAttackLevel += amount1;
        }
        else if (variableToChange1 == 3)
        {
            GameManager.currentPlayerMovementSpeed += amount1;
        }
        else if (variableToChange1 == 4)
        {
            GameManager.currentPlayerCadency += amount1;
        }
        else if (variableToChange1 == 5)
        {
            GameManager.currentPlayerBulletSize += amount1;
        }
        if (variableToChange2 == 1)
        {
            GameManager.currentPlayerMaxHPLevel += amount2;
            GameManager.maxHealth += (amount2 * 10);
            GameManager.playerHealth += (amount2 * 10);
        }
        else if (variableToChange2 == 2)
        {
            GameManager.currentPlayerAttackLevel += amount2;
        }
        else if (variableToChange2 == 3)
        {
            GameManager.currentPlayerMovementSpeed += amount2;
        }
        else if (variableToChange2 == 4)
        {
            GameManager.currentPlayerCadency += amount2;
        }
        else if (variableToChange2 == 5)
        {
            GameManager.currentPlayerBulletSize += amount2;
        }
        player.SetPlayerLevels();
    }

    public void UpdateEnemyLevel(int variableToChange1, int variableToChange2, int amount1, int amount2)
    {
        if (variableToChange1 == 1)
        {
            GameManager.currentEnemyMaxHPLevel += amount1;
        }
        else if (variableToChange1 == 2)
        {
            GameManager.currentEnemyAttackLevel += amount1;
        }
        else if (variableToChange1 == 3)
        {
            GameManager.currentEnemyMovementSpeed += amount1;
        }
        else if (variableToChange1 == 4)
        {
            GameManager.currentEnemyCadency += amount1;
        }
        if (variableToChange2 == 1)
        {
            GameManager.currentEnemyMaxHPLevel += amount2;
        }
        else if (variableToChange2 == 2)
        {
            GameManager.currentEnemyAttackLevel += amount2;
        }
        else if (variableToChange2 == 3)
        {
            GameManager.currentEnemyMovementSpeed += amount2;
        }
        else if (variableToChange2 == 4)
        {
            GameManager.currentEnemyCadency += amount2;
        }
    }

    public void SelectRandomLevel1Upgrades(int numberOfUpgrades)
    {
        for (int i = 0; i < numberOfUpgrades; i++)
        {
            int r = Random.Range(0, upgradesLevel1.Length);
            if (i == 0)
            {
                upgrade1 = upgradesLevel1[r];
                upgrade1int = r;
                SetUpgrade(1);
            }
            else if (i == 1)
            {
                if (r != upgrade1int)
                {
                    upgrade2 = upgradesLevel1[r];
                    upgrade2int = r;
                    SetUpgrade(2);
                }
                else
                {
                    i--;
                }
            }
            else if (i == 2)
            {
                if (r != upgrade1int && r != upgrade2int)
                {
                    upgrade3 = upgradesLevel1[r];
                    SetUpgrade(3);
                }
                else
                {
                    i--;
                }
            }
        }
    }

    public void SelectRandomLevel2Upgrades(int numberOfUpgrades)
    {
        for (int i = 0; i < numberOfUpgrades; i++)
        {
            int r = Random.Range(0, upgradesLevel2.Length);
            if (i == 0)
            {
                upgrade1 = upgradesLevel2[r];
                upgrade1int = r;
                SetUpgrade(1);
            }
            else if (i == 1)
            {
                if (r != upgrade1int)
                {
                    upgrade2 = upgradesLevel2[r];
                    upgrade2int = r;
                    SetUpgrade(2);
                }
                else
                {
                    i--;
                }
            }
            else if (i == 2)
            {
                if (r != upgrade1int && r != upgrade2int)
                {
                    upgrade3 = upgradesLevel2[r];
                    SetUpgrade(3);
                }
                else
                {
                    i--;
                }
            }
        }
    }

    public void SelectRandomLevel3Upgrades(int numberOfUpgrades)
    {
        for (int i = 0; i < numberOfUpgrades; i++)
        {
            int r = Random.Range(0, upgradesLevel3.Length);
            if (i == 0)
            {
                upgrade1 = upgradesLevel3[r];
                upgrade1int = r;
                SetUpgrade(1);
            }
            else if (i == 1)
            {
                if (r != upgrade1int)
                {
                    upgrade2 = upgradesLevel3[r];
                    upgrade2int = r;
                    SetUpgrade(2);
                }
                else
                {
                    i--;
                }
            }
            else if (i == 2)
            {
                if (r != upgrade1int && r != upgrade2int)
                {
                    upgrade3 = upgradesLevel3[r];
                    SetUpgrade(3);
                }
                else
                {
                    i--;
                }
            }
        }
    }

    public void SelectRandomUpgrades(int numberOfUpgrades)
    {
        for (int i = 0; i < numberOfUpgrades; i++)
        {
            if (i == 0)
            {
                int r = Random.Range(0, upgradesLevel1.Length);
                upgrade1 = upgradesLevel1[r];
                upgrade1int = r;
                SetUpgrade(1);
            }
            else if (i == 1)
            {
                int r = Random.Range(0, upgradesLevel2.Length);
                upgrade2 = upgradesLevel2[r];
                upgrade2int = r;
                SetUpgrade(2);
            }
            else if (i == 2)
            {
                int r = Random.Range(0, upgradesLevel3.Length);
                upgrade3 = upgradesLevel3[r];
                SetUpgrade(3);
            }
        }
    }
}
