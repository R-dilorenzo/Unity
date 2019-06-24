using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sin : MonoBehaviour
{
    public float amplitude;
    public float frequency;
    public float phase;
    private Vector3 initial_position;
    private float time;

    public GameObject target;
    public GameObject centro;


    void Start()
    {
        GameObject x = this.centro;
        time = 0.0f;
        //initial_position = this.target.transform.position;
        initial_position = this.centro.transform.position;
        //initial_position = new Vector3(0,0,0);
    }

    void Update()
    {

        //float x = this.target.transform.position.x;
        //float y = initial_position.y + amplitude * Mathf.Sin(2.0f * Mathf.PI * frequency * time + phase);
        float x = initial_position.x + amplitude * Mathf.Sin(2.0f * Mathf.PI * frequency * time + phase);
        float y = this.centro.transform.position.y;
        float z = this.target.transform.position.z;
        this.target.transform.position = new Vector3(x, y, z);
        time = time + 1.0f;
        //this.target.transform.RotateAround(this.centro.transform.position, new Vector3(x, y, z), time);
    }
}
