using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourEquationsGameManager : MonoBehaviour
{
    public GameObject[] replacementNumbers;

    private int[,] _numbers; 

    private UI_Manager4E _uiManager4E;

    // Start is called before the first frame update
    void Start()
    {
        DisableReplacementNumbers();
        _numbers = new int[3, 3];

        _uiManager4E = GameObject.Find("Canvas").GetComponent<UI_Manager4E>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableReplacementNumbers()
    {
        for (int i = 0; i < replacementNumbers.Length; i++)
        {
            replacementNumbers[i].SetActive(false);
        }
    }

    public void EnableReplacementNumbers()
    {
        for (int i = 0; i < replacementNumbers.Length; i++)
        {
            replacementNumbers[i].SetActive(true);
        }
    }

    private bool CheckIfWin()
    {
        bool condition1, condition2, condition3, condition4;
        condition1 = false;
        condition2 = false;
        condition3 = false;
        condition4 = false;

        GameObject[] nums = GameObject.FindGameObjectsWithTag("Number");
        for (int i = 0; i < nums.Length; i++)
        {
            Numbers numScript = nums[i].GetComponent<Numbers>();
            //Debug.Log("[" + numScript.row + "," + numScript.col + "] = " + numScript.value);

            if (numScript.row != 4 && numScript.col != 4)
            {
                if (numScript.value == 0) //If there are still clean pieces on the evaluation board: row -> 0,1,2 or col -> 0,1,2
                    return false;
                else
                    _numbers[numScript.row, numScript.col] = numScript.value; //Load the value of the piece on it's current position 
            }
        }

        if (_numbers[0, 0] - _numbers[0, 1] == _numbers[0, 2])
            condition1 = true;
        if (_numbers[1, 1] == 0) //Trying to avoid division by zero
            condition2 = false;
        else if (_numbers[1, 0] / _numbers[1, 1] == _numbers[1, 2])
            condition2 = true;
        if (_numbers[2, 0] + _numbers[2, 1] == _numbers[2, 2])
            condition3 = true;
        if (_numbers[0, 2] * _numbers[1, 2] == _numbers[2, 2])
            condition4 = true;

        return condition1 && condition2 && condition3 && condition4;
    }

    public void CheckLastMovement()
    {
        if (CheckIfWin())
        {
            _uiManager4E.ShowVictoryScreen();
            _uiManager4E.StopTimer();
        }
            
    }

    public void RestartGame()
    {
        _uiManager4E.HideVictoryScreen();
        EnableReplacementNumbers();
        GameObject[] nums = GameObject.FindGameObjectsWithTag("Number");
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i].GetComponent<Numbers>().ResetPosition();
        }
        DisableReplacementNumbers();

        _uiManager4E.ResetTimer();
    }
}
