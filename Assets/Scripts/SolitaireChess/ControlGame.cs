using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
//using TMPro para usar el textmeshpro
using TMPro;

//para usar el sprite
using UnityEngine.UI;

public class ControlGame : MonoBehaviour
{
    private string[] valores;
    private int turno;
    public TextMeshProUGUI turnoText;

    public AudioSource audioFelicidades;
    private Animator _victoryAnimator;
    private Animator _lostAnimator;
    public bool startGame = false;
    public UI_Manager4E uiManager4E;


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
        
    }

    void Start(){
        _victoryAnimator = GameObject.Find("VictoryPanel").GetComponent<Animator>();
        _lostAnimator = GameObject.Find("LostPanel").GetComponent<Animator>();
        uiManager4E = GameObject.Find("Canvas").GetComponent<UI_Manager4E>();
    }

    public void StartGame(){
        Debug.Log("StartGame");
        startGame = true;
        uiManager4E.StartTimer();
        uiManager4E.ActivateTip();
        
    }

    public void ShowTip(){
        uiManager4E.ShowTip();
    }

    public string [] getArray()
    {
        return valores;
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

    static string getNum(string input)
    {  // Utilizamos una expresión regular para buscar el número al final del string.
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

    private int ballInPosition(int index)
    {
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
      

    public int returnEmptySpace()
    {
        for (int i = 0; i < valores.Length; i++)
        {
            if (valores[i].Equals("null"))
            {
                return i;
            }
        }
        return -1;
    }

    public void winner(){
        Debug.Log("Ganaste");
        _victoryAnimator.SetBool("ShowVictory", true);
        audioFelicidades.Play();
        uiManager4E.StopTimer();
    }

    public bool cierreHole0(int holeIndex){
        int colorVecino = int.Parse(getNum(valores[holeIndex + 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 2])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 6])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }

        return true;
    }

    public bool cierreHole1(int holeIndex){
            
            int colorVecino = int.Parse(getNum(valores[holeIndex - 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
            if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
                return false;
            }
    
            colorVecino = int.Parse(getNum(valores[holeIndex + 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
            if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
                return false;
            }
    
            colorVecino = int.Parse(getNum(valores[holeIndex + 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
            if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
                return false;
            }
    
            colorVecino = int.Parse(getNum(valores[holeIndex + 6])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
            if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
                return false;
            }
    
            return true;
    }

    public bool cierreHole2(int holeIndex){
        
        int colorVecino = int.Parse(getNum(valores[holeIndex - 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex - 2])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 6])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }

        return true;
    }

    public bool cierreHole3(int holeIndex){
            
            int colorVecino = int.Parse(getNum(valores[holeIndex - 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
            if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
                return false;
            }
    
            colorVecino = int.Parse(getNum(valores[holeIndex + 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
            if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
                return false;
            }
    
            colorVecino = int.Parse(getNum(valores[holeIndex + 2])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
            if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
                return false;
            }
    
            colorVecino = int.Parse(getNum(valores[holeIndex + 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
            if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
                return false;
            }
    
            return true;
    }

    public bool cierreHole4(int holeIndex){

        int colorVecino = int.Parse(getNum(valores[holeIndex - 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex - 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }

        return true;
    }

    public bool cierreHole5(int holeIndex){
            
        int colorVecino = int.Parse(getNum(valores[holeIndex - 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex - 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex - 2])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 6])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }

        return true;
    }

    public bool cierreHole6(int holeIndex){

        int colorVecino = int.Parse(getNum(valores[holeIndex - 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex - 6])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 2])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }

        return true;
    }

    public bool cierreHole7(int holeIndex){

        int colorVecino = int.Parse(getNum(valores[holeIndex - 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex - 6])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex - 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 2])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }

        return true;
    }

    public bool cierreHole8(int holeIndex){

        int colorVecino = int.Parse(getNum(valores[holeIndex - 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex - 2])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex - 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex - 6])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 2])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 6])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        return true;
    }

    public bool cierreHole9(int holeIndex){

        int colorVecino = int.Parse(getNum(valores[holeIndex - 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex - 2])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 6])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }

        return true;
    }

    public bool cierreHole10(int holeIndex){

        int colorVecino = int.Parse(getNum(valores[holeIndex - 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex - 2])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex + 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex + 2])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }

        return true;
    }

    public bool cierreHole11(int holeIndex){

        int colorVecino = int.Parse(getNum(valores[holeIndex - 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex - 6])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex + 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex + 2])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex + 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }

        return true;
    }

    public bool cierreHole12(int holeIndex){

        int colorVecino = int.Parse(getNum(valores[holeIndex - 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex - 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex + 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex + 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }

        return true;
    }

    public bool cierreHole13(int holeIndex){

        int colorVecino = int.Parse(getNum(valores[holeIndex - 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex - 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex - 2])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false;
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex + 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){//si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false;
        }

        return true;
    }

    public bool cierreHole14(int holeIndex){

        int colorVecino = int.Parse(getNum(valores[holeIndex - 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){//si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false; 
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex - 6])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){ //si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false; 
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex + 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){ //si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false; 
        }

        colorVecino = int.Parse(getNum(valores[holeIndex + 2])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){ //si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false; 
        }

        return true;
    }

    public bool cierreHole15(int holeIndex){

        int colorVecino = int.Parse(getNum(valores[holeIndex - 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){ //si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false; 
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex - 6])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){ //si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false; 
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex - 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){ //si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false; 
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex + 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 1){ //si el indice usado en valores[] es menor que holeIndex y color vecino es 1 entonces perdio = false
            return false; 
        }

        return true;
    }

    public bool cierreHole16(int holeIndex){

        int colorVecino = int.Parse(getNum(valores[holeIndex - 3])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){ //si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false; 
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex - 6])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){ //si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false; 
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex - 1])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){ //si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false; 
        }
            
        colorVecino = int.Parse(getNum(valores[holeIndex - 2])) <= 8 ? 0 : 1;//0 es rojo y 1 es azul
        if(colorVecino == 0){ //si el indice usado en valores[] es menor que holeIndex y color vecino es 0 entonces perdio = false
            return false; 
        }

        return true;
    }

    private void ShowVictoryScreen()
    {
        _victoryAnimator.SetBool("ShowVictory", true);
        audioFelicidades.Play();
    }

    public void verificarJuegoPerdido(){
        int espacioVacio = returnEmptySpace();
        if(espacioVacio == 0){
            if(cierreHole0(espacioVacio)){
                Debug.Log("Perdiste");
                _lostAnimator.SetBool("ShowVictory", true);
            }
        }else if(espacioVacio == 1){
            if(cierreHole1(espacioVacio)){
                Debug.Log("Perdiste");
                _lostAnimator.SetBool("ShowVictory", true);
            }
        }else if(espacioVacio == 2){
            if(cierreHole2(espacioVacio)){
                Debug.Log("Perdiste");
                _lostAnimator.SetBool("ShowVictory", true);
            }
        }else if(espacioVacio == 3){
            if(cierreHole3(espacioVacio)){
                Debug.Log("Perdiste");
                _lostAnimator.SetBool("ShowVictory", true);
            }
        }else if(espacioVacio == 4){
            if(cierreHole4(espacioVacio)){
                Debug.Log("Perdiste");
                _lostAnimator.SetBool("ShowVictory", true);
            }
        }else if(espacioVacio == 5){
            if(cierreHole5(espacioVacio)){
                Debug.Log("Perdiste");
                _lostAnimator.SetBool("ShowVictory", true);
            }
        }else if(espacioVacio == 6){
            if(cierreHole6(espacioVacio)){
                Debug.Log("Perdiste");
                _lostAnimator.SetBool("ShowVictory", true);
            }
        }else if(espacioVacio == 7){
            if(cierreHole7(espacioVacio)){
                Debug.Log("Perdiste");
                _lostAnimator.SetBool("ShowVictory", true);
            }
        }else if(espacioVacio == 8){
            if(cierreHole8(espacioVacio)){
                Debug.Log("Perdiste");
                _lostAnimator.SetBool("ShowVictory", true);
            }
        }else if(espacioVacio == 9){
            if(cierreHole9(espacioVacio)){
                Debug.Log("Perdiste");
                _lostAnimator.SetBool("ShowVictory", true);
            }
        }else if(espacioVacio == 10){
            if(cierreHole10(espacioVacio)){
                _lostAnimator.SetBool("ShowVictory", true);
                Debug.Log("Perdiste");
            }
        }else if(espacioVacio == 11){
            if(cierreHole11(espacioVacio)){
                Debug.Log("Perdiste");
                _lostAnimator.SetBool("ShowVictory", true);
            }
        }else if(espacioVacio == 12){
            if(cierreHole12(espacioVacio)){
                Debug.Log("Perdiste");
                _lostAnimator.SetBool("ShowVictory", true);
            }
        }else if(espacioVacio == 13){
            if(cierreHole13(espacioVacio)){
                Debug.Log("Perdiste");
                _lostAnimator.SetBool("ShowVictory", true);
            }
        }else if(espacioVacio == 14){
            if(cierreHole14(espacioVacio)){
                Debug.Log("Perdiste");
                _lostAnimator.SetBool("ShowVictory", true);
            }
        }else if(espacioVacio == 15){
            if(cierreHole15(espacioVacio)){
                Debug.Log("Perdiste");
                _lostAnimator.SetBool("ShowVictory", true);
            }
        }else if(espacioVacio == 16){
            if(cierreHole16(espacioVacio)){
                Debug.Log("Perdiste");
                _lostAnimator.SetBool("ShowVictory", true);
            }
        }


    }

    public void verificarJuegoGanado(){

        bool win = true;
        //si los sphere 1, 2, 3, 4, 5, 6 , 7  y 8 estan en el array entre la posicion 9 al 16 entonces el juego termina
        for(int i = 0; i < 8; i++){
            string sphere =  valores[i];
            if(sphere == "null"){
                win = false;
                break;
            }
            int num = int.Parse(getNum(sphere));
            if(num < 10){
                win = false;
                break;
            }
        }

        if(win){
            winner();
        }else{
            verificarJuegoPerdido();
        }

    }

    public void sumTurno(){
        int numTurno = int.Parse(turnoText.text);
        numTurno++;
        turnoText.text = numTurno.ToString();
    }

    
}
