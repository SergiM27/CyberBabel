using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewUpgrade", menuName ="Upgrades")]
public class Upgrade: ScriptableObject
{
    public int levelOfUpgrade;
    public string playerText;
    public string enemyText;
    public int variableToChangePlayer1;
    public int variableToChangePlayer2;
    public int variableToChangeEnemy1;
    public int variableToChangeEnemy2;
    public int levelsToUpgradePlayer1;
    public int levelsToUpgradePlayer2;
    public int levelsToUpgradeEnemy1;
    public int levelsToUpgradeEnemy2;

}
