using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generazione : MonoBehaviour
{
    public int NumOfClone;
    public GameObject Obj;

    private GameObject[] clones;
    private float time;

    public float TempoDiAggiornamento = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        clones = new GameObject[NumOfClone+1];  //array parte da 0
        for (int i = 0; i < NumOfClone; i++) {
            //per ogni obj dell array instanzio un oggetto GameObject (Obj) con 
            //Instantiate( GameObject da creare, vettore (x,y,z) dove crearlo, rotazione(quaternion[quaternion.identity=stessa rotazione dell oggetto instanziato])  )
            clones[i] = Instantiate(Obj, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)), Quaternion.identity);
            //per inserire un float (-10.5f,10.5f) 
        }
        time = 0.0f;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= TempoDiAggiornamento){ //se si supera il tempo di aggiornamento esegui il blocco  
            time = time - TempoDiAggiornamento;
            for (int i = 0; i < NumOfClone; i++)
            {
                Color colore = new Color(Random.value, Random.value, Random.value, 1);
                clones[i].GetComponent<Renderer>().material.color = colore;

            }
        }
    }
}
