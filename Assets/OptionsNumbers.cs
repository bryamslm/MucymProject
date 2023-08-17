using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsNumbers : MonoBehaviour
{
    public int value; //The number on the piece
    public int row = 4; //0 to 3 are the positions on the game board          
    public int col = 4;

    private int _originalRow;
    private int _originalColumn;

    private Vector3 _originalPosition;

    private void Start()
    {
        _originalPosition = transform.localPosition;
        _originalRow = row;
        _originalColumn = col;
    }

    public void ResetPosition()
    {
        transform.localPosition = _originalPosition;
        row = _originalRow;
        col = _originalColumn;
    }
}
