using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DiskBehavior : MonoBehaviour
{
    private Vector3 _originalPosition;
    private Outline _outline;
    
    // Start is called before the first frame update
    void Start()
    {
        _originalPosition = transform.localPosition;
        if(transform.tag == "Disk")
        {
           // _outline = GetComponent<Outline>();
           // _outline.enabled = false;
        }
        
    }

    public void ResetPosition()
    {
        transform.localPosition = _originalPosition;
    }
}
