using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Algorithm : MonoBehaviour
{
    public GameObject myHoof;
    public string name;
    public AudioSource audio;
    public AudioSource audioFelicidades;
    private string [] valores;
    private Animator _victoryAnimator;
    private Animator animacion;

    void Start()
    {
        animacion = this.GetComponent<Animator>();
        CreateArray createArray = myHoof.GetComponent<CreateArray>();
        _victoryAnimator = GameObject.Find("VictoryPanel").GetComponent<Animator>();
        valores = createArray.getArray();
    }

    private int returnEmptySpace()
    {
        Debug.Log("Cont: " + valores.Length);
        for (int i = 0; i < valores.Length; i++)
        {
            Debug.Log("Cont1: " + valores[i]);
            if (valores[i].Equals("null"))
            {
                return i;
            }
        }
        return -1;
    }

    private int returnBallIndex(string name)
    {
        for (int i = 0; i < valores.Length; i++)
        {
            if (valores[i].Equals(name))
            {
                return i;
            }
        }
        return -1;
    }

    private bool moveBall(string name)
    {
        audio.Play();
        int indexBallV = returnBallIndex(name);
        for (int i = 0; i < valores.Length; i++)
        {
            if (i == returnEmptySpace())
            {
                if (valores[i].Equals("null"))
                {
                    valores[i] = name;
                    valores[indexBallV] = "null";
                    return true;
                }
            }
        }
        return false;
    }

    private bool condition1B(string name)
    {
        if (returnBallIndex(name) == 0)
        {
            if (returnEmptySpace() == 1)
            {
                animacion.SetInteger("touch", 1);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 2)
            {
                if (valores[1] != "Sphere2" && valores[1] != "Sphere3")
                {
                    animacion.SetInteger("touch", 2);
                    moveBall(name);
                    return true;
                }
            }
        }
        else if (returnBallIndex(name) == 1)
        {
            if (returnEmptySpace() == 2)
            {
                animacion.SetInteger("touch", 3);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 3)
            {
                if (valores[2] != "Sphere2" && valores[2] != "Sphere3")
                {
                    animacion.SetInteger("touch", 4);
                    moveBall(name);
                    return true;
                }
            }
        }
        else if (returnBallIndex(name) == 2)
        {
            if (returnEmptySpace() == 3)
            {
                animacion.SetInteger("touch", 5);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 4)
            {
                if (valores[3] != "Sphere2" && valores[3] != "Sphere3")
                {
                    animacion.SetInteger("touch", 6);
                    moveBall(name);
                    return true;
                }
            }
        }
        else if (returnBallIndex(name) == 3)
        {
            if (returnEmptySpace() == 4)
            {
                animacion.SetInteger("touch", 7);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 5)
            {
                if (valores[4] != "Sphere2" && valores[4] != "Sphere3")
                {
                    animacion.SetInteger("touch", 8);
                    moveBall(name);
                    return true;
                }
            }
        }
        return false;
    }

    private bool condition2B(string name)
    {
        if (returnBallIndex(name) == 1)
        {
            if (returnEmptySpace() == 2)
            {
                animacion.SetInteger("touch", 1);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 3)
            {
                if (valores[2] != "Sphere3")
                {
                    animacion.SetInteger("touch", 2);
                    moveBall(name);
                    return true;
                }
            }
        }
        else if (returnBallIndex(name) == 2)
        {
            if (returnEmptySpace() == 3)
            {
                animacion.SetInteger("touch", 3);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 4)
            {
                if (valores[3] != "Sphere3")
                {
                    animacion.SetInteger("touch", 4);
                    moveBall(name);
                    return true;
                }
            }
        }
        else if (returnBallIndex(name) == 3)
        {
            if (returnEmptySpace() == 4)
            {
                animacion.SetInteger("touch", 5);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 5)
            {
                if (valores[4] != "Sphere3")
                {
                    animacion.SetInteger("touch", 6);
                    moveBall(name);
                    return true;
                }
            }
        }
        else if (returnBallIndex(name) == 4)
        {
            if (returnEmptySpace() == 5)
            {
                animacion.SetInteger("touch", 7);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 6)
            {
                if (valores[5] != "Sphere3")
                {
                    animacion.SetInteger("touch", 8);
                    moveBall(name);
                    return true;
                }
            }
        }
        return false;
    }

    private bool condition3B(string name)
    {
        if (returnBallIndex(name) == 2)
        {
            if (returnEmptySpace() == 3)
            {
                animacion.SetInteger("touch", 1);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 4)
            {
                animacion.SetInteger("touch", 2);
                moveBall(name);
                return true;
            }
        }
        else if (returnBallIndex(name) == 3)
        {
            if (returnEmptySpace() == 4)
            {
                animacion.SetInteger("touch", 3);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 5)
            {
                animacion.SetInteger("touch", 4);
                moveBall(name);
                return true;
            }
        }
        else if (returnBallIndex(name) == 4)
        {
            if (returnEmptySpace() == 5)
            {
                animacion.SetInteger("touch", 5);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 6)
            {
                animacion.SetInteger("touch", 6);
                moveBall(name);
                return true;
            }
        }
        else if (returnBallIndex(name) == 5)
        {
            if (returnEmptySpace() == 6)
            {
                animacion.SetInteger("touch", 7);
                moveBall(name);
                return true;
            }
        }
        return false;
    }

    private bool condition4R(string name)
    {
        if (returnBallIndex(name) == 4)
        {
            if (returnEmptySpace() == 3)
            {
                animacion.SetInteger("touch", 1);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 2)
            {
                animacion.SetInteger("touch", 2);
                moveBall(name);
                return true;
            }
        }
        else if (returnBallIndex(name) == 3)
        {
            if (returnEmptySpace() == 2)
            {
                animacion.SetInteger("touch", 3);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 1)
            {
                animacion.SetInteger("touch", 4);
                moveBall(name);
                return true;
            }
        }
        else if (returnBallIndex(name) == 2)
        {
            if (returnEmptySpace() == 1)
            {
                animacion.SetInteger("touch", 5);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 0)
            {
                animacion.SetInteger("touch", 6);
                moveBall(name);
                return true;
            }
        }
        else if (returnBallIndex(name) == 1)
        {
            if (returnEmptySpace() == 0)
            {
                animacion.SetInteger("touch", 7);
                moveBall(name);
                return true;
            }
        }
        return false;
    }

    private bool condition5R(string name)
    {
        if (returnBallIndex(name) == 5)
        {
            if (returnEmptySpace() == 4)
            {
                animacion.SetInteger("touch", 1);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 3)
            {
                if (valores[4] != "Sphere4")
                {
                    animacion.SetInteger("touch", 2);
                    moveBall(name);
                    return true;
                }
            }
        }
        else if (returnBallIndex(name) == 4)
        {
            if (returnEmptySpace() == 3)
            {
                animacion.SetInteger("touch", 3);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 2)
            {
                if (valores[3] != "Sphere4")
                {
                    animacion.SetInteger("touch", 4);
                    moveBall(name);
                    return true;
                }
            }
        }
        else if (returnBallIndex(name) == 3)
        {
            if (returnEmptySpace() == 2)
            {
                animacion.SetInteger("touch", 5);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 1)
            {
                if (valores[2] != "Sphere4")
                {
                    animacion.SetInteger("touch", 6);
                    moveBall(name);
                    return true;
                }
            }
        }
        else if (returnBallIndex(name) == 2)
        {
            if (returnEmptySpace() == 1)
            {
                animacion.SetInteger("touch", 7);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 0)
            {
                if (valores[1] != "Sphere4")
                {
                    animacion.SetInteger("touch", 8);
                    moveBall(name);
                    return true;
                }
            }
        }
        return false;
    }

    private bool condition6R(string name)
    {
        if (returnBallIndex(name) == 6)
        {
            if (returnEmptySpace() == 5)
            {
                animacion.SetInteger("touch", 1);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 4)
            {
                if (valores[5] != "Sphere4" && valores[5] != "Sphere5")
                {
                    animacion.SetInteger("touch", 2);
                    moveBall(name);
                    return true;
                }
            }
        }
        else if (returnBallIndex(name) == 5)
        {
            if (returnEmptySpace() == 4)
            {
                animacion.SetInteger("touch", 3);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 3)
            {
                if (valores[4] != "Sphere4" && valores[4] != "Sphere5")
                {
                    animacion.SetInteger("touch", 4);
                    moveBall(name);
                    return true;
                }
            }
        }
        else if (returnBallIndex(name) == 4)
        {
            if (returnEmptySpace() == 3)
            {
                animacion.SetInteger("touch", 5);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 2)
            {
                if (valores[3] != "Sphere4" && valores[3] != "Sphere5")
                {
                    animacion.SetInteger("touch", 6);
                    moveBall(name);
                    return true;
                }
            }
        }
        else if (returnBallIndex(name) == 3)
        {
            if (returnEmptySpace() == 2)
            {
                animacion.SetInteger("touch", 7);
                moveBall(name);
                return true;
            }
            else if (returnEmptySpace() == 1)
            {
                if (valores[2] != "Sphere4" && valores[2] != "Sphere5")
                {
                    animacion.SetInteger("touch", 8);
                    moveBall(name);
                    return true;
                }
            }
        }
        return false;
    }

    private void IsWinner()
    {
        if (valores[0].Equals("Sphere4") && valores[1].Equals("Sphere5") && valores[2].Equals("Sphere6") && 
            valores[4].Equals("Sphere1") && valores[5].Equals("Sphere2") && valores[6].Equals("Sphere3"))
        {
            ShowVictoryScreen();
        }
    }
    
    private void ShowVictoryScreen()
    {
        _victoryAnimator.SetBool("ShowVictory", true);
        audioFelicidades.Play();
    }

    public void actionToDo()
    {
        if (name.Equals("Sphere1"))
        {
            condition1B(name);
        }
        else if (name.Equals("Sphere2"))
        {
            condition2B(name);
        }
        else if (name.Equals("Sphere3"))
        {
            condition3B(name);
        }
        else if (name.Equals("Sphere4"))
        {
            condition4R(name);
        }
        else if (name.Equals("Sphere5"))
        {
            condition5R(name);
        }
        else if (name.Equals("Sphere6"))
        {
            condition6R(name);
        }
        IsWinner();
    }
}
