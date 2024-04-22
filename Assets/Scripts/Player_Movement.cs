using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    public float movementSpeed;
    private PlayerInput playerInput;
    private InputAction inputAction;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        inputAction = playerInput.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        Vector2 direction = inputAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, direction.y) * movementSpeed * Time.deltaTime;
    }
}
