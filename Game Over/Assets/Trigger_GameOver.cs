using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //Aggiungere libreria

public class Trigger_GameOver : MonoBehaviour
{
    private void OnTriggerEnter(Collider otherCollider) {
        if (otherCollider.gameObject.tag == "kind") {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
