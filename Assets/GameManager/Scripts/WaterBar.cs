using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBar : MonoBehaviour
{
    [SerializeField] private float value;
    [SerializeField] private float max;
    [SerializeField] private Image image;

    public void SetRate( float rate )
    {
        value = max * rate;
        image.fillAmount = GetRate();
    }

    public void AddValue( float v )
    {
        value += v;
        if (value < 0) value = 0;
        if (value > max) value = max;
        image.fillAmount = GetRate();
    }

    public float GetRate()
    {
        return value / max;
    }
}
