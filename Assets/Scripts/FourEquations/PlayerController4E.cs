using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController4E : MonoBehaviour
{
    private GameObject _numberSelected;

    private GameObject _numberReplace;

    public int movesCount;

    private FourEquationsGameManager _FourEquationsGM;
    private UI_Manager4E _uiManager;

    private Outline _outline;

    // Start is called before the first frame update
    void Start()
    {
        movesCount = 0;
        _FourEquationsGM = GameObject.Find("GameManager").GetComponent<FourEquationsGameManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager4E>();
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

                    _FourEquationsGM.EnableReplacementNumbers();
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
                    Numbers num1 = _numberSelected.GetComponent<Numbers>();
                    Numbers num2 = _numberReplace.GetComponent<Numbers>();
                    int auxRow = num1.row;
                    int auxCol = num1.col;

                    num1.row = num2.row;
                    num1.col = num2.col;
                    num2.row = auxRow;
                    num2.col = auxCol;

                    //After changing positions I'll add a move to the count
                    movesCount++;

                    //Check if win after each move
                    _FourEquationsGM.CheckLastMovement();

                    _outline.enabled = false;
                    _outline = null;
                    _numberSelected = null;
                    _numberReplace = null;
                    _FourEquationsGM.DisableReplacementNumbers();
                }
            }
        }
    }
}
