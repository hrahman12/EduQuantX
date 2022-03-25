using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;
using UnityEngine.Events;

public class QubitConnector : MonoBehaviour
{
    public Transform LineRoot;

    public Renderer Sphere;

    public void ChangeColor(Color clr)
    {
        var mixedRealityLineRenderer = GetComponent<MixedRealityLineRenderer>();
        for (var i = 0; i < mixedRealityLineRenderer.LineColor.colorKeys.Length; i++)
        {
            mixedRealityLineRenderer.LineColor.colorKeys[i] = new GradientColorKey { color = clr, time = mixedRealityLineRenderer.LineColor.colorKeys[i].time };
        }
        Sphere.material.color = clr;
    }

}
