using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayedEvent : MonoBehaviour
{
    public float DelayInSeconds = 60f;

    public UnityEvent Event;

    private void OnEnable()
    {
        Invoke(nameof(ThrowEvent), DelayInSeconds);
    }

    private void ThrowEvent()
    {
        Event?.Invoke();
    }
}
