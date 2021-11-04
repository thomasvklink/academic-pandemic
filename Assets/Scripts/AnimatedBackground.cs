using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedBackground : MonoBehaviour
{
    public bool enable = true;
    public float ScrollX = 0.5f;
    public float ScrollY = 0.5f;

    void Update()
    {
        if (enable)
        {
            float OffsetX = Time.time * ScrollX;
            float OffsetY = Time.time * ScrollY;
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
        }
        
    }

    public void Toggle()
    {
        if(enable)
        {
            enable = false;
        } else 
        {
            enable = true;
        }
    }
}
