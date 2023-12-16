using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnimationController : MonoBehaviour
{
    private Animator _animator;

    public void SwitchAnimtaion()
    {
        _animator.SetInteger("random animation", Random.Range(0, 2));
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
