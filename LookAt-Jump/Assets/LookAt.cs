using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    //public Transform target;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PosObj = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
        transform.LookAt(PosObj);
      //  transform.LookAt(target);
    }
}
