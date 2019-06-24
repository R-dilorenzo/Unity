using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moto_Ellittico : MonoBehaviour
{
    public Transform target;
    public float RotationSpeed = 100f;
    public float OrbitDegrees = 1f;
    void Update()
    {
        transform.Rotate(Vector3.left, RotationSpeed * Time.deltaTime); //rotazione su se stesso
        transform.RotateAround(target.position, Vector3.up, OrbitDegrees);  //rotazione intorno target
    }
}
