using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cos : MonoBehaviour
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
       
        time = 0.0f;
        //initial_position = this.target.transform.position;
        initial_position = this.centro.transform.position;
        Debug.Log("posizione: " + initial_position);
        //initial_position = new Vector3(0, 0, 0) ;
    }

    void Update()
    {
        //float x = initial_position.x + amplitude * Mathf.Cos(2.0f * Mathf.PI * frequency * time + phase);
        float x = this.target.transform.position.x;
        float y = this.centro.transform.position.y;
        float z = initial_position.z + amplitude * Mathf.Cos(2.0f * Mathf.PI * frequency * time + phase);
        //float z = this.target.transform.position.z;
        this.target.transform.position = new Vector3(x, y, z);
        //this.target.transform.RotateAround(this.centro.transform.position, new Vector3(x, y, z), time);
        time = time + 1.0f;
    }
}
