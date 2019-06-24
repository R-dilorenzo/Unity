using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private float gravity = 20f;

    private Vector3 moveDirection;

    private float hInput;
    private float vInput;
    private bool jumpKey;

    private CharacterController charController;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        GetInput();
        PlayerMove();
    }

    private void GetInput()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
    }

    private void PlayerMove()
    {
        moveDirection = new Vector3(hInput * runSpeed, moveDirection.y, vInput * runSpeed);

        if (charController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y += jumpForce;
            }
        }

        if (!charController.isGrounded)  // if player is in the air, apply gravity
        {
            moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        }

        charController.Move(moveDirection * Time.deltaTime);
    }
}
/*
public float jumpSpeed = 100.0f;
private bool onGround = false;

Rigidbody rb;
// Use this for initialization
void Start()
{
    rb = GetComponent<Rigidbody>();
}

float movementSpeed;
// Update is called once per frame
void Update()
{
    float amountToMove = movementSpeed * Time.deltaTime;
    Vector3 movement = (Input.GetAxis("Horizontal") * -Vector3.left * amountToMove) + (Input.GetAxis("Vertical") * Vector3.forward * amountToMove);
    rb.AddForce(movement, ForceMode.Force);

    if (Input.GetKeyDown("space"))
    {
        rb.AddForce(Vector3.up * jumpSpeed);
    }


}

void OnCollisionStay()
{
    onGround = true;
}
}
*/
