using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generazione_cambioColore : MonoBehaviour
{
    public int NumOfClone;
    public GameObject Obj;

    private GameObject[] clones;
    private float time;

    public float TempoDiAggiornamento = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        clones = new GameObject[NumOfClone + 1];
        for (int i = 0; i < NumOfClone; i++)
        {
            clones[i] = Instantiate(Obj, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)), Quaternion.identity);

        }
        time = 0.0f;
        
    }

    void Update()
    {

        time += Time.deltaTime;
        if (time >= TempoDiAggiornamento)
        {
            time = time - TempoDiAggiornamento;
            for (int i = 0; i < NumOfClone; i++)
            {
                float x = Random.value;
                Color colore = clones[i].GetComponent<Renderer>().material.color;
                colore.a = x;
                clones[i].GetComponent<Renderer>().material.color = colore;
            }
        }
    }
}
