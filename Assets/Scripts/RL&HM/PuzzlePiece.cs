using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
        LeanSelectableByFinger selectable;
        Rigidbody rb;
        void Start()
        {
        selectable = GetComponent<LeanSelectableByFinger>();
        rb = transform.GetComponent<Rigidbody>();

    }

    void Update()
    {
        //transform.rotation = _plane.transform.rotation;  
        if (!selectable.IsSelected)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {

        }
    }







}
