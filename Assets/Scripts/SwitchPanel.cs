using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPanel : MonoBehaviour
{
    public GameObject calculator;
    public GameObject comparison;
    public GameObject currentState;
    private void Start()
    {
        calculator.SetActive(true);
        currentState = calculator;
    }

    public void SwitchState(GameObject state)
    {
        currentState.SetActive(false);
        state.SetActive(true);
        currentState = state;
    }
}
