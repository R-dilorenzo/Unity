using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    /*
    public GameObject palla;
    private Rigidbody rbPlayer;
    public GameObject linea;
    private Vector3 x;
    public float moveSpeed = 10;
    */
    private GameObject[] insta;
    public int numeroDiBirilli;
    //private Rigidbody[] rb;
    public GameObject birillo;
    public GameObject pista;

    //private bool impulse;
    //private float force;
    public int Score = 0;
    public Text ScoreText;
    private bool[] birilloup;
    // Start is called before the first frame update
    void Start()
    {
        //rbPlayer = palla.GetComponent<Rigidbody>();

        //prendo lo scale.x di transform(localScale) della scachiera e inserisco in un vettore ponendo y=z=0
        //poichè lo scale della scacchiera era (20,0.5.20) il vettore x risulta(20,0,0)
        //x = new Vector3(linea.transform.localScale.x, 0.0f, 0.0f);

        //instanzio 10 birilli
        numeroDiBirilli = 10;
        insta = new GameObject[numeroDiBirilli];
        //rb = new Rigidbody[numeroDiBirilli];
        for (int i = 0; i < numeroDiBirilli; i++)
        {
            insta[i] = Instantiate(birillo, new Vector3((Random.Range(-4, 5)), (pista.transform.position.y + 1.25f), (Random.Range(5, 20))), Quaternion.identity);
            //ogni birillo ha un colore casuale
            Color colore = new Color(Random.value, Random.value, Random.value, 1);
            insta[i].GetComponent<Renderer>().material.color = colore;
            //ogni birillo ha una massa casuale
            int RMass  = Random.Range(1, 20);
            insta[i].GetComponent<Rigidbody>().mass = RMass;
        }

        //impulse = true;
        //force = 30;

        birilloup = new bool[numeroDiBirilli];
        for (int i = 0; i < numeroDiBirilli; i++)
        {
            birilloup[i] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numeroDiBirilli; i++)
        {
            if (insta[i].transform.up.y < 0.5f && birilloup[i] == true)
            {
                //myscript.Score++;
                Score++;
                ScoreText.text = "SCORE " + Score;
                birilloup[i] = false;
            }
        }

        /*MOVIMENTO*/
        /*
        //invece di invertire (ruotare) la scacchiera e  freccia inverto i tasti 
        //freccia a sinista-->sfera a sinistra-->vettore x (-inf) 
        //freccia a destra-->sfera a destra-->vettore x (+inf) 
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //freccia left--> vettore -inf
            if (palla.transform.position.x >= (-(x.x / 2) + 1)) //prendo la metà dello scale della scacchiera e riduco di 1 poichè siamo su asse positivo
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
              
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //freccia right--> vettore +inf
            if (palla.transform.position.x <= ((x.x / 2) - 1)) //prendo al metà dello scale della scacchiera e aggiungo di 1 poichè siamo su asse negativo
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
        }
        */
        /*fine condizione movimento*/
    }

   

    /*
    void FixedUpdate()
    {
        if (impulse)
        {
            rbPlayer.AddForce(0, 0, force, ForceMode.Impulse);
            impulse = false;
        }
    }
    */

}
