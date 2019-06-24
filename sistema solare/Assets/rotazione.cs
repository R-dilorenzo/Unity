using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotazione : MonoBehaviour
{
    public GameObject target;
    public GameObject obj;
    public float speed;

    void Start() { }
    void Update()
    {
        GameObject body = this.target;
        GameObject x = this.obj;
        float angle = speed;
        x.transform.RotateAround(target.transform.position, Vector3.up, angle);
    }
}
