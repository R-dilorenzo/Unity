using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotazione_su_Asse : MonoBehaviour
{
    public GameObject target;
    public float speed;

    void Start() { }
    void Update()
    {
        GameObject body = this.target;
        float angle = speed;
        body.transform.RotateAround(target.transform.position, Vector3.up, angle);
    }
}
