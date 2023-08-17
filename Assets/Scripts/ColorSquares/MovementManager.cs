using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> selected = new List<GameObject>();

    private GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = this.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void addSelected(GameObject add)
    {

        if (selected.Count <= 2) {

            if (selected.Contains(add))
            {

                selected.Remove(add);
            }
            else
            {
                selected.Add(add);
            }
        }

        if(selected.Count == 2)
        {
            manager.clearEverything();
            Vector3 tempTrans = selected[0].transform.position;
            selected[0].transform.position = selected[1].transform.position;
            selected[1].transform.position = tempTrans;



            selected[0].GetComponent<LeanSelectableByFinger>().Deselect();
            selected[1].GetComponent<LeanSelectableByFinger>().Deselect();

            selected[0].GetComponent<MovementSquares>().clearAllChecks();
            selected[1].GetComponent<MovementSquares>().clearAllChecks();

            selected.RemoveAt(0);
            selected.RemoveAt(0);

        }

    }
   /* public void deleteunSelected(GameObject add)
    {
        Debug.Log("removed " + add.name);

        selected.Remove(add);
    }*/


}
