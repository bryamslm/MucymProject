using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Transform pivot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //cuando se detecta una colision con el objeto
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        //hacer este hijo del other si name es agarreIzquiero o agarreDerecho
        if (other.name == "AgarreIzquierdo" || other.name == "AgarreDerecho")
        {
            this.transform.parent = pivot;
            Debug.Log("Triggered by " + other.name);
        }
    }

    //cuando se deja de detectar una colision con el objeto
    void OnTriggerExit(Collider other)
    {
        //hacer este hijo del other
        this.transform.parent = null;
    }
}
