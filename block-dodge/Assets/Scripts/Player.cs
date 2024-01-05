using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// SceneManagement provdes methods:
// LoadScene(string sceneName | int sceneIndex)
// LoadSceneAsync(string sceneName | int sceneIndex)
// UnloadSceneAsync(string sceneName | int sceneIndex)
// GetActiveScene()
// GetSceneByName(string sceneName)
// GetSceneByBuildIndex(int sceneBuildIndex)
// GetSceneAt(int index)
// GetSceneByPath(string scenePath)
// GetSceneCount()
// GetSceneAt(int index)


public class Player : MonoBehaviour
{
    public float moveSpeed;
    // This is a reference to the Rigidbody component called "rb"
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Get the mouse position in world space
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (touchPos.x < 0)
            {
                rb.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                rb.AddForce(Vector2.right * moveSpeed);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Log collision object
        // Debug.Log(collision.gameObject.tag);

        // Not Working
        if (collision.gameObject.tag == "Block")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Game");
        }
    }
}