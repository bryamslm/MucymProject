using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject[] spheres;
    [SerializeField]
    private Canvas canvas;
    private UI_Manager4E uiManager;


    public bool playerWon = false;
    // Start is called before the first frame update
    void Start()
    {
         spheres = GameObject.FindGameObjectsWithTag("PuzzlePiece");
        uiManager = canvas.GetComponent<UI_Manager4E>();
        uiManager.HideVictoryScreen();
        uiManager.StartTimer();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerWon)
        {
            endGame();
        }
    }
    public void clearEverything()
    {
        foreach (GameObject sphere in spheres)
        {
            sphere.GetComponent<ColorSephere>().clear();
        }

        checkALL();
        
    }


    public void checkALL()
    {
        bool won = false;
        foreach (GameObject sphere in spheres)
        {

            List<bool> checks = sphere.GetComponent<ColorSephere>().checks;
            foreach (bool check in checks)
            {
                won = check;

                if (!won)
                {
                    break;
                }

            }
            
        }
        playerWon = won;

    }
    private void endGame()
    {
        uiManager.StopTimer();
        uiManager.ShowVictoryScreen();

    }
    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
