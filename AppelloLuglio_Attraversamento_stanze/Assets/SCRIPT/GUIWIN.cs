using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIWIN : MonoBehaviour
{
    public GUIStyle stileBottoni;
    public GUIStyle stileScritta;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {

        GUILayout.BeginArea(new Rect((Screen.width / 2 - 400), (Screen.height / 2 - 150), 800, 300));

        if (GUILayout.Button("Nuova Partita", stileBottoni))
        {
            SceneManager.LoadScene("game");
        }
        GUILayout.Label("FINE PARTITA", stileScritta);
        GUILayout.EndArea();

    }
}
