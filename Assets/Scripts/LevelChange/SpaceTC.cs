using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTC : MonoBehaviour
{

    public LevelLoader levelLoader;
    private bool isPressed;


    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed == false)
        {
            if (Input.GetAxisRaw("Fire1") > 0)
            {
                levelLoader.LoadLevel(2);
                AudioManager.instance.PlaySFX("ButtonPress");
                isPressed = true;
            }
        }
    }
}
