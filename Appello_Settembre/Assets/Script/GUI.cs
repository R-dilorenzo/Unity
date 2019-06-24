using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI : MonoBehaviour
{
    //------------------------
    //------------------------
    //GUI+DESTROY MONETE+WIN+OVER
    //------------------------
    //------------------------

    public GUIStyle stileBottoni;  //per permettere la personalizzazione dei bottoni
    private int countMonete;
    public GUIStyle stileScritta;


    // Update is called once per frame
    void Start()
    {
        countMonete = 0;
    }

    void Update()
    {
        if (countMonete == 10)    //condizione vittoria:se il contatore arriva a 10 carica la schermata di vittoria
        {
            SceneManager.LoadScene("vittoria");
        }
    }

    void OnGUI()
    {
       
        GUILayout.BeginArea(new Rect(0,0, 150, 150));  //Gui parte dal punto 0,0 (angolo in alto a sinistra e ha dim 150,150
        if (GUILayout.Button("Ricomincia Partita", stileBottoni))
        {
            SceneManager.LoadScene("game");
        }
        GUILayout.Label("Monete:" + countMonete,stileScritta);   //contatore monete
        GUILayout.EndArea();
       
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Moneta")   //Destroy Moneta e aggiorna il contatore
        {
            Destroy(col.gameObject);
            countMonete++;
        }
        if (col.collider.tag == "muro")    //Se il player collide con un muro carica la scena di gameover
        {
            SceneManager.LoadScene("gameover");
        }
    }
}
