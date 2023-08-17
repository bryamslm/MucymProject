using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField]    private List<GameObject> pieces;
    [SerializeField] private Collider coll;
    private UI_Manager4E _uiManager4E;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager4E = GameObject.Find("Canvas").GetComponent<UI_Manager4E>();
        _uiManager4E.StartTimer();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(!(pieces.Contains(other.gameObject)) && FullyContains(other, coll))
        {
            pieces.Add(other.gameObject);

        }
        else if((pieces.Contains(other.gameObject)) && !FullyContains(other, coll))
        {
            pieces.Remove(other.gameObject);
        }
        if (pieces.Count == 4) {
            _uiManager4E.ShowVictoryScreen();
            _uiManager4E.StopTimer();
        }

    }


    bool FullyContains(Collider resident,Collider zone)
    {
        if (zone == null)
        {
            return false;
        }
        return zone.bounds.Contains(resident.bounds.max) && zone.bounds.Contains(resident.bounds.min) && zone.bounds.Contains(resident.bounds.center);
    }

}
