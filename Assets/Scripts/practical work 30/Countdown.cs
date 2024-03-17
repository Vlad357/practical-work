using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Countdown : MonoBehaviour
{
    public UnityEvent CountdownAction;
    public TextMeshProUGUI countdownText;
    
    private float _countdownTime;
    [SerializeField] private float coundownValue;

    private void Start()
    {
        Restart();
    }

    private void Update()
    {
        CountdownTimer();
    }

    private void Restart()
    {
        _countdownTime = coundownValue;
    }

    private void CountdownTimer()
    {
        if(_countdownTime < 0) return;
        
        _countdownTime -= Time.deltaTime;
        countdownText.text = Mathf.Round(_countdownTime).ToString();
        if (_countdownTime <= 0)
        {
            CountdownAction?.Invoke();
        }
    }
}
