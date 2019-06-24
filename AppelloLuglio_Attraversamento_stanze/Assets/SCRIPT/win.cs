using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
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

        if (col.collider.tag == "Player")
        {
            //se il colore corrisponde a quello della palla viene tolto alla porta 
            //il box collieder e viene fatta passare la palla al livello successivo
            if (gameObject.GetComponent<Renderer>().material.color == col.gameObject.GetComponent<Renderer>().material.color)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                SceneManager.LoadScene("vittoria");
            }

        }
    }
}
