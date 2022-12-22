using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//é_ëfÉQÅ[ÉW
public class OxygenBar : MonoBehaviour
{
    [SerializeField] private float value;
    [SerializeField] private float max;

    [SerializeField] private Image image;

    public float GetValue()
    {
        return value;
    }

    public void SetValue( float value )
    {
        if (value < 0) value = 0;
        else if (value > max) value = max;
        this.value = value;

        image.fillAmount = this.value / max;
    }

    public void AddValue( float value )
    {
        SetValue(this.value + value);
    }
}
