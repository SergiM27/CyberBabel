using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{

    public Material black;
    public Material green;
    public LevelLoader levelLoader;

    private void OnMouseEnter()
    {
        this.gameObject.GetComponent<Renderer>().material = green;
    }

    private void OnMouseExit()
    {
        this.gameObject.GetComponent<Renderer>().material = black;
    }

    private void OnMouseDown()
    {
        if (this.gameObject.name == "StartText")
        {
            levelLoader.PlayPress();
        }
        else if (this.gameObject.name == "ExitText")
        {
            levelLoader.QuitGame();
        }
        AudioManager.instance.PlaySFX("ButtonPress");
    }
}
