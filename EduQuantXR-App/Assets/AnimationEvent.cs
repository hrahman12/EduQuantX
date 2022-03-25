using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{

    public UnityEvent[] AnimationEvents;

    public void ThrowAnimationEvent(int i)
    {
        if (AnimationEvents.Length <= i || i < 0)
        {
            Debug.LogError("AnimationEvent not specified");
            return;
        }
        AnimationEvents[i]?.Invoke();
    }
}
