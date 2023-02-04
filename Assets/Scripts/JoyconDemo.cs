﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyconDemo : MonoBehaviour {
	
    Joycon joyconCurrent;
    public bool isLeft;

    // Values made available via Unity
    public float[] stick;
    public Vector3 gyro;
    public Vector3 accel;
    public Quaternion orientation;
    private bool joyconExists;
    public static bool pausePressed = false;
    
    public Joycon getJoyCon() { return joyconCurrent; }
    void Start ()
    {
        gyro = new Vector3(0, 0, 0);
        accel = new Vector3(0, 0, 0);
        // get the public Joycon object attached to the JoyconManager in scene
        //j = JoyconManager.Instance.j[1];
        
        
        if (isLeft)
            joyconCurrent = JoyconManager.Instance.GetJoycon(JoyconManager.JoyconType.left);
        else if (!isLeft)
            joyconCurrent = JoyconManager.Instance.GetJoycon(JoyconManager.JoyconType.right);
    }


    private void FixedUpdate()
    {
        
        
    }
    // Update is called once per frame
    void Update () {
        // make sure the Joycon only gets checked if attached
        try { joyconExists = joyconCurrent != null; } catch { }
        if (joyconExists && joyconCurrent.state > Joycon.state_.ATTACHED)
        {
            if (((joyconCurrent.GetButtonUp(Joycon.Button.MINUS) && joyconCurrent.isLeft) || (joyconCurrent.GetButtonUp(Joycon.Button.PLUS) && !isLeft)) && pausePressed == false)
            {
                pausePressed = true;
                print("paused" + joyconCurrent.isLeft + ' ' + gameObject.name);
                gameManager.pauseMode();
            }
            if (joyconCurrent.GetButtonDown(Joycon.Button.DPAD_LEFT))
            {
                print("LEFT");
            }

            // GetButtonDown checks if a button has been pressed (not held)
            if (joyconCurrent.GetButtonDown(Joycon.Button.SHOULDER_2))
            {
				Debug.Log ("Shoulder button 2 pressed");
				// GetStick returns a 2-element vector with x/y joystick components
				Debug.Log(string.Format("Stick x: {0:N} Stick y: {1:N}",joyconCurrent.GetStick()[0],joyconCurrent.GetStick()[1]));
            
				// Joycon has no magnetometer, so it cannot accurately determine its yaw value. Joycon.Recenter allows the user to reset the yaw value.
				joyconCurrent.Recenter ();
			}
			// GetButtonDown checks if a button has been released
			if (joyconCurrent.GetButtonUp (Joycon.Button.SHOULDER_2))
			{
				Debug.Log ("Shoulder button 2 released");
			}
			// GetButtonDown checks if a button is currently down (pressed or held)
			if (joyconCurrent.GetButton (Joycon.Button.SHOULDER_2))
			{
				Debug.Log ("Shoulder button 2 held");
			}

            // GetButtonDown checks if a button has been pressed (not held)
            if (joyconCurrent.GetButtonDown(Joycon.Button.DPAD_UP))
            {
                Debug.Log("Shoulder button 2 pressed");
                // GetStick returns a 2-element vector with x/y joystick components
                Debug.Log(string.Format("Stick x: {0:N} Stick y: {1:N}", joyconCurrent.GetStick()[0], joyconCurrent.GetStick()[1]));

                // Joycon has no magnetometer, so it cannot accurately determine its yaw value. Joycon.Recenter allows the user to reset the yaw value.
                joyconCurrent.Recenter();
            }
            // GetButtonDown checks if a button has been released
            if (joyconCurrent.GetButtonUp(Joycon.Button.DPAD_UP))
            {
                Debug.Log("Shoulder button 2 released");
            }
            // GetButtonDown checks if a button is currently down (pressed or held)
            if (joyconCurrent.GetButton(Joycon.Button.DPAD_UP))
            {
                Debug.Log("Shoulder button 2 held");
            }

            if (joyconCurrent.GetButtonDown (Joycon.Button.DPAD_DOWN)) {
				Debug.Log ("Rumble");

				// Rumble for 200 milliseconds, with low frequency rumble at 160 Hz and high frequency rumble at 320 Hz. For more information check:
				// https://github.com/dekuNukem/Nintendo_Switch_Reverse_Engineering/blob/master/rumble_data_table.md

				joyconCurrent.SetRumble (160, 320, 0.6f, 200);

				// The last argument (time) in SetRumble is optional. Call it with three arguments to turn it on without telling it when to turn off.
                // (Useful for dynamically changing rumble values.)
				// Then call SetRumble(0,0,0) when you want to turn it off.
			}

            stick = joyconCurrent.GetStick();

            // Gyro values: x, y, z axis values (in radians per second)
            gyro = joyconCurrent.GetGyro();

            // Accel values:  x, y, z axis values (in Gs)
            accel = joyconCurrent.GetAccel();

            orientation = joyconCurrent.GetVector();
            gameObject.transform.rotation = orientation;
        }
    }
}