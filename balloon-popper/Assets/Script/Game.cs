using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject balloon;

    public static int score = 0;

    public Transform spawnPoint;
    public float spawnRate = 1;
    public float maxX = 2f;

    void Start()
    {
        StartSpawning();
    }

    void Update()
    {
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnBalloon", 0.1f, spawnRate);
    }

    private void SpawnBalloon()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(balloon, spawnPos, Quaternion.identity);
    }

    public static void Restart()
    {
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}