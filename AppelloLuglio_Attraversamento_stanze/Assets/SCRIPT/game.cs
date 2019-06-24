using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game : MonoBehaviour
{
    public float speed = 70;
    private Rigidbody rigid;

    private List<Color> Lcolor;
    private int coloreScelto;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        //Aggiungo i 3 colori attraverso una lista
        Lcolor = new List<Color>(3);//lista di 3 elementi
        Lcolor.Add(Color.red);
        Lcolor.Add(Color.green);
        Lcolor.Add(Color.blue);

       
       
       // Lcolor.RemoveAt(coloreScelto);
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(h, 0.0f, v);
        rigid.AddForce(speed * input * Time.deltaTime);
     
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "cubo")   
        {
            //viene randomicamente un colore dalla lista e viene assegnato alla palla
            coloreScelto = Random.Range(0, Lcolor.Count);
            gameObject.GetComponent<Renderer>().material.color = Lcolor[coloreScelto];
        }
        if (col.collider.tag == "muro")
        {
            SceneManager.LoadScene("gameover");
        }

    }
    
   
    /*
    public void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "porta")
        {
            Lcolor.RemoveAt(coloreScelto);  //tolgo il colore dalla lista
        }
    }
    */
}
