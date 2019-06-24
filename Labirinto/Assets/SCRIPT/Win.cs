using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GUIStyle stileBottone;
    public GUIStyle stileS;
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

        GUILayout.BeginArea(new Rect((Screen.width / 2 - 150), (Screen.height / 2-150), 300, 300));
        GUILayout.Label("HAI VINTO", stileS);
        if (GUILayout.Button("Ricomincia Partita", stileBottone))
        {
            SceneManager.LoadScene("game");
        }
        GUILayout.EndArea();

    }
}
