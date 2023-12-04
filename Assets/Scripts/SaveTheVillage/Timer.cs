using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public UnityEvent eventOnCoolDown;
    public CheckRule ruleTimer;

    public bool isButtonTimer = false;

    private bool isEnd = true;
    private Image sprite;

    [SerializeField] private float totalTime;
    [SerializeField] private float currentTime;

    public void ReloadTimer()
    {
        if (isEnd)
        {
            if (isButtonTimer && Convert.ToInt32(GameManager.Instance.eatCounter.text) <= 0)
                return;
            else if(isButtonTimer && Convert.ToInt32(GameManager.Instance.eatCounter.text) >= 0)
            {
                GameManager.Instance.EatCount = Convert.ToInt32(GameManager.Instance.eatCounter.text) - 1;
            }
            currentTime = totalTime;
            isEnd = false;
        }
    }

    private void Update()
    {
        if(currentTime <= 0)
        {
            sprite.fillAmount = 1;
            if(!isEnd)eventOnCoolDown?.Invoke();
            isEnd = true;
            if (!isButtonTimer && ruleTimer != null && ruleTimer())
            {
                ReloadTimer();
            }
        }
        else
        {
            currentTime -= Time.deltaTime;
            sprite.fillAmount = currentTime / totalTime;
        }
    }

    private void Start()
    {
        sprite = GetComponent<Image>();
        if (ruleTimer.IsUnityNull())
        {
            ruleTimer = () => true;
        }
    }
}

public delegate bool CheckRule();