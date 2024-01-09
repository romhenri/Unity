using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallonController : MonoBehaviour
{
    public float upSpeed;

    public AudioSource audioSource;
    public SpriteRenderer texture;

    private void Start()
    {
    }

    // Difference beetwen awake and start:
    // Awake is called when the script instance is being loaded.
    // Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        texture = GetComponent<SpriteRenderer>();
    }

    // Difference between Update and FixedUpdate:
    // Update is called every frame, if the MonoBehaviour is enabled.
    // FixedUpdate is called every fixed framerate frame. This is independant of the frame rate of the application. FixedUpdate can be called multiple times per frame, if the frame rate is low and it may not be called between frames at all if the frame rate is high.

    void Update()
    {
        if(transform.position.y > 7f)
        {
            if (GetComponent<SpriteRenderer>().enabled)
            {
                Game.Restart();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(0, upSpeed, 0);
    }

    // Functions related mouse interactions:
    // OnMouseDown is called when the user has pressed the mouse button while over the GUIElement or Collider.
    // OnMouseDrag is called when the user has clicked on a GUIElement or Collider and is still holding down the mouse.
    // OnMouseEnter is called when the mouse entered the GUIElement or Collider.
    // OnMouseExit is called when the mouse is not any longer over the GUIElement or Collider.
    // OnMouseOver is called every frame while the mouse is over the GUIElement or Collider.
    // OnMouseUp is called when the user has released the mouse button.

    private void OnMouseDown()
    {
        if (texture.enabled)
        {
            pop();
        }
    }

    public void pop()
    {
        Game.score++;
        GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>().text = Game.score.ToString();
        audioSource.Play();
       
        texture.enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);

        // Delayed because of the sound need be played before the object is destroyed
        Invoke("destroy", 0.5f);
    }
    public void destroy()
    {
        Destroy(gameObject);
    }
}