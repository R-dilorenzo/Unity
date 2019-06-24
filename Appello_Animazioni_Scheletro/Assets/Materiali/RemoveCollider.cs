using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCollider : MonoBehaviour
{
    private BoxCollider myBoxCollider;
    // Start is called before the first frame update
    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //alla pressione del tasto a il boxcollider viene disattivato
        if (Input.GetKeyDown(KeyCode.A))
        {
            myBoxCollider.enabled = false;
        }
        //al rilascio del tasto il boxcollider viene riattivato
        if (Input.GetKeyUp(KeyCode.A))
        {
            myBoxCollider.enabled = true;
        }
    }
}
