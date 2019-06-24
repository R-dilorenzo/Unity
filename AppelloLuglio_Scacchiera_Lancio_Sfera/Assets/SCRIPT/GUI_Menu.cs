using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI_Menu : MonoBehaviour
{
    public GUIStyle stileBottoni;
    public GUIStyle stileScritta;

    static bool menuPrincipale=true;
    static bool menuGameOver=false;

 

    // Start is called before the first frame update
    void Start()
    {
        //non inizializzo le variabili nello start altrimenti ogni volta che viene caricata la scena menu
        //vengono reinizializzate le variabili
        /*
        menuPrincipale = true;
        menuGameOver = false;
        */
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {
        //menù principale attivo all inizio del gioco poi viene settato a false e viene attivato il menù 
        //di gameover quando il giocatore non riesce a completare la partita viene riportato in questa scena 
        if (menuPrincipale)
        {
            GUILayout.BeginArea(new Rect((Screen.width / 2 - 100), (Screen.height / 2 - 100), 200, 200));

            if (GUILayout.Button("Inizia Partita", stileBottoni))
            {
                SceneManager.LoadScene("game");
                menuPrincipale = false;
                menuGameOver = true;
            }
            GUILayout.EndArea();
        }
        if (menuGameOver)
        {
            GUILayout.BeginArea(new Rect((Screen.width / 2 - 100), 100, 200, 400));
            GUILayout.Label("GAMEOVER!",stileScritta);
            GUILayout.Label("Hai colpito per due volte il muro",stileScritta);
            if (GUILayout.Button("Ricomincia Partita", stileBottoni))
            {
                SceneManager.LoadScene("game");
            }
            GUILayout.EndArea();
        }
    }
}
