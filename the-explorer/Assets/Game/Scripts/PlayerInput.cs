using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInput : MonoBehaviour
{
    private struct InputConstants
    {
        public const string HORIZONTAL = "Horizontal";
        public const string VERTICAL = "Vertical";
        public const string JUMP = "Jump";
        public const string CROUCH = "Crouch";
    }
    public Vector2 GetMovementInput()
    {
        // Input Telado
        float horizontalInput = Input.GetAxisRaw(InputConstants.HORIZONTAL);

        if (horizontalInput == 0.0f)
        {
            // Input Joystick
            horizontalInput = CrossPlatformInputManager.GetAxisRaw(InputConstants.HORIZONTAL);
        }
        return new Vector2(horizontalInput, 0);
    }

    public bool isJumpButtonDown()
    {
        bool isKeyDownButtonDown = Input.GetKeyDown(KeyCode.Space);
        bool isMobileButtonDown = CrossPlatformInputManager.GetButtonDown(InputConstants.JUMP);
        return isKeyDownButtonDown || isMobileButtonDown;
    }

    public bool isJumpButtonHeld()
    {
        bool isKeyDownButtonHeld = Input.GetKey(KeyCode.Space);
        bool isMobileButtonHeld = CrossPlatformInputManager.GetButton(InputConstants.JUMP);
        return isKeyDownButtonHeld || isMobileButtonHeld;
    }

    public bool isCrouchButtonDown()
    {
        bool isKeyDownButtonDown = Input.GetKey(KeyCode.S);
        bool isJoystickDown = CrossPlatformInputManager.GetAxisRaw(InputConstants.VERTICAL) <= -0.5f;
        return isKeyDownButtonDown || isJoystickDown;
    }

    public bool isCrouchButtonUp()
    {
        bool isKeyDownButtonUp = Input.GetKey(KeyCode.S) == false;
        bool isJoystickToUp = CrossPlatformInputManager.GetAxisRaw(InputConstants.VERTICAL) > -0.5f;
        return isKeyDownButtonUp && isJoystickToUp;
    }
}
