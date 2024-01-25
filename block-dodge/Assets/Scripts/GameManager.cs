using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;

    public static int score = 0;
    public static TextMesh scoreText;

    bool gameStarted = false;
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        // Start Game when the player clicks
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartSpawning();
            gameStarted = true;
        }
    }

    private void StartSpawning() {
        // Calling a function every x seconds
        InvokeRepeating("SpawnBlock", 0.1f, spawnRate);
        // The parameters are: 
        // 1. The name of the function to call
        // 2. The time to wait before calling the function for the first time
        // 3. The time to wait between each call
    }

    private void SpawnBlock() 
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(block, spawnPos, Quaternion.identity);
        // The parameters are:
        // 1. The object to instantiate
        // 2. The position to instantiate the object at
        // 3. The rotation of the object
    }
    public static void increaseScore()
    {
        score = (score + 1);
        scoreText.text = "Score: " + score;
    }
}