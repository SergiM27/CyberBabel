using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentUpgrades : MonoBehaviour
{
    public TextMeshProUGUI healthLevel;
    public TextMeshProUGUI movementSpeedLevel;
    public TextMeshProUGUI attackLevel;
    public TextMeshProUGUI cadencyLevel;
    public TextMeshProUGUI bulletSizeLevel;



    private void OnEnable()
    {
        healthLevel.text = GameManager.currentPlayerMaxHPLevel.ToString();
        movementSpeedLevel.text = GameManager.currentPlayerMovementSpeed.ToString();
        attackLevel.text = GameManager.currentPlayerAttackLevel.ToString();
        cadencyLevel.text = GameManager.currentPlayerCadency.ToString();
        bulletSizeLevel.text = GameManager.currentPlayerBulletSize.ToString();
    }
}
