using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInput : MonoBehaviour
{
    public Vector2 GetMovementInput()
    {
        // Input Telado
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput == 0.0f)
        {
            // Input Joystick
            horizontalInput = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        }
        return new Vector2(horizontalInput, 0);
    }

    public bool isJumpButtonDown()
    {
        bool isKeyDownButtonDown = Input.GetKeyDown(KeyCode.Space);
        bool isMobileButtonDown = CrossPlatformInputManager.GetButtonDown("Jump");
        return isKeyDownButtonDown || isMobileButtonDown;
    }

    public bool isJumpButtonHeld()
    {
        bool isKeyDownButtonHeld = Input.GetKey(KeyCode.Space);
        bool isMobileButtonHeld = CrossPlatformInputManager.GetButton("Jump");
        return isKeyDownButtonHeld || isMobileButtonHeld;
    }

    public bool isCrouchButtonDown()
    {
        return Input.GetKey(KeyCode.LeftControl);
    }

    public bool isCrouchButtonUp()
    {
        return Input.GetKeyUp(KeyCode.LeftControl);
    }
}
