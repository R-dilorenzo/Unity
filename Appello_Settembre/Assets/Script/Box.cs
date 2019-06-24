using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    //------------------------
    //------------------------
    //APPLICARE AL PLAYER(sfera) E AGGIUNGERE AD OGGETTO CHE COLLIDE(box) IL TAG
    //------------------------
    //------------------------
    private int NumOfClone=10;   //numero di oggetti da spawnare
    public GameObject Obj;    //oggetto da spawnare (instanziare)[moneta in questo caso]

    private GameObject[] clones;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "box")   //se il player tocca la box distrugge la box e spawn random delle monete
        {
            clones = new GameObject[NumOfClone + 1];
            for (int i = 0; i < NumOfClone; i++)
            {
                clones[i] = Instantiate(Obj, new Vector3(Random.Range(-15, 15), 1, Random.Range(-15, 15)), Quaternion.identity);

            }
            Destroy(col.gameObject);    //distrugge oggetto che collide
        }
    }
}
