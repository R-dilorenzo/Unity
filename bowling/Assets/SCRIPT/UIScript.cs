using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject palla;
    private Rigidbody rbPlayer;
    public GameObject linea;
    private Vector3 x;
    public float moveSpeed = 10;

    private bool impulse;
    private bool lancioPalla;
    private float force;

    public Button muoviASinistra, muoviADestra, go;

    //public  int Score=0;
    //public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = palla.GetComponent<Rigidbody>();

        //prendo lo scale.x di transform(localScale) della scachiera e inserisco in un vettore ponendo y=z=0
        //poichè lo scale della scacchiera era (20,0.5.20) il vettore x risulta(20,0,0)
        x = new Vector3(linea.transform.localScale.x, 0.0f, 0.0f);

        impulse = false;
        force = 400;
        lancioPalla = false;
        
        muoviASinistra.onClick.AddListener(MuoviASinistra);
        muoviADestra.onClick.AddListener(MuoviADestra);
        go.onClick.AddListener(Go);

        //Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //freccia left--> vettore -inf
            if (palla.transform.position.x >= (-(x.x / 2) + 1)) //prendo la metà dello scale della scacchiera e riduco di 1 poichè siamo su asse positivo
            {
                palla.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            }
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //freccia right--> vettore +inf
            if (palla.transform.position.x <= ((x.x / 2) - 1)) //prendo al metà dello scale della scacchiera e aggiungo di 1 poichè siamo su asse negativo
            {
                palla.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
        }
        */
        
        //ScoreText.text="SCORE " + Score;
        //Debug.Log(Score);
    }

    public void MuoviASinistra()
    {
        /*MOVIMENTO*/
        //invece di invertire (ruotare) la scacchiera e  freccia inverto i tasti 
        //freccia a sinista-->sfera a sinistra-->vettore x (-inf) 
        //freccia a destra-->sfera a destra-->vettore x (+inf) 
       
            //freccia left--> vettore -inf
            if (palla.transform.position.x >= (-(x.x / 2) + 1) && lancioPalla==false) //prendo la metà dello scale della scacchiera e riduco di 1 poichè siamo su asse positivo
            {
                palla.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            }
        
    }

    public void MuoviADestra()
    {
        /*MOVIMENTO*/
        //invece di invertire (ruotare) la scacchiera e  freccia inverto i tasti 
        //freccia a sinista-->sfera a sinistra-->vettore x (-inf) 
        //freccia a destra-->sfera a destra-->vettore x (+inf) 
        
            //freccia right--> vettore +inf
            if (palla.transform.position.x <= ((x.x / 2) - 1) && lancioPalla==false) //prendo al metà dello scale della scacchiera e aggiungo di 1 poichè siamo su asse negativo
            {
                palla.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
        
    }

    public void Go()
    {
        if (lancioPalla == false)
        {
            impulse = true;
            FixedUpdate();
            lancioPalla = true;
        }
    }
    
    void FixedUpdate()
    {
        if (impulse)
        {
            rbPlayer.AddForce(0, 0, force, ForceMode.Impulse);
            impulse = false;
        }
    }
    
}
