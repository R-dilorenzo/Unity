using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
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

        GUILayout.BeginArea(new Rect((Screen.width / 2 - 150), (Screen.height / 2 - 150), 300, 300));

        if (GUILayout.Button("Ricomincia Partita", stileBottoni))
        {
            SceneManager.LoadScene("game");
        }
        GUILayout.Label("Game Over", stileScritta);
        GUILayout.EndArea();

    }
}
