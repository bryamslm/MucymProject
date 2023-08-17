using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSquares : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager manager;

    void Start()
    {
        manager = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GameManager>();

        Vector3 euler = transform.eulerAngles;
        euler.z = 90 * Random.Range(0, 4);
        transform.eulerAngles = euler;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void rotate()
    {
        manager.clearEverything();
        clearAllChecks();
        this.transform.Rotate(0, 0, 90);
    }


    public void clearAllChecks()
    {
        foreach (Transform child in transform)
            child.GetComponent<ColorSephere>().checks.Clear();
    }
}

