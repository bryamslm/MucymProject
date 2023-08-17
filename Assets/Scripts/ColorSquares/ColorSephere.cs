using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSephere : MonoBehaviour
{
    public Material type;
    public List<bool> checks =  new List<bool>();
    // Start is called before the first frame update
    void Start()
    {
        type = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clear()
    {
        checks = new List<bool>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "PuzzlePiece" && other.GetType() == typeof(SphereCollider))
        {
            if (type.ToString() == other.gameObject.GetComponent<ColorSephere>().type.ToString())
            {
                checks.Add(true);
            }
            else
            {
                checks.Add(false);

            }

        }

    }
}
