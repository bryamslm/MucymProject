using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMenu : MonoBehaviour
{
    // Start is called before the first frame update+
    [SerializeField]
    private RectTransform mainMenu;
    private RectTransform  otherMenu;
    private RectTransform targetMove;
    [SerializeField]
    private RectTransform offScreen;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //float step = 4 * Time.deltaTime;

        if (otherMenu != null) { 
        otherMenu.position = Vector3.MoveTowards(otherMenu.position, targetMove.position, 10);
        }

    }
    public void moveToScreen(RectTransform movingRect)
    {
        targetMove = mainMenu;
        otherMenu = movingRect;
    }
    public void goBack(RectTransform target)
    {
        targetMove = offScreen;

        otherMenu = target;
    }
}
