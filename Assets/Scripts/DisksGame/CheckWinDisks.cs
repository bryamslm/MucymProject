using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinDisks : MonoBehaviour
{
    public bool CheckIfDiskIsPlaced()
    {
        RaycastHit hitInfo;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, 4f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 4, Color.blue);
            if (hitInfo.transform.tag == "Disk")
                return true;
            else
                return false;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 4, Color.red);
            return false;
        }
    }
}
