using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger_Palla : MonoBehaviour
{
    //static var per mantenere il conteggio anche dopo che object è stato distrutto e viene 
    //riassegnato lo script alla palla successiva
    //inserendolo come private si azzera ad ogni instanziazione di una palla
    static int countVite=0;
    static int countVittoria = 0;

    //private Game myScript; //puntatore ad una variabile di uno script diverso

    public GUIStyle stileScritta1;

    // Start is called before the first frame update
    void Start()
    {
        //myScript = gameObject.GetComponent<Game>(); //ora che è inizializzato per accedere ad una 
        //variabile dello script game-->myScript.NOME_VARIABILE        
        countVite = 0;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    
    private void OnTriggerEnter(Collider otherCollider)
    {
       
        if (otherCollider.gameObject.tag == "muro")
        {
            countVite++;
            Destroy(gameObject);
            
            /*CONDIZIONE GAMEOVER*/
            //dopo che è stato toccato per due volte il muro ritorna al men+ e 
            if (countVite.Equals(2))
            {
                SceneManager.LoadScene("menu");
            }
           /*fine condizione gameover*/
        }
        if (otherCollider.gameObject.tag == "sfera")
        {
            if (gameObject.GetComponent<Renderer>().material.color == otherCollider.gameObject.GetComponent<Renderer>().material.color)
            {
                countVittoria++;
                Destroy(gameObject);
                Destroy(otherCollider.gameObject);
                /*CONDIZIONE DI VITTORIA*/
                if (countVittoria.Equals(3))
                {
                    SceneManager.LoadScene("vittoria");
                }
                /*fine condizione di v*/
            }
        }
    }
    

    void OnGUI()
    {

        GUILayout.BeginArea(new Rect((Screen.height / 2),0 , 150, 150)); 
        
        GUILayout.Label("colpisci le sfere dello stesso colore");  
        GUILayout.EndArea();

     
    }
    
}
