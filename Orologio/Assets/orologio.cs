using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orologio : MonoBehaviour
{
    public GameObject target;
    public GameObject Sfera_minuti;
    public GameObject Sfera_secondi;


    public float speed;

    void Start() { }
    void Update()
    {
        GameObject body = this.target;
        GameObject x = this.Sfera_minuti;
        GameObject y = this.Sfera_secondi;
        float angle = speed;
        y.transform.RotateAround(target.transform.position, Vector3.up, angle);
        double min = (double) 1/60;
        //double min = 0.0166666666666667; //(1/60) precalcolato
        float Fmin = (float)min;
        float angle1 = speed * Fmin;
        x.transform.RotateAround(target.transform.position, Vector3.up, angle1);
    }
}
