using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // This script moves the character controller forward
    // and sideways based on the arrow keys.
    // It also jumps when pressing space.
    // Make sure to attach a character controller to the same game object.
    // It is recommended that you make only one call to Move or SimpleMove per frame.

    public class ExampleClass : MonoBehaviour
    {
        /*
        public float speed = 6.0f;
        public float gravity = -9.8f;

        private CharacterController _charController;
        */
        
        CharacterController characterController;

        public float speed = 6.0f;
        public float jumpSpeed = 8.0f;
        public float gravity = 20.0f;

        private Vector3 moveDirection = Vector3.zero;

        private bool isgrounded= true;
        
        void Start()
        {
            /*_charController = GetComponent<CharacterController>();*/
            characterController = GetComponent<CharacterController>();
        }

        void Update()
        {
            /*
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;
            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);

            movement.y = gravity;

            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _charController.Move(movement);
            */
            
            if (characterController.isGrounded == false)
            {
                // We are grounded, so recalculate
                // move direction directly from axes

                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                moveDirection *= speed;

                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                }
            }

            // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
            // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
            // as an acceleration (ms^-2)
            moveDirection.y -= gravity * Time.deltaTime;

            // Move the controller
            characterController.Move(moveDirection * Time.deltaTime);
        }
        
        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.name == "pavimento")
            {
              isgrounded = true;
            }
        }

        private void OnCollisionExit(Collision col)
        {
            if (col.gameObject.name == "pavimento")
            {
                isgrounded = false;
            }
        }

    }
}
