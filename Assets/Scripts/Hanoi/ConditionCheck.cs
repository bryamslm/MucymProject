using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionCheck : MonoBehaviour
{
    private void FixedUpdate()
    {
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 0.17f, Color.green);
    }

    public bool CheckCondition(int diskSize)
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 0.04f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            Debug.Log(hit.transform.tag);
            if (hit.transform.tag == "PuzzlePiece")
                return true;
            if (hit.transform.tag == "Disk")
            {
                //Get number of the disk on bottom
                int bottomSize = hit.transform.gameObject.GetComponent<HanoiDisk>().size;
                if (diskSize < bottomSize)
                { //Disk in bottom is bigger = correct
                    Debug.Log("True");
                    return true;
                }
                else
                {
                    return false; //Disk in bottom is smaller = incorrect

                    Debug.Log("False1");
                }
            }
            else
            {
                Debug.Log("False2");
                return false;

            }
        }
        else
        {
            Debug.Log("False3");
            return false;

        }
    }

    public bool CheckUp()
    {
        RaycastHit hit;

        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, 0.17f)) //If there is  nothing upside the piece, then you can move
            return true;
        else
            return false; //If there is another piece on top, you can't move that one
    }

    public bool CheckHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 0.028f))
            return true;
        else
            return false;
            
    }

    //This was a method to debug and test CheckUp
    void ASD()
    {
        RaycastHit hit;

        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, 0.17f)) //If there is  nothing upside the piece, then you can move
            Debug.Log("Libre: " + transform.parent.transform.name);
        else
            Debug.Log("Nel " + transform.parent.transform.name + "hitted: " + hit.transform.name);
    }
}
