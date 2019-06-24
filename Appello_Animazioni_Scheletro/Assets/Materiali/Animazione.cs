using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animazione : MonoBehaviour
{
    public Animator anim;
    private int countVite;

    private float inputH; //paramatri inseriti in animator per prendere i tasti
    //private bool BinputH;
    private string strKeyCode;

    private Rigidbody rb;

    private bool run; //paramatro booleano inserito nel animator
    private bool jump;
    public int walkspeed = 1;

    public float anglespeed;
    private GameObject sword;

    private bool BSword;
    private KeyCode upArrow;
    // Start is called before the first frame update
    void Start()
    {
        countVite = 10;
        BSword = false;
        anim = this.GetComponent<Animator>();//per animazione movimento

        rb = GetComponent<Rigidbody>();
        //BinputH = false;
        run = false;
        jump = false;

        anglespeed = Random.value * 10;
        sword = GameObject.Find("free_sword") ;

        upArrow = KeyCode.UpArrow;
    }

    // Update is called once per frame
    void Update()
    {
        /*Prendo i valori e setto i comandi per animazione di movimento */

        //strKeyCode = upArrow.ToString(); //prendo la stringa di uparrow (cast)
         inputH = Input.GetAxis("Vertical");
        //inputH = Input.GetKey(strKeyCode);
        //upArrow.GetHashCode();
        //inputH = upArrow.GetHashCode(); 
        //BinputH = Input.GetKey(KeyCode.UpArrow);    //oppure BinputH = Input.GetKey(strKeyCode);
        //BinputH = Input.GetButton(strKeyCode);
        //anim.SetBool("BinputH", BinputH);
        anim.SetFloat("inputH", inputH);

        if (Input.GetKey(KeyCode.UpArrow) && countVite >=0)
        {
            transform.Translate(Vector3.forward * walkspeed * Time.deltaTime);
        }
       
        /*----*/
       
        /*Prendo i valori per la corsa */
        if (Input.GetKey(KeyCode.LeftShift)) //premendo il tasto LeftMaiusc attivo il parametro bool run
        {
            run = true;
        }
        else
        {
            run = false;
        }
        anim.SetBool("run", run);
        /*----*/
        /*----*/
        float movex = inputH * 20f * Time.deltaTime;
        if (run)
        {
            movex *= 3f;
        }
        rb.velocity = new Vector3(0f, 0f, -movex); //-movex poichè il percorso dritto è posizionato su asse z negativo
                                                   /*----*/
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("attack", true);
        }
        else
        {
            anim.SetBool("attack", false);
        }

        /*
        if (Input.GetKey(KeyCode.Space)) {
            anim.SetBool("jump", true);
        } else {
            anim.SetBool("jump", false);
        }
        */

        if (BSword == true)
        {
            //rotazione su asse z di anglespeed random
            sword.transform.RotateAround(sword.transform.position, Vector3.forward, anglespeed);
        }

    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "vita")
        {
            countVite++;
            Destroy(col.gameObject);
        }
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (string.Equals(otherCollider.gameObject.name, "pedana"))
       // if (otherCollider.gameObject.tag == "pedana")
        {
            BSword = true;
        }

        if (otherCollider.gameObject.tag == "sword")
        {
            countVite--;
            anim.SetInteger("countVite", countVite);
        }
    }
    void OnGUI()
    {

        GUILayout.BeginArea(new Rect(Screen.width/2-125, 0, 250, 250));  //Gui parte dal punto 0,0 (angolo in alto a sinistra e ha dim 150,150
        GUILayout.Label("Vite rimaste:"+countVite);   //contatore monete
        GUILayout.EndArea();

        if (countVite <= 0)
        {
            GUILayout.BeginArea(new Rect(Screen.width / 2 - 125, Screen.height/2-125, 250, 250));  //Gui parte dal punto 0,0 (angolo in alto a sinistra e ha dim 150,150
            GUILayout.Label("HAI PERSO");   //contatore monete
            GUILayout.EndArea();
        }
    }
}