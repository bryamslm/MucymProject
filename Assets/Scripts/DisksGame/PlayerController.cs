using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject[] replacementDisks;
    
    private GameObject _diskSelected;

    private GameObject _diskReplace;

    public int moves;

    public int movesCount;

    private DisksGameManager _disksGM;
    private UI_Manager uiManager;

    private Outline _outline;

    private string[] _disksMoved;
    private int _diskUsedIndex;

    // Start is called before the first frame update
    void Start()
    {
        moves = 3;
        _disksGM = GameObject.Find("GameManager").GetComponent<DisksGameManager>();
        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        movesCount = 0;
        _disksMoved = new string[3];
        _diskUsedIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if(moves > 0)
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Mouse or touch position
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    //Debug.Log(hitInfo.transform.tag);
                    if (hitInfo.transform.tag == "Disk") //Select the disk to move
                    {
                        _diskSelected = hitInfo.transform.gameObject;

                        //Focus selected disk
                        //_outline = hitInfo.transform.gameObject.GetComponent<Outline>();
                        //_outline.enabled = true;

                        _disksGM.EnableReplacementDisks();
                        //When I begin to play I start the timer
                        uiManager.StartTimer();
                    }
                    if (_diskSelected != null && hitInfo.transform.tag == "DiskReplacement") //Select the new position for that disk
                    {
                        _diskReplace = hitInfo.transform.gameObject;
                        Vector3 auxPos = _diskSelected.transform.position;
                        _diskSelected.transform.position = _diskReplace.transform.position;
                        _diskReplace.transform.position = auxPos;
                        //After changing positions I'll add a move to the count
                        movesCount++;
                        //After changing the positions, I'll add this disk to the moved ones
                        if (!_disksMoved.Contains(_diskSelected.transform.name))
                        {
                            if (moves > 0 && _diskUsedIndex < 3)
                            {
                                _disksMoved[_diskUsedIndex] = _diskSelected.transform.name; //I add the disk name to the disks used
                                _diskUsedIndex++;
                            }
                        }
                        else //If it is in disksMoved, it means I am moving a piece I already moved before
                        {
                            moves++;
                        }
                        //_outline.enabled = false;
                        //_outline = null;
                        _diskSelected = null;
                        _diskReplace = null;
                        _disksGM.DisableReplacementDisks();

                        moves--;
                        uiManager.UpdateMoves(moves);
                    }
                }
            }
            else
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Mouse or touch position
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.transform.tag == "Disk") //Select the disk to move
                    {
                        if (_disksMoved.Contains(hitInfo.transform.name))
                        {
                            _diskSelected = hitInfo.transform.gameObject;

                            //Focus selected disk
                            _outline = hitInfo.transform.gameObject.GetComponent<Outline>();
                            _outline.enabled = true;

                            _disksGM.EnableReplacementDisks();
                            //When I begin to play I start the timer
                            uiManager.StartTimer();
                        }
                    }
                    if (_diskSelected != null && hitInfo.transform.tag == "DiskReplacement") //Select the new position for that disk
                    {
                        _diskReplace = hitInfo.transform.gameObject;
                        Vector3 auxPos = _diskSelected.transform.position;
                        _diskSelected.transform.position = _diskReplace.transform.position;
                        _diskReplace.transform.position = auxPos;
                        //After changing positions I'll add a move to the count
                        movesCount++;
                        //After changing the positions, I'll add this disk to the moved ones
                        //if (!_disksMoved.Contains(_diskSelected.transform.name))
                        //{
                        //    if (moves > 0 && _diskUsedIndex < 3)
                        //    {
                        //        _disksMoved[_diskUsedIndex] = _diskSelected.transform.name; //I add the disk name to the disks used
                        //        _diskUsedIndex++;
                        //    }
                        //}
                        //else //If it is in disksMoved, it means I am moving a piece I already moved before
                        //{
                        //    moves++;
                        //}
                        _outline.enabled = false;
                        _outline = null;
                        _diskSelected = null;
                        _diskReplace = null;
                        _disksGM.DisableReplacementDisks();

                        //moves--;
                        uiManager.UpdateMoves(0);
                    }
                }
            }
        }
        
    }

    public void ResetDisksData()
    {
        _disksMoved = new string[3];
        _diskUsedIndex = 0;
    }

}
