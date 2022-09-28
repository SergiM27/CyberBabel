using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectControlMethod : MonoBehaviour
{

    public PlayerController player;
    public EventSystem eventSystem;
    public GameObject upgrade1;

    // Update is called once per frame
    void Update()
    {
        //Detect mouse input
        DetectMouse();
        //Detect controller input
        DetectController();
    }

    public void DetectMouse()
    {
        if (player.isUpgrading)
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
            {
                player.useController = false;
                Cursor.visible = true;
            }
            if (Input.GetAxisRaw("Mouse X") != 0.0f || Input.GetAxisRaw("Mouse Y") != 0.0f)
            {
                player.useController = false;
            }
        }
        else 
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
            {
                player.useController = false;
            }
            if (Input.GetAxisRaw("Mouse X") != 0.0f || Input.GetAxisRaw("Mouse Y") != 0.0f)
            {
                player.useController = false;
            }
        }
    }
    private void DetectController()
    {
        if (player.isUpgrading)
        {
            if (Input.GetAxisRaw("RHorizontal") != 0.0f || Input.GetAxisRaw("RVertical") != 0.0f)
            {
                player.useController = true;
                Cursor.visible = false;
                eventSystem.SetSelectedGameObject(upgrade1);
            }
            if (Input.GetAxisRaw("R2") != 0.0f
                || Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Joystick1Button2)
                || Input.GetKey(KeyCode.Joystick1Button3) || Input.GetKey(KeyCode.Joystick1Button4) || Input.GetKey(KeyCode.Joystick1Button5)
                || Input.GetKey(KeyCode.Joystick1Button6) || Input.GetKey(KeyCode.Joystick1Button7) || Input.GetKey(KeyCode.Joystick1Button8)
                || Input.GetKey(KeyCode.Joystick1Button9) || Input.GetKey(KeyCode.Joystick1Button10))
            {
                player.useController = true;
                Cursor.visible = false;
            }
        }
        else
        {
            if (Input.GetAxisRaw("RHorizontal") != 0.0f || Input.GetAxisRaw("RVertical") != 0.0f)
            {
                player.useController = true;
            }
            if (Input.GetAxisRaw("R2") != 0.0f
                || Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Joystick1Button2)
                || Input.GetKey(KeyCode.Joystick1Button3) || Input.GetKey(KeyCode.Joystick1Button4) || Input.GetKey(KeyCode.Joystick1Button5)
                || Input.GetKey(KeyCode.Joystick1Button6) || Input.GetKey(KeyCode.Joystick1Button7) || Input.GetKey(KeyCode.Joystick1Button8)
                || Input.GetKey(KeyCode.Joystick1Button9) || Input.GetKey(KeyCode.Joystick1Button10))
            {
                player.useController = true;
                Cursor.visible = false;
            }
        }

    }
}
