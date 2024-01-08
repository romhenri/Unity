using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class Gun : MonoBehaviour
{
    // trmasform
    public FixedJoystick joystick;
    float hInput, yInput;
    public float force = 10f;

    void Start()
    {
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        hInput = joystick.Horizontal;
        yInput = joystick.Vertical;

        // Convert z,y of joystick to rotatation 0 to 360
        float angle = Mathf.Atan2(yInput, hInput) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}