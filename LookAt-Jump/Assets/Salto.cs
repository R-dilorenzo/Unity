using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    public float moveSpeed = 5;
    public float rotateSpeed = 180;
    public float jumpSpeed = 20;
    public float gravity = 9.8f;
    private CharacterController controller;
    private Vector3 currentMovement;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
        currentMovement = new Vector3(0, currentMovement.y, Input.GetAxis("Vertical") * moveSpeed);
        currentMovement = transform.rotation * currentMovement;

        if (!controller.isGrounded)
        {
            currentMovement -= new Vector3(0, gravity * Time.deltaTime, 0);
        }
        else { 
        currentMovement.y = -0.5f;
        }
        if (controller.isGrounded && Input.GetButtonDown("Jump")){
            currentMovement.y = jumpSpeed;
        }
        controller.Move(currentMovement * Time.deltaTime);
    }

}

