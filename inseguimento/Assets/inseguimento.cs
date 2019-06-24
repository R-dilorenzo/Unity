using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inseguimento : MonoBehaviour
{
    public GameObject player;
    private Vector3 distanza;

    void Start() {
        distanza = player.transform.position - this.transform.position;
    }

    void Update() {
        this.transform.position = player.transform.position - distanza;
    }
}
