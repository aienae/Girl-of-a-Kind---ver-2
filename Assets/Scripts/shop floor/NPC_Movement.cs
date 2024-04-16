using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    
    public float moveSpeed = 5f; // Adjust this to control the movement speed
    private Vector3 targetPosition;
    private Animator animator;


    void Start()
    {
        // Set the target position (where you want the character to move)
        targetPosition = new Vector3(-0.6f, -1.61f, 2.9f); // Example target position, adjust as needed
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        //var velocity = Vector3.forward * Input.GetAxis("Vertical") * moveSpeed;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
       
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            animator.SetFloat("Speed", 0);
            // Character has reached the target position, you can add further actions here
        }
        else
        {
            animator.SetFloat("Speed", 1);

        }
    }
}
