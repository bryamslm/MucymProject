using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerMagicSquare : MonoBehaviour
{
    private GameObject _numberSelected;

    private GameObject _numberReplace;

    public int movesCount;

    private MagicSquareGameManager _gameManager;
    private UI_ManagerMagicSquare _uiManager;

    private Outline _outline;

    // Start is called before the first frame update
    void Start()
    {
        movesCount = 0;
        _gameManager = GameObject.Find("GameManager").GetComponent<MagicSquareGameManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_ManagerMagicSquare>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Mouse or touch position
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (_numberSelected == null && hitInfo.transform.tag == "Number") //Select the disk to move
                {
                    
                    _numberSelected = hitInfo.transform.gameObject;
                    //Focus selected disk
                    _outline = hitInfo.transform.gameObject.GetComponent<Outline>();
                    _outline.enabled = true;

                    _gameManager.EnableReplacementNumbers();
                    //When I begin to play I start the timer
                    _uiManager.StartTimer();
                }
                else if (_numberSelected != null && hitInfo.transform.tag == "Number")
                {
                    _numberReplace = hitInfo.transform.gameObject;
                    Vector3 auxPos = _numberSelected.transform.position;
                    _numberSelected.transform.position = _numberReplace.transform.position;
                    _numberReplace.transform.position = auxPos;

                    //Logic to change values within pieces
                    OptionsNumbers num1 = _numberSelected.GetComponent<OptionsNumbers>();
                    OptionsNumbers num2 = _numberReplace.GetComponent<OptionsNumbers>();
                    int auxRow = num1.row;
                    int auxCol = num1.col;

                    num1.row = num2.row;
                    num1.col = num2.col;
                    num2.row = auxRow;
                    num2.col = auxCol;

                    //After changing positions I'll add a move to the count
                    movesCount++;

                    //Check if win after each move
                    _gameManager.CheckLastMovement();

                    _outline.enabled = false;
                    _outline = null;
                    _numberSelected = null;
                    _numberReplace = null;
                    _gameManager.DisableReplacementNumbers();
                }
            }
        }
    }
}
