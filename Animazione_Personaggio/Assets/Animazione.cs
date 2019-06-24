using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animazione : MonoBehaviour
{
    public Animator anim;
    private int count=0;

    private float inputH, inputV; //paramatri inseriti in animator per prendere i tasti

    private Rigidbody rb;

    private bool run; //paramatro booleano inserito nel animator
    private bool jump;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();//per animazione movimento

        rb = GetComponent<Rigidbody>();
        run = false;
        jump = false;

    }

    // Update is called once per frame
    void Update()
    {
        /*Prendo i valori e setto i comandi per animazione di movimento */
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        /*----*/
    
        /*Prendo i valori per la corsa */
        if (Input.GetKey(KeyCode.LeftShift)) //premendo il tasto LeftMaiusc attivo il parametro bool run
        {
            run = true;
        } else {
            run = false;
        }
        anim.SetBool("run", run);
        /*----*/
        /*----*/
        float movex = inputH * 20f * Time.deltaTime;
        float movez = inputV * 50f * Time.deltaTime;
        if (movez <= 0f)
        {
            movex = 0f;
        }
        else if (run) {
            movex *= 3f;
            movez *= 3f;
        }
        rb.velocity = new Vector3(movex, 0f, movez);
        /*----*/
        /*
        if (Input.GetKey(KeyCode.Space)) {
            anim.SetBool("jump", true);
        } else {
            anim.SetBool("jump", false);
        }
        */
        if (Input.GetKey(KeyCode.Space)) { 
            jump = true;
        }
        else
        {
            jump = false;
        }
        anim.SetBool("jump", jump);
        /*Associo un animazione alla pressione del tasto */
        if (Input.GetKeyDown("1"))
        {
            anim.Play("WAIT01", -1, 0f);
        }
        if (Input.GetKeyDown("2"))
        {
            anim.Play("WAIT02", -1, 0f);
        }
        if (Input.GetKeyDown("3"))
        {
            anim.Play("WAIT03", -1, 0f);
        }
        if (Input.GetKeyDown("4"))
        {
            anim.Play("WAIT04", -1, 0f);
        }

        /*Al quarto di click del mouse sinistro esegue animazione damage01 altrimenti esegue damage00 */
        if (Input.GetMouseButtonDown(0))
        {
            if (count < 3)
            {
                anim.Play("DAMAGED00", -1, 0f);
                count++;
            }
            else
            {
                anim.Play("DAMAGED01", -1, 0f);
                count = 0;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            anim.Play("DAMAGED01", -1, 0f);
        }
    }
}
