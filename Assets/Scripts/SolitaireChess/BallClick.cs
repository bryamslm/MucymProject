using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class BallClick : MonoBehaviour
{
    private string [] valores;
    public GameObject myHoof;
    private Animator _victoryAnimator;
    public AudioSource audio;
    public AudioSource audioFelicidades;
    private  ControlGame controlGame;
    public Transform puntoA;
    public Transform puntoB;
    private float tiempo = 0.6f;
    public float alturaMaxima = 0.4f;
    private int turno;



    // Start is called before the first frame update
    void Start()
    {
        controlGame = myHoof.GetComponent<ControlGame>();
        _victoryAnimator = GameObject.Find("VictoryPanel").GetComponent<Animator>();
        valores = controlGame.getArray();
        turno = controlGame.getTurno();
    }

    public int returnEmptySpace()
    {
        valores = controlGame.getArray();
        for (int i = 0; i < valores.Length; i++)
        {
            if (valores[i].Equals("null"))
            {
                return i;
            }
        }
        return -1;
    }

    private int ballInPosition(int index)
    {
        valores = controlGame.getArray();
        if (valores[index].Equals("null"))
        {
            return -1;
        }
        else if(int.Parse(getNum(valores[index])) <= 8)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
    public int returnBallIndex(string name)
    {
        valores = controlGame.getArray();
        for (int i = 0; i < valores.Length; i++)
        {
            if (valores[i].Equals(name))
            {
                return i;
            }
        }
        return -1;
    }
 
    static string getNum(string input)
    {
        // Utilizamos una expresión regular para buscar el número al final del string.
        // La expresión regular busca uno o más dígitos (\d+) seguidos opcionalmente por otros caracteres (\D*) al final del string.
        Match match = Regex.Match(input, @"(\d+)\D*$");

        if (match.Success)
        {
            // Obtenemos el valor capturado en el primer grupo de la expresión regular.
            string numStr = match.Groups[1].Value;
            return numStr;
        }

        // Si no se encuentra ningún número, retornamos una cadena vacía.
        return "";
    }

    public void moveBallToHole(GameObject puntoB, float tiempo)
    {
        StartCoroutine(MoveCoroutine(puntoB, tiempo));
    }

    private IEnumerator MoveCoroutine(GameObject puntoB, float tiempo)
    {
        Vector3 startPosition = transform.parent.localPosition;
        Vector3 endPosition = puntoB.transform.localPosition;

        Vector3 midPosition = new Vector3(startPosition.x, (startPosition.y + endPosition.y) / 2f, startPosition.z);
        // Calculate a mid position that's at the half-height between start and end positions

        float elapsedTime = 0f;

        while (elapsedTime < tiempo)
        {
            float t = elapsedTime / tiempo;
            t = Mathf.SmoothStep(0f, 1f, t); // Smooth interpolation

            Vector3 newPosition;

            if (t < 0.5f)
            {
                // Move vertically upwards
                newPosition = Vector3.Lerp(startPosition, midPosition, t * 2f);
            }
            else
            {
                // Move horizontally and then vertically downwards
                float tAdjusted = (t - 0.5f) * 2f; // Adjust t for the second phase
                newPosition = Vector3.Lerp(midPosition, endPosition, tAdjusted);
                newPosition.y = Mathf.Lerp(midPosition.y, endPosition.y, tAdjusted * 2f);
            }

            transform.parent.localPosition = newPosition;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is exactly puntoB
        transform.parent.localPosition = endPosition;
        Debug.Log("Destino: " + puntoB.name + " - Coordenadas: " + endPosition);
    }

    public bool moveBall(string name)
    {
        valores = controlGame.getArray();
        audio.Play();
        int indexBallV = returnBallIndex(name);
        int i = returnEmptySpace();
        
        if (valores[i].Equals("null"))
        {
            valores[i] = name;
            valores[indexBallV] = "null";
            controlGame.setArray(valores);
    
            //find object by name from parent
            Debug.Log("Valor i: " + i);
            GameObject holeLlegada = transform.parent.parent.Find("hole" + (i+1)).gameObject;
            this.turno  = this.turno == 0 ? 1 : 0; //cambiar turno
            controlGame.setTurno(this.turno);
            controlGame.sumTurno();
            moveBallToHole(holeLlegada, tiempo);
        }
        
        return false;
    }

    private void position0(string name)
    {
        int emptySpace = returnEmptySpace();

        if(emptySpace == 1 && turno == 0)
        {
            moveBall(name);
        }
        else if(emptySpace == 3 && turno == 0)
        {
            moveBall(name);
        }
        else if(emptySpace == 2 && ballInPosition(1) == 1 && turno == 0)
        {
            moveBall(name);
        }
        else if(emptySpace == 6 && ballInPosition(3) == 1 && turno == 0)
        {
            moveBall(name);
        }
    }

    private void position1(string name){
        int emptySpace =  returnEmptySpace();

        if(emptySpace == 0 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 2 && turno == 0)
        {
            moveBall(name);
        }
        else if(emptySpace == 4 && turno == 0)
        {
            moveBall(name);
        }
        else if(emptySpace == 7 && ballInPosition(4) == 1 && turno == 0)
        {
            moveBall(name);
        }
    }

    private void position2(string name){
        int emptySpace =  returnEmptySpace();

        if(emptySpace == 1 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 5 && turno == 0)
        {
            moveBall(name);
        }
        else if(emptySpace == 8 && ballInPosition(5) == 1 && turno == 0)
        {
            moveBall(name);
        }
    }

    private void position3(string name){
        int emptySpace =  returnEmptySpace();

        if(emptySpace == 1 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 4 && turno == 0)
        {
            moveBall(name);
        }
        else if(emptySpace == 6 && turno == 0)
        {
            moveBall(name);
        }
        else if(emptySpace == 5 && ballInPosition(4) == 1 && turno == 0)
        {
            moveBall(name);
        }
    }

    private void position4(string name){
        int emptySpace =  returnEmptySpace();

        if(emptySpace == 1 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 3 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 5 && turno == 0)
        {
            moveBall(name);
        }
        else if(emptySpace == 7 && turno == 0)
        {
            moveBall(name);
        }
    }

    private void position5(string name)
    {
        int emptySpace = returnEmptySpace();

        if(emptySpace == 2 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 3 && ballInPosition(4) == 0 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 4 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 8 && turno == 0)
        {
           moveBall(name);
        }  
        else if(emptySpace == 11 && ballInPosition(8) == 1 && turno == 0)
        {
            moveBall(name);
        } 
    }

    private void position6(string name)
    {
        int emptySpace = returnEmptySpace();

        if(emptySpace == 0 && ballInPosition(3) == 0 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 3 && turno == 1){
            moveBall(name);
        }
        else if(emptySpace == 7 && turno == 0)
        {
           moveBall(name);
        }   
        else if (emptySpace == 8 && ballInPosition(7) == 1 && turno == 0)
        {
            moveBall(name);
        }
    }
    private void position7(string name)
    {
        int emptySpace = returnEmptySpace();

        if(emptySpace == 1 && ballInPosition(4) == 0 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 4 && turno == 1){
            moveBall(name);
        }
        else if(emptySpace == 6 && turno == 1){
            moveBall(name);
        }
        else if(emptySpace == 8 && turno == 0)
        {
           moveBall(name);
        }   
        else if(emptySpace == 9 && ballInPosition(8) == 1 && turno == 0)
        {
            moveBall(name);
        }
    }

    private void position8(string name)
    {
        int emptySpace = returnEmptySpace();

        if(emptySpace == 2 && ballInPosition(5) == 0 && turno == 1)
        {
            moveBall(name);
        }
        else if (emptySpace == 6 && ballInPosition(7) == 0 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 9 && turno == 0)
        {
           moveBall(name);
        } 
        else if(emptySpace == 10 && ballInPosition(9) == 1 && turno == 0)
        {
            moveBall(name);
        }  
        else if(emptySpace == 11 && turno == 0)
        {
            moveBall(name);
        }
        else if(emptySpace == 14 && ballInPosition(11) == 1 && turno == 0)
        {
            moveBall(name);
        }
        else if(emptySpace == 7 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 5 && turno == 1)
        {
            moveBall(name);
        }
    
    }

    private void position9(string name)
    {
        int emptySpace = returnEmptySpace();

        if(emptySpace == 10 && turno == 0)
        {
            moveBall(name);
        }
        else if(emptySpace == 12 && turno == 0)
        {
            moveBall(name);
        }
        else if(emptySpace == 15 && ballInPosition(12) == 1 && turno == 0)
        {
            moveBall(name);
        }
        else if(emptySpace == 8 && turno == 1)
        {
           moveBall(name);
        }   
        else if(emptySpace == 7 && ballInPosition(8) == 0 && turno == 1)
        {
            moveBall(name);
        }
    }
    private void position10(string name)
    {
        int emptySpace = returnEmptySpace();

        if(emptySpace == 9 && turno == 1)
        {
           moveBall(name);
        }   
        else if(emptySpace == 8 && ballInPosition(9) == 0 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 13 && turno == 0){
            moveBall(name);
        }
        else if(emptySpace == 16 && ballInPosition(13) == 1 && turno == 0)
        {
            moveBall(name);
        }
    }
    private void position11(string name)
    {
        int emptySpace = returnEmptySpace();
        if(emptySpace == 8 && turno == 1)
        {
           moveBall(name);
        }   
        else if(emptySpace == 5 && ballInPosition(8) == 0 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 12 && turno == 0){
            moveBall(name);
        }
        else if(emptySpace == 13 && ballInPosition(12) == 1 && turno == 0)
        {
            moveBall(name);
        }
        else if(emptySpace == 14 && turno == 0){
            moveBall(name);
        }
    }

    private void position12(string name)
    {
        int emptySpace = returnEmptySpace();

        if(emptySpace == 9 && turno == 1)
        {
           moveBall(name);
        }   
        else if(emptySpace == 11 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 13 && turno == 0){
            moveBall(name);
        }
        else if(emptySpace == 15 && turno == 0){
            moveBall(name);
        }
    }

    private void position13(string name)
    {
        int emptySpace = returnEmptySpace();
        if(emptySpace == 10 && turno == 1)
        {
           moveBall(name);
        }   
        else if(emptySpace == 11 && ballInPosition(12) == 0 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 12 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 16 && turno == 0){
            moveBall(name);
        }
    }

    private void position14(string name)
    {
        int emptySpace = returnEmptySpace();

        if(emptySpace == 11 && turno == 1)
        {
           moveBall(name);
        }   
        else if(emptySpace == 8 && ballInPosition(11) == 0 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 15 && turno == 0){
            moveBall(name);
        }
        else if(emptySpace == 16 && ballInPosition(15) == 1 && turno == 0){
            moveBall(name);
        }

    }

    private void position15(string name)
    {
        int emptySpace = returnEmptySpace();
        if(emptySpace == 12 && turno == 1)
        {
           moveBall(name);
        }   
        else if(emptySpace == 14 && turno == 1)
        {
            moveBall(name);
        }
        if(emptySpace == 16 && turno == 0){
            moveBall(name);
        }
    }

    private void position16(string name)
    {
        int emptySpace = returnEmptySpace();

        if(emptySpace == 10 && ballInPosition(13) == 0 && turno == 1)
        {
           moveBall(name);
        }   
        else if(emptySpace == 14 && ballInPosition(15) == 0 && turno == 1)
        {
            moveBall(name);
        }
        else if(emptySpace == 13 && turno == 1)
        {
           moveBall(name);
        }   
        else if(emptySpace == 15 && turno == 1)
        {
            moveBall(name);
        }
    }

    public void actionToDo()
    {
        turno = controlGame.getTurno();
        int ballIndex = returnBallIndex(gameObject.name);
        int num = int.Parse(getNum(gameObject.name));

        if(num <= 8){
            turno = 0;
        }else{
            turno = 1;
        }
        Debug.Log("Numero: " + num + " Ball Index: " + ballIndex + " Turno: " + turno );

        if(ballIndex == 0){
            position0(gameObject.name);
        }
        else if(ballIndex == 1){
            position1(gameObject.name);
        }
        else if(ballIndex == 2){
            position2(gameObject.name);
        }
        else if(ballIndex == 3){
            position3(gameObject.name);
        }
        else if(ballIndex == 4){
            position4(gameObject.name);
        }
        else if(ballIndex == 5){
            position5(gameObject.name);
        }
        else if(ballIndex == 6){
            position6(gameObject.name);
        }
        else if(ballIndex == 7){
            position7(gameObject.name);
        }
        else if(ballIndex == 8){
            position8(gameObject.name);
        }
        else if(ballIndex == 9){
            position9(gameObject.name);
        }
        else if(ballIndex == 10){
            position10(gameObject.name);
        }
        else if(ballIndex == 11){
            position11(gameObject.name);
        }
        else if(ballIndex == 12){
            position12(gameObject.name);
        }
        else if(ballIndex == 13){
            position13(gameObject.name);
        }
        else if(ballIndex == 14){
            position14(gameObject.name);
        }
        else if(ballIndex == 15){
            position15(gameObject.name);
        }
        else if(ballIndex == 16){
            position16(gameObject.name);
        }

        //IsWinner();
    }

    public void actionOnExit()
    {

    }
}