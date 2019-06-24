using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene scena = SceneManager.GetActiveScene();
        if(transform.position.y < -5.0f)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
