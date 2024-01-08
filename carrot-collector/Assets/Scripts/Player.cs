using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FixedJoystick joystick;
    public float moveSpeed;

    float hInput, yInput;
    int score = 0;

    public GameObject winText;
    public int winScore = 6;

    void Start()
    {
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        hInput = joystick.Horizontal * moveSpeed;
        yInput = joystick.Vertical * moveSpeed;
        ;
        transform.Translate(hInput, yInput, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Carrot"))
        {
            score++;
            Destroy(collision.gameObject);

            if (score >= winScore)
            {
                winText.SetActive(true);
                Invoke("RestartScene", 3f);
            }
        }
    }
    void RestartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
