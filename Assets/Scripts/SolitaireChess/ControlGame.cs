using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro para usar el textmeshpro
using TMPro;

//para usar el sprite
using UnityEngine.UI;

public class ControlGame : MonoBehaviour
{
    private string[] valores;
    private int turno;
    public TextMeshProUGUI turnoText;


    // Start is called before the first frame update
    void Awake()
    {
        valores = new string[17];
        valores[0] = "Sphere1";
        valores[1] = "Sphere2";
        valores[2] = "Sphere3";
        valores[3] = "Sphere4";
        valores[4] = "Sphere5";
        valores[5] = "Sphere6";
        valores[6] = "Sphere7";
        valores[7] = "Sphere8";
        valores[8] = "null";
        valores[9] = "Sphere10";
        valores[10] = "Sphere11";
        valores[11] = "Sphere12";
        valores[12] = "Sphere13";
        valores[13] = "Sphere14";
        valores[14] = "Sphere15";
        valores[15] = "Sphere16";
        valores[16] = "Sphere17";

        //random turno int 0 o 1
        turno = Random.Range(0, 2);

        
    }

    public string [] getArray()
    {
        return valores;
    }

    private void printLista(){
        for (int i = 0; i < valores.Length; i++)
        {
            Debug.Log("Index " + i + ": " + valores[i]);
        }
    }

    public void setArray(string [] array)
    {
        valores = array;
        //printLista();
    }

    public void setTurno(int turno)
    {
        this.turno = turno;
    }

    public int getTurno()
    {
        return turno;
    }

    public void sumTurno(){
        int numTurno = int.Parse(turnoText.text);
        numTurno++;
        turnoText.text = numTurno.ToString();
    }

    
}
