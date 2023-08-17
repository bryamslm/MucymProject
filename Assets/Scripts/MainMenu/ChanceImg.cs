using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChanceImg : MonoBehaviour
{
    public Button button;
    public Sprite myFirstImage;
    public Sprite mySecondImage;
    public AudioSource audioMain;
    private bool substract = false; 

    // Start is called before the first frame update
    public void changeNumber()
    {
        if (substract) {
            button.image.sprite = myFirstImage;
            substract = false;
            audioMain.Play();
        } else {
            button.image.sprite = mySecondImage;
            substract = true;
            audioMain.Stop();
        }
    }
}
