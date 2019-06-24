using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    public float jumpforce;
    public float gravityscale=20.0f;
    private CharacterController controller;
    private Vector3 movecontroller;

    public bool isgrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movecontroller = new Vector3(Input.GetAxis("Horizontal"), movecontroller.y, Input.GetAxis("Vertical"));
        if (controller.isGrounded) {
        //if (isgrounded == true) {
                movecontroller.y = 0f;
            if (Input.GetKey(KeyCode.Space)){
                //if (Input.GetButton("Jump")) {
                movecontroller.y = jumpforce;
            }
            //Vector3 vector3 = (Physics.gravity * Time.deltaTime * gravityscale);
            //movecontroller.y = movecontroller.y + vector3;
            movecontroller.y -= gravityscale * Time.deltaTime;
            controller.Move(movecontroller);
        }

    }
    
    /*
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
    */
}
