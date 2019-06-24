using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game : MonoBehaviour
{
    public float speed;
    private Rigidbody rigid;
    private bool Bwin;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Bwin = false;
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
        //movimento attraverso traslazione della sfera
        //poichè il labirinto ha gli assi invertiti ad una pressione su asse
        //verticale +inf (sopra) corrisponde una traslazione verso il basso (e viceversa)
        //orizzontale +inf (destra) corrisponde una traslazione verso sinistra (e viceversa)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
       
    }

    public void OnCollisionEnter(Collision col)
    {
        //se la sfera collide con il cubo distrugge il cubo e setta la condizione di vittoria a true
        if (col.collider.tag == "cuboWin")
        {
            Destroy(col.gameObject);
            Bwin = true;
        }

        //se la sfera ha preso il cubo e tocca il muro giallo allora carica la scena di vittoria
        if (col.collider.tag == "muroWin" && Bwin==true)
        {
            SceneManager.LoadScene("win");
        }

        //se la sfera colpisce uno dei muri rossi allora carica la scena di gameover
        if (col.collider.tag == "muro")
        {
            SceneManager.LoadScene("gameover");
        }
    }
}
