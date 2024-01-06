using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static int score = 0;

    void Start()
    {
    }

    void Update()
    {
    }
    public static void Restart()
    {
        score = 0;
        //SceneManager.LoadScene("Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
