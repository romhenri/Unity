using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pop : MonoBehaviour
{
    // to animator
    public Animator animator;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key was pressed.");
            // Restart the animator
            //animator.Play("corn-growing");
            //animator.SetBool("Collect", true);
            animator.SetTrigger("Get");
        }
    }
}