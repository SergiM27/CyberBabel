using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayPress()
    {
        StartCoroutine(LoadLevel_NormalTransition(1));
        RestartVariables();
        //AudioManager.instance.PlaySFX("Tear");
    }

    public void LoadLevel(int level)
    {
        StartCoroutine(LoadLevel_NormalTransition(level));
        //AudioManager.instance.PlaySFX("Tear");
    }

    public void BackToMenuPress()
    {
        StartCoroutine(LoadLevel_LateTransition(0));
        AudioManager.instance.PlaySFX("ButtonPress");
        AudioManager.instance.sfx2.clip = null;
        AudioManager.instance.sfx3.clip = null;
        AudioManager.instance.sfx4.clip = null;
        AudioManager.instance.sfx5.clip = null;
        AudioManager.instance.sfx6.clip = null;
        AudioManager.instance.sfx7.clip = null;
    }

    public void BackToMenuGameOver()
    {
        StartCoroutine(LoadLevel_LateTransition(0));
        AudioManager.instance.sfx2.clip = null;
        AudioManager.instance.sfx3.clip = null;
        AudioManager.instance.sfx4.clip = null;
        AudioManager.instance.sfx5.clip = null;
        AudioManager.instance.sfx6.clip = null;
        AudioManager.instance.sfx7.clip = null;
    }

    public void BackToMenuPressInGame()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadLevel_NormalTransition(0));
        AudioManager.instance.PlaySFX("ButtonPress");
        AudioManager.instance.sfx2.clip = null;
        AudioManager.instance.sfx3.clip = null;
        AudioManager.instance.sfx4.clip = null;
        AudioManager.instance.sfx5.clip = null;
        AudioManager.instance.sfx6.clip = null;
        AudioManager.instance.sfx7.clip = null;
    }

    public void GameOver()
    {
        StartCoroutine(LoadLevel_NormalTransition(2));
    }

    public void NextFloorLoading()
    {
        StartCoroutine(LoadLevel_NormalTransition(3));
    }

    public void NextFloorLoadingScreen()
    {
        StartCoroutine(LoadLevel_FloorTransition(2));
    }

    public void RestartVariables()
    {
        GameManager.currentFloor = 0;
        GameManager.floorList= 0;
        GameManager.currentWave = 0;
        GameManager.currentFloorNumberOfWaves = FindObjectOfType<FloorController>().NumberOfEnemiesThisFloorPerWave();
        GameManager.maxHealth = 100;
        GameManager.playerHealth = 100;
        GameManager.currentPlayerAttackLevel = 0;
        GameManager.currentPlayerBulletSize = 0;
        GameManager.currentPlayerCadency = 0;
        GameManager.currentPlayerMaxHPLevel = 0;
        GameManager.currentPlayerMovementSpeed = 0;
        GameManager.currentEnemyAttackLevel = 0;
        GameManager.currentEnemyCadency = 0;
        GameManager.currentEnemyMaxHPLevel = 0;
        GameManager.currentEnemyMovementSpeed = 0;

    }

    IEnumerator LoadLevel_NormalTransition(int levelIndex)
    {
        transition.SetBool("Start",true);

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadLevel_FloorTransition(int levelIndex)
    {
        transition.SetBool("Start", true);

        yield return new WaitForSeconds(transitionTime);
        GameManager.currentFloor++;
        if (GameManager.currentFloor == 11)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            GameManager.floorList++;
            GameManager.currentWave = 0;
            GameManager.currentFloorNumberOfWaves = FindObjectOfType<FloorController>().numberOfWaves[GameManager.floorList];
            SceneManager.LoadScene(levelIndex);
        }
    }

    IEnumerator LoadLevel_LateTransition(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime * 1.5f);

        transition.SetBool("Start", true);

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
