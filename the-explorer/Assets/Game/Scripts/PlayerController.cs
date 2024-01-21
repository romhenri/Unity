using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    CharacterMovement2D playerMovement;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        playerMovement = GetComponent<CharacterMovement2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        playerMovement.ProcessMovementInput(new Vector2(horizontalInput, 0));

        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        } else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
