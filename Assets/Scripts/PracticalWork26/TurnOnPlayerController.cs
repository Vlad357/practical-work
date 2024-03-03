using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class TurnOnPlayerController : MonoBehaviour
{
    private ThirdPersonController controller;

    public void TurnOnController()
    {
        controller.enabled = true;
    }

    public void TurnOffController()
    {
        controller.enabled = false;
    }
    
    private void Start()
    {
        controller = GetComponent<ThirdPersonController>();
        TurnOffController();
    }
}
