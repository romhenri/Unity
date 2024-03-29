using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    CharacterMovement2D playerMovement;
    SpriteRenderer spriteRenderer;
    PlayerInput playerInput;

    public Sprite defaultSprite;
    public Sprite crounchedSprite;

    void Start()
    {
        playerMovement = GetComponent<CharacterMovement2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        Vector2 movementInput = playerInput.GetMovementInput();
        playerMovement.ProcessMovementInput(new Vector2(movementInput.x, 0));

        if (movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        } else if (movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        // Jump
        if (playerInput.isJumpButtonDown())
        {
            playerMovement.Jump();
        }
        if (playerInput.isJumpButtonHeld() == false)
        {
            playerMovement.UpdateJumpAbort();
        }

        // Crouch
        if (playerInput.isCrouchButtonDown())
        {
            playerMovement.Crouch();
            spriteRenderer.sprite = crounchedSprite;
        }
        if (playerInput.isCrouchButtonDown() == false)
        {
            playerMovement.UnCrouch();
            spriteRenderer.sprite = defaultSprite;
        }

        if (transform.position.y < -8f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}
