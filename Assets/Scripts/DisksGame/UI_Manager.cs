using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UI_Manager : MonoBehaviour
{
    public Text movementsLabel;

    public Text attemptsLabel;

    public Text timerLabel;
    public float time;
    public bool startTimer;

    public GameObject losePanel;

    public GameObject tipPanel;
    public Text tipLabel;
    public GameObject nextTipBtn;

    private string[] _tips;
    private int _tipIndex;

    private DisksGameManager _diskGM;

    private Animator _victoryAnimator;

    private Animator _tipAnimator;

    // Start is called before the first frame update
    void Start()
    {
        movementsLabel.text = "Movimientos\nrestantes\n3";
        attemptsLabel.text = "";
        timerLabel.text = "Tiempo\n0:00";
        losePanel.SetActive(false);
        _diskGM = GameObject.Find("GameManager").GetComponent<DisksGameManager>();
        _victoryAnimator = GameObject.Find("VictoryPanel").GetComponent<Animator>();
        _tipAnimator = tipPanel.GetComponent<Animator>();
        FillTipsArray();
        nextTipBtn.SetActive(false);
        _tipIndex = 1;
        tipPanel.SetActive(false);
    }

    private void Update()
    {
        if (startTimer)
        {
            CalculateTime();
        }
    }

    private void FillTipsArray()
    {
        _tips = new string[2];
        _tips[0] = "¡No muevas la pieza del centro!\nY prueba observar unos segundos la figura antes de mover";
        _tips[1] = "Prueba mover primero una esquina";
        tipLabel.text = _tips[0];
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

    public void UpdateMoves(int moves)
    {
        if (moves == 0)
            StartCoroutine(CheckIfWin());

        movementsLabel.text = "Movimientos\nrestantes\n" + moves.ToString();
    }

    public void ShowMessage()
    {
        losePanel.SetActive(true);
    }

    public void ShowVictoryScreen()
    {
        //Debug.Log("YOU WON!");
        _victoryAnimator.SetBool("ShowVictory",true);
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
        //Handheld.Vibrate();
    }

    public void ShowTip()
    {
        _tipAnimator.SetBool("ShowTip", true);
    }

    public void ShowSecondTip()
    {
        _tipAnimator.SetTrigger("TipAnimation");
        nextTipBtn.SetActive(true);
        tipLabel.text = _tips[1];
        AudioSource asTip = tipPanel.GetComponent<AudioSource>();
        asTip.Play();
        //Handheld.Vibrate();
    }

    public void ShowNextTip()
    {
        _tipIndex++;
        if (_tipIndex == _tips.Length)
            _tipIndex = 0;
        tipLabel.text = _tips[_tipIndex];
    }

    public void HideTip()
    {
        _tipAnimator.SetBool("ShowTip", false);
    }

    private IEnumerator CheckIfWin()
    {
        yield return new WaitForSeconds(0.2f);
        _diskGM.CheckIfWin();
    }

    public void ShowMovements(int movesUsed)
    {
        movementsLabel.text = "Total de movimientos usados:\n" + movesUsed.ToString();
    }

    public void ShowAttempts(int attempts)
    {
        attemptsLabel.text = "Intentos:\n" + attempts.ToString();
    }

    public void HideAttempts()
    {
        attemptsLabel.text = "";
    }
}
