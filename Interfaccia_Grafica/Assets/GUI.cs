using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI : MonoBehaviour
{
    private bool menuPrincipaleOn;
    private bool menuOpzioniOn;
    // Start is called before the first frame update
    void Start()
    {
        menuPrincipaleOn = true;
        menuOpzioniOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private string testo, risposta,nome;
   
    public GUIStyle stileBottoni;  //per permettere la personalizzazione dei bottoni

    void OnGUI() {
        if (menuPrincipaleOn)
        {
            GUILayout.BeginArea(new Rect((Screen.width / 2 - 250), (Screen.height / 2), 500, 500));
            if (GUILayout.Button("Nuova Partita", stileBottoni))
            {
                SceneManager.LoadScene("scena2");
            }
            if (GUILayout.Button("Opzioni", stileBottoni))
            {
                menuPrincipaleOn = false;
                menuOpzioniOn = true;
            }
            GUILayout.EndArea();
        }
        if (menuOpzioniOn == true)
        {
            GUILayout.BeginArea(new Rect((Screen.width / 2 - 250), (Screen.height / 2), 500, 500));
            GUILayout.Button("PROVA", stileBottoni);
            GUILayout.Button("BOTTONE OPZIONI", stileBottoni);
            if (GUILayout.Button("Back", stileBottoni))
            {
                menuPrincipaleOn = true;
                menuOpzioniOn = false;
            }
            GUILayout.EndArea();
        }
    }
    /*
    GUILayout.Button("Nuova Partita");
    GUILayout.Button("Carica Partita");
    GUILayout.Button("Opzioni");
    GUILayout.Button("Extra");
    GUILayout.Button("Esci");
  
    GUILayout.EndArea();
    }
    */
}
