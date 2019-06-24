using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p : MonoBehaviour
{
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded == false)
        {
            Debug.Log("CharacterController is ground");
        }
    }
}
