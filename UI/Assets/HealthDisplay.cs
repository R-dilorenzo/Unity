using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    //ADD COMPONENT TEXT (icona gialla al gameobject text) e assegnare a public Text
    public int health = 5;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HEALTH:" + health;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            health--;
        }
    }
}
