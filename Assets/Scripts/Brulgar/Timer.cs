using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [SerializeField]private float _timeValue = 50f;
    [SerializeField]private float _time;
    private TextMeshProUGUI _timer;

    public void ReloadTimer()
    {
        _time = _timeValue;
    }

    private void Start()
    {
        _timer = GetComponent<TextMeshProUGUI>();
        GameManager.instance.timer = this;
        ReloadTimer();
    }

    private void Update()
    {
        CountDown();
    }
    
    private void CountDown()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime;
            _timer.text = Mathf.Round(_time).ToString();
        }
        else if( _time <= 0)
        {
            GameManager.instance.EndGameEvent(GameManager.instance.losePanel);
        }
    }

}
