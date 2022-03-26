using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureUpdater : MonoBehaviour
{

    public Renderer ToUpdateRenderer;

    public void UpdateTexture(Texture2D text)
    {
        ToUpdateRenderer.sharedMaterial.mainTexture = text;
    }
}
