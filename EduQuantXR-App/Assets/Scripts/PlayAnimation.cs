using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    private Animator _animator;
    public string AnimationToPlay;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _animator.Play(AnimationToPlay);
    }

}
