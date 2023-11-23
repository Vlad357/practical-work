using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject winPanel;
    public GameObject losePanel;

    public TextMeshProUGUI pin0;
    public TextMeshProUGUI pin1;
    public TextMeshProUGUI pin2;

    public Timer timer;

    public int winValue = 5;

    [SerializeField] private int pin0StartValue = 3;
    [SerializeField] private int pin1StartValue = 3;
    [SerializeField] private int pin2StartValue = 4;
    public void EndGameEvent(GameObject panel)
    {
        if (!panel.activeSelf)
        {
            panel.SetActive(true);
        }
    }

    public void RepeatGame(GameObject panel)
    {
        panel.SetActive(false);
        timer.ReloadTimer();
    }

    public void UseTool(int x, int y, int z)
    {
        GetInt RoundInt = (int a) => a <= 0 ? 0 : 10;

        int pinZero = Convert.ToInt32(pin0.text) + x;
        pin0.text = pinZero <= 0 || pinZero > 10? RoundInt(pinZero).ToString() : pinZero.ToString();

        int pinOne = Convert.ToInt32(pin1.text) + y;
        pin1.text = pinOne <= 0 || pinOne > 10 ? RoundInt(pinOne).ToString() : pinOne.ToString();

        int pinTwo = Convert.ToInt32(pin2.text) + z;
        pin2.text = pinTwo <= 0 || pinTwo > 10 ? RoundInt(pinTwo).ToString() : pinTwo.ToString() ;

        CheckPins();
    }

    private void CheckPins()
    {
        if(Convert.ToInt32(pin0.text) == winValue 
            && Convert.ToInt32(pin1.text) == winValue
            && Convert.ToInt32(pin2.text) == winValue)
        {
            EndGameEvent(winPanel);
        }
        else if(Convert.ToInt32(pin0.text) == 0
            || Convert.ToInt32(pin1.text) == 0
            || Convert.ToInt32(pin2.text) == 0)
        {
            EndGameEvent(losePanel);
        }
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = this; 
        }
        else if (instance == this)
        { 
            Destroy(gameObject); 
        }
        DontDestroyOnLoad(gameObject);
        Initialize();
    }

    private void Initialize()
    {
        pin0.text = pin0StartValue.ToString();
        pin1.text = pin1StartValue.ToString();
        pin2.text = pin2StartValue.ToString();
    }

    delegate int GetInt(int a);
}
