using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandleTooltip : MonoBehaviour
{
    public float TooltipTime = 15f;

    private static List<string> _shownTooltips = new List<string>();

    public UnityEvent ShowTooltip;

    public UnityEvent HideTooltip;

    public void Grabbing()
    {
        if (_shownTooltips.Contains(gameObject.name))
        {
            return;
        }
        _shownTooltips.Add(gameObject.name);
        Invoke(nameof(ShowingTooltip), 0.5F);
    }

    private void ShowingTooltip()
    {
        ShowTooltip.Invoke();
        Invoke(nameof(StopTooltip), TooltipTime);
    }

    private void StopTooltip()
    {
        HideTooltip.Invoke();
    }

}
