using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ManagerMagicSquare : MonoBehaviour
{
    public Text timerLabel;
    public float time;
    public bool startTimer;

    public GameObject tipPanel;

    public Animator _victoryAnimator;

    private Animator _tipAnimator;

    void Start()
    {
        timerLabel.text = "Tiempo\n0:00";
        _tipAnimator = tipPanel.GetComponent<Animator>();
        tipPanel.SetActive(false);
    }

    void Update()
    {
        if (startTimer)
        {
            CalculateTime();
        }
    }

    void CalculateTime()
    {
        time += Time.deltaTime;
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        string timer = "Tiempo\n " + minutes.ToString() + ":" + seconds.ToString().PadLeft(2, '0');
        timerLabel.text = timer;
    }

    public void StartTimer()
    {
        startTimer = true;
    }

    public void StopTimer()
    {
        startTimer = false;
        //time = 0;
    }

    public void ResetTimer()
    {
        timerLabel.text = "Tiempo\n0:00";
        time = 0;
    }

    public void ShowVictoryScreen()
    {
        _victoryAnimator.SetBool("ShowVictory", true);
    }

    public void HideVictoryScreen()
    {
        _victoryAnimator.SetBool("ShowVictory", false);
    }

    public void ActivateTip()
    {
        tipPanel.SetActive(true);
        AudioSource asTip = tipPanel.GetComponent<AudioSource>();
        asTip.Play();
    }

    public void ShowTip()
    {
        _tipAnimator.SetBool("ShowTip", true);
    }

    public void HideTip()
    {
        _tipAnimator.SetBool("ShowTip", false);
    }


}
