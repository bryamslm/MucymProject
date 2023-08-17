using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public int expectedValue;

    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1f, Color.yellow);
    }

    public bool CheckWinCondition()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1f))
        {
            if (hit.transform.tag == "Disk")
            {
                //Get number of the disk on bottom
                int diskSize = hit.transform.gameObject.GetComponent<HanoiDisk>().size;
                if (diskSize == expectedValue) //Disk in front is the one expected. game is complete
                    return true;
                else
                    return false; //Disk in front is not the expected disk
            }
            else
                return false; //No disk in this position
        }
        else
            return false; //Hit nothing at all
    }
}
