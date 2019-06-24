using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisioneSpada : MonoBehaviour
{
    private bool Bwin;
    // Start is called before the first frame update
    void Start()
    {
        Bwin = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "barile")
        {
            Destroy(col.gameObject);
            Bwin = true;

        }
    }
    void OnGUI()
    {
        if (Bwin == true)
        {
            GUILayout.BeginArea(new Rect(Screen.width / 2 - 125, Screen.height / 2 - 125, 250, 250));  //Gui parte dal punto 0,0 (angolo in alto a sinistra e ha dim 150,150
            GUILayout.Label("HAI VINTO");   //contatore monete
            GUILayout.EndArea();
        }
    }
    
    
}
