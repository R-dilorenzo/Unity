using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gui_2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private string testo, risposta, nome;
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect((Screen.width / 2-250), (Screen.height / 2), 500, 500));
        GUILayout.Label("Inserisci il nome utente");
        testo = GUILayout.TextField(testo, GUILayout.Width(100));
        if (GUILayout.Button("Invia", GUILayout.Width(100)))
        {
            nome = testo;
            risposta = "Ciao " + testo;
        }
        GUILayout.Label(risposta);
    GUILayout.EndArea();
    }
}
