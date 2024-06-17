using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClick : MonoBehaviour
{
    public ClickManager clickManager;
    public float rangeTime;
    public float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= rangeTime)
        {
            timer = 0;
            clickManager.OnClick();
        }
    }
}
