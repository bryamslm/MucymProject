using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage1 : MonoBehaviour
{
    public Sprite[] sprites;
    public Image imageRenderer;
    public static int selectNum = 0;
    public bool direction;

    public int getSelectNum()
    {
        return selectNum;
    }
    public void setSelectNum(int num)
    {
        selectNum = num;
    }

    public void changeNumber()
    {
        if (direction)
        {
            selectNum += 1;

            if (selectNum == 7)
            {
                selectNum = 0;
            }
        }
        else
        {
            if (selectNum != 0)
            {
                selectNum -= 1;
            }
            else if (selectNum == 0)
            {
                selectNum = 7;
            }
        }
        
        imageRenderer.sprite = sprites[selectNum];
    }
}
