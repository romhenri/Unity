using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 GetMovementInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        return new Vector2(horizontalInput, 0);
    }

    public bool isJumpButtonDown()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public bool isJumpButtonHeld()
    {
        return Input.GetKey(KeyCode.Space);
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
