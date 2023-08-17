using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateArray : MonoBehaviour
{
    private string[] valores;

    // Start is called before the first frame update
    void Start()
    {
        valores = new string[7];
        valores[0] = "Sphere1";
        valores[1] = "Sphere2";
        valores[2] = "Sphere3";
        valores[3] = "null";
        valores[4] = "Sphere4";
        valores[5] = "Sphere5";
        valores[6] = "Sphere6";
    }

    public string [] getArray()
    {
        return valores;
    }

}