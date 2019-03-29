using System;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public static ControllerScript instance;

    public KeyCode squareButton = KeyCode.JoystickButton0;
    public KeyCode crossButton = KeyCode.JoystickButton1;
    public KeyCode circleButton = KeyCode.JoystickButton2;
    public KeyCode triangleButton = KeyCode.JoystickButton3;
    public KeyCode leftBumper = KeyCode.JoystickButton4;
    public KeyCode rightBumper = KeyCode.JoystickButton5;
    public KeyCode leftTrigger = KeyCode.JoystickButton6;
    public KeyCode rightTrigger = KeyCode.JoystickButton7;
    public KeyCode selectButton = KeyCode.JoystickButton8;
    public KeyCode startButton = KeyCode.JoystickButton9;
    public KeyCode L3 = KeyCode.JoystickButton10;
    public KeyCode R3 = KeyCode.JoystickButton11;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        //print("Left Thumbstick Horizontal: " + Input.GetAxis("Horizontal"));
        //print("Left Thumbstick Vertical: " + Input.GetAxis("Vertical"));
        //print("Right Thumbstick Horizontal: " + Input.GetAxis("Right Stick Horizontal"));
        //print("Right Thumbstick Vertical: " + Input.GetAxis("Right Stick Vertical"));
        //print("D-Pad Horizontal: " + Input.GetAxis("D-Pad Horizontal"));
       // print("D-Pad Vertical: " + Input.GetAxis("D-Pad Vertical"));

        if (Input.GetKeyDown(circleButton))
        {
            print("circle pressed");
        }
        if (Input.GetButtonDown("Fire1"))
        {
            print("square pressed");
        }
    }
}
