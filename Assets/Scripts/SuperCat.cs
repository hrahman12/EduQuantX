using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCat : MonoBehaviour
{

    public float Frequency = 60F;

    public Renderer Renderer;

    public Texture2D[] SwitchingTextures;

    private int _idx = 0;
    private float _lastSwitched = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _lastSwitched > (1f / Frequency))
        {
            if (_idx >= SwitchingTextures.Length)
            {
                _idx = 0;
            }
            Renderer.sharedMaterial.mainTexture = SwitchingTextures[_idx++];
            _lastSwitched = Time.time;
        }
    }
}
