using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisksGameManager : MonoBehaviour
{
    public GameObject[] replacementDisks;

    public GameObject[] winChecks;

    public int attempts;

    private bool[] disksPlaced;

    private GameObject[] disks;

    private PlayerController playerController;

    private UI_Manager uiManager;


    // Start is called before the first frame update
    void Start()
    {
        //Place the screen in correct position
        Screen.orientation = ScreenOrientation.LandscapeLeft;//or right for right landscape

        disks = GameObject.FindGameObjectsWithTag("Disk");
        DisableReplacementDisks();
        playerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        uiManager.HideVictoryScreen();

        disksPlaced = new bool[6];
        disksPlaced[0] = false;
        disksPlaced[1] = false;
        disksPlaced[2] = false;
        disksPlaced[3] = true;
        disksPlaced[4] = true;
        disksPlaced[5] = true;


        attempts = 1;
    }

    public void DisableReplacementDisks()
    {
        for (int i = 0; i < replacementDisks.Length; i++)
        {
            replacementDisks[i].SetActive(false);
        }
    }

    public void EnableReplacementDisks()
    {
        for (int i = 0; i < replacementDisks.Length; i++)
        {
            replacementDisks[i].SetActive(true);
        }
    }

    public void RestartGame()
    {
        uiManager.HideVictoryScreen();

        //Restart disks positions
        for (int i = 0; i < replacementDisks.Length; i++)
        {
            DiskBehavior diskBeh = replacementDisks[i].GetComponent<DiskBehavior>();
            diskBeh.ResetPosition();
        }
        for (int i = 0; i < disks.Length; i++)
        {
            DiskBehavior diskBeh = disks[i].GetComponent<DiskBehavior>();
            diskBeh.ResetPosition();
        }

        disksPlaced[0] = false;
        disksPlaced[1] = false;
        disksPlaced[2] = false;
        disksPlaced[3] = true;
        disksPlaced[4] = true;
        disksPlaced[5] = true;

        //Restart player turns
        playerController.moves = 3;
        playerController.movesCount = 0;
        playerController.ResetDisksData();
        uiManager.UpdateMoves(playerController.moves);
        uiManager.losePanel.SetActive(false);
        uiManager.StopTimer();
        uiManager.ResetTimer();
        uiManager.HideAttempts();

        this.attempts++;

        if (attempts == 6)
            uiManager.ActivateTip();
        if (attempts == 10)
            uiManager.ShowSecondTip();
    }

    public void CheckIfWin()
    {
        for (int i = 0; i < winChecks.Length; i++)
        {
            CheckWinDisks check = winChecks[i].GetComponent<CheckWinDisks>();
            disksPlaced[i] = check.CheckIfDiskIsPlaced();
        }

        if(disksPlaced[0] && disksPlaced[1] && disksPlaced[2] && !disksPlaced[3] && !disksPlaced[4] && !disksPlaced[5]) //If the three disks are actually in the respective places
        {
            uiManager.StopTimer();
            uiManager.ShowVictoryScreen();
            uiManager.ShowMovements(playerController.movesCount);
            uiManager.ShowAttempts(attempts);
        }
        else if (playerController.moves == 0)
        {
            uiManager.ShowMessage();
        }
    }
}
