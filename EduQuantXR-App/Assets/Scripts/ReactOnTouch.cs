using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReactOnTouch : MonoBehaviour
{

    private AudioSource _audio;

    public UnityEvent RequestTwoQubits;

    public OperatorControl Operator { get; internal set; }
    public LineRenderer Line { get; internal set; }
    public int LinePos { get; internal set; }

    private void OnTriggerEnter(Collider other)
    {
        if (Operator) return;
        if (!other.GetComponent<OperatorControl>()) return;
        _audio.Play();
        other.GetComponent<OperatorControl>().CurrentPos = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    internal void DoTwoQubits()
    {
        RequestTwoQubits?.Invoke();
    }
}
