using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public float moveSpeed=15;
    public GameObject freccia;
    public GameObject scacchiera;

    private Vector3 x;

    private Vector3 distanza;
    public GameObject palla;
    
    private GameObject[] insta;
    private int i = 0;
    public Rigidbody[] rb;
    public int numPalle_vite=3;

    public GUIStyle stileBottoni;
    public GUIStyle stileScritta;

    private bool count;

    private Color[] colori;
    private List<Color> Lcolor;
    private int coloreScelto;

    //private Trigger_Palla myscript;

    // Start is called before the first frame update
    void Start()
    {
        //myscript = gameObject.GetComponent<Trigger_Palla>();
        
        //prendo lo scale.x di transform(localScale) della scachiera e inserisco in un vettore ponendo y=z=0
        //poichè lo scale della scacchiera era (20,0.5.20) il vettore x risulta(20,0,0)
        x = new Vector3(scacchiera.transform.localScale.x, 0.0f,0.0f);

        //instanzio una palla quando il gioco viene avviato
        insta = new GameObject[20];
        rb = new Rigidbody[20];
       insta[i]=Instantiate(palla, new Vector3(freccia.transform.position.x, freccia.transform.position.y + 1, freccia.transform.position.z + 2.4f), Quaternion.identity);

        count = true;
        rb[i] = insta[i].GetComponent<Rigidbody>();
        
        //instanzio i colori possibili i 3 colori possibili
        colori = new Color[3];
        colori[0] = Color.red;
        colori[1] = Color.green;
        colori[2] = Color.blue;
        coloreScelto = Random.Range(0, colori.Length);
        insta[i].GetComponent<Renderer>().material.color = colori[coloreScelto];
        RemoveAt(ref colori, coloreScelto);
        /*
        //colori attraverso lista
        Lcolor = new List<Color>(3);//lista di 3 elementi
        Lcolor.Add(Color.red);
        Lcolor.Add(Color.green);
        Lcolor.Add(Color.blue);
        coloreScelto = Random.Range(0, Lcolor.Count);
        insta[i].GetComponent<Renderer>().material.color = Lcolor[coloreScelto];
        Lcolor.RemoveAt(coloreScelto);
        */
    }

    // Update is called once per frame
    void Update()
    {
      
        /*MOVIMENTO*/
        //invece di invertire (ruotare) la scacchiera e  freccia inverto i tasti 
        //freccia a sinista-->sfera a sinistra-->vettore x (+inf) 
        //freccia a destra-->sfera a destra-->vettore x (-inf) 
        if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A))
        {
            //freccia left--> vettore +inf
            //if (freccia.transform.position.x <= 9.0f)  //prendo manualmente il valore MAX per restare sulla scacchiera (scaleScacchiera.x/2-1)
            if(freccia.transform.position.x <= ((x.x/2)-1) ) //prendo la metà dello scale della scacchiera e riduco di 1 poichè siamo su asse positivo
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                //al movimento della freccia corrisponde il movimento della palla(i) corrispondente
                insta[i].transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D))
        {
            //freccia right--> vettore -inf
            //if (freccia.transform.position.x >= -9.0f)  //prendo manualmente il valore MIN per restare sulla scacchiera (scaleScacchiera.x/2-1)
            if(freccia.transform.position.x >= (-(x.x/2)+1) ) //prendo al metà dello scale della scacchiera e aggiungo di 1 poichè siamo su asse negativo
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                //al movimento della freccia corrisponde il movimento della palla(i) corrispondente
                insta[i].transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
        }
        /*fine condizione movimento*/

        /*LANCIO PALLA*/
        if (Input.GetKey(KeyCode.F) && count == true)
        {
            rb[i].AddForce(-transform.forward * moveSpeed * 40);
            count = false;
        }
        /*fine lancio palla*/
        
        /*INSTANZIO NUOVA PALLA*/
        //alla pressione della barra spazziatrice si instanzia una nuova palla
        if (Input.GetKeyDown(KeyCode.Space) && count == false)
        {
            count = true;
            i++;
            insta[i] = Instantiate(palla, new Vector3(freccia.transform.position.x, freccia.transform.position.y + 1, freccia.transform.position.z + 2.4f), Quaternion.identity);
            //prende uno dei colori che non è stato ancora scelto, lo assesgna a insta(i++) e lo rimuove dall array
            coloreScelto = Random.Range(0, colori.Length);
            insta[i].GetComponent<Renderer>().material.color = colori[coloreScelto];
            RemoveAt(ref colori, coloreScelto);
            rb[i] = insta[i].GetComponent<Rigidbody>();
        }
        /*fine instanziazione palla*/

    }
    

    //bottone ricomincia partita
    void OnGUI()
    {

        GUILayout.BeginArea(new Rect(0, 0, 150, 150));

        if (GUILayout.Button("Ricomincia Partita", stileBottoni))
        {
            SceneManager.LoadScene("game");
        }
        GUILayout.Label("Premi F per lanciare la palla", stileScritta);
        GUILayout.EndArea();
    }

    public static void RemoveAt<T>(ref T[] arr, int index)
    {
        for (int a = index; a < arr.Length - 1; a++)
        {
            // moving elements downwards, to fill the gap at [index]
            arr[a] = arr[a + 1];
        }
        // finally, let's decrement Array's size by one
        System.Array.Resize(ref arr, arr.Length - 1);
    }
}
