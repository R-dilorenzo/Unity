using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Monete : MonoBehaviour
{
    /*SCRIPT*/
    //inserire su oggetto che deve distruggere 
    //gli oggetti che devono essere distrutti devono avere il tag "coin_bonus"-->
    //-->nell'inspector sotto il nome del gameobject aggiungere e cambiare il tag 
    /*-------*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "coin_bonus"){
            Destroy(col.gameObject);
        }
    }
}
