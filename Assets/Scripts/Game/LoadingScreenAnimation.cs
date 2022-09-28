using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenAnimation : MonoBehaviour
{

    public Material[] panelMaterials;
    public int i;
    public LevelLoader levelLoader;
    private int rounds;
    private bool isLoop;

    // Start is called before the first frame update
    void Start()
    {
        isLoop = true;
        i = 0;
        rounds = 0;
        StartCoroutine("ChangePanel");
    }

    IEnumerator ChangePanel()
    {
        if (isLoop)
        {
            this.gameObject.GetComponent<Renderer>().material = panelMaterials[i];
            yield return new WaitForSeconds(0.08f);
            if (i >= panelMaterials.Length - 1)
            {
                rounds++;
                if (rounds >= 3)
                {
                    isLoop = false;
                    levelLoader.NextFloorLoadingScreen();
                }
                else
                {
                    i = 0;
                }
            }
            i++;
            StartCoroutine(ChangePanel());
        }
    }
}
