using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSquareGameManager : MonoBehaviour
{
    public GameObject[] replacementNumbers;

    private int[,] _numbers; 

    private UI_ManagerMagicSquare _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        DisableReplacementNumbers();
        _numbers = new int[3, 3];
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_ManagerMagicSquare>();
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
        bool checkColumnSum, checkRowSum, checkDiagonalSum, checkAntiDiagonalSum;
        checkColumnSum = false;
        checkRowSum = false;
        checkDiagonalSum = false;
        checkAntiDiagonalSum = false;
        /*
        int sumRows = 0;
        int sumColumns = 0;
        int sumDiagonal = 0;
        int sumAntiDiagonal = 0;
        */
        GameObject[] nums = GameObject.FindGameObjectsWithTag("Number");
        int size = nums.Length;

        for (int i = 0; i < nums.Length; i++)
        {
            OptionsNumbers numScript = nums[i].GetComponent<OptionsNumbers>();
            //Debug.Log("[" + numScript.row + "," + numScript.col + "] = " + numScript.value);

            if (numScript.row != 4 && numScript.col != 4)
            {
                if (numScript.value == 0) //If there are still clean pieces on the evaluation board: row -> 0,1,2 or col -> 0,1,2
                    return false;
                else
                    _numbers[numScript.row, numScript.col] = numScript.value; //Load the value of the piece on it's current position 
            }
        }

        if ((_numbers[0, 0] + _numbers[0, 1] + _numbers[0, 2]) == 15)
        {
            if ((_numbers[1, 0] + _numbers[1, 1] + _numbers[1, 2]) == 15)
            {
                if ((_numbers[2, 0] + _numbers[2, 1] + _numbers[2, 2]) == 15)
                {
                    checkRowSum = true;
                }
      
            }
        }

        if ((_numbers[0, 0] + _numbers[1, 0] + _numbers[2, 0]) == 15)
        {
            if ((_numbers[0, 1] + _numbers[1, 1] + _numbers[2, 1]) == 15)
            {
                if ((_numbers[0, 2] + _numbers[1, 2] + _numbers[2, 2]) == 15)
                {
                    checkColumnSum = true;
                }
            }
        }

        if ((_numbers[0, 0] + _numbers[1, 1] + _numbers[2, 2]) == 15)
        {
            checkDiagonalSum = true;
        }

        if ((_numbers[0, 2] + _numbers[1, 1] + _numbers[2, 0] )== 15)
        {
            checkAntiDiagonalSum = true;
        }

   
            return checkColumnSum && checkRowSum && checkDiagonalSum && checkAntiDiagonalSum;
    }

    public void CheckLastMovement()
    {
        if (CheckIfWin())
        {
            _uiManager.ShowVictoryScreen();
            _uiManager.StopTimer();
        }
            
    }

    public void RestartGame()
    {
        _uiManager.HideVictoryScreen();
        EnableReplacementNumbers();
        GameObject[] nums = GameObject.FindGameObjectsWithTag("Number");
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i].GetComponent<OptionsNumbers>().ResetPosition();
        }
        DisableReplacementNumbers();

        _uiManager.ResetTimer();
    }
}
