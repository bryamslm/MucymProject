using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoiGameManager : MonoBehaviour
{
    //Column one is the one with the disks at the begining
    public WinCondition[] columnTwo;
    public WinCondition[] columnThree;

    [HideInInspector]
    public int movements;

    private HanoiUI_Manager _uiManager;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<HanoiUI_Manager>();
        movements = 0;
        _uiManager.UpdateMoves(movements);
    }

    public void StartTimer()
    {
        _uiManager.StartTimer();
    }

    public void CheckIfWin()
    {
        //Check column two
        bool condition = true;
        for (int i = 0; i < columnTwo.Length; i++)
        {
            if(!columnTwo[i].CheckWinCondition())
            {
                condition = false;
                break;
            }
        }
        if (condition)
        {
            Debug.Log("Se gano en la segunda columna");
            _uiManager.StopTimer();
            _uiManager.ShowVictoryScreen();
            return;
        }

        //Check column three
        bool condition2 = true;
        for (int i = 0; i < columnThree.Length; i++)
        {
            if (!columnThree[i].CheckWinCondition())
            {
                condition2 = false;
                break;
            }
        }
        if (condition2)
        {
            _uiManager.StopTimer();
            _uiManager.ShowVictoryScreen();
            Debug.Log("Se gano en la tercera columna");
            return;
        }
    }

    public void RestartGame()
    {
        movements = 0;
        _uiManager.UpdateMoves(movements);
        _uiManager.ResetTimer();
        GameObject[] disks = GameObject.FindGameObjectsWithTag("Disk");
        for (int i = 0; i < disks.Length; i++)
        {
            HanoiDisk disk = disks[i].GetComponent<HanoiDisk>();
            disk.ResetPosition();
        }
        _uiManager.HideVictoryScreen();
    }

    public void AddMovement()
    {
        movements++;
        _uiManager.UpdateMoves(movements);
    }

    //Este tengo que preguntar todavia :V
    public void RemoveMovement()
    {
        movements--;
        _uiManager.UpdateMoves(movements);
    }
}
