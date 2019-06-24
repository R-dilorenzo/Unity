using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinusoide : MonoBehaviour
{
    public float amplitude;
    public float frequency;
    public float phase;
    private Vector3 initial_position;
    private float time;

    void Start()
    {
        time = 0.0f;
        initial_position = gameObject.transform.position;
    }

    void Update()
    {
        float x = gameObject.transform.position.x;
        float y = initial_position.y + amplitude * Mathf.Sin(2.0f * Mathf.PI * frequency * time + phase);
        float z = gameObject.transform.position.z;
        gameObject.transform.position = new Vector3(x, y, z);
        time = time + 1.0f;
    }

}
