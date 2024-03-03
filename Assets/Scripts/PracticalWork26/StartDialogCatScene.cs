using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class StartDialogCatScene : MonoBehaviour
{
    public PlayableDirector catsceneTimeLine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<TurnOnPlayerController>().TurnOffController();
            catsceneTimeLine.Play();
            Animator animator = other.GetComponent<Animator>();
            animator.enabled = false;
            animator.enabled = true;
        }
    }
}
