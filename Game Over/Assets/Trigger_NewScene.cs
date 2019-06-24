using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //aggiungere Libreria

public class Trigger_NewScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "kind1")
        {
            SceneManager.LoadScene("NewScene");
        }
    }
}
