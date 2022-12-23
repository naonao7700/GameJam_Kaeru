using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBar : MonoBehaviour
{
    [SerializeField] private float value;
    [SerializeField] private float max;
    [SerializeField] private Image image;

    [SerializeField] private bool maxFlag;  //ゲージが最大になったときにONになるフラグ
    [SerializeField] private bool zeroFlag; //ゲージが0になった時にONになるフラグ

    [SerializeField] private Color _color;

    //水位を上げることができるか取得する
    public bool CanUpFlag()
    {
        if (zeroFlag && !maxFlag) return false;
        return true;
    }

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

        if (value <= 0.0f) zeroFlag = true;
        if( value >= max )
        {
            maxFlag = true;
            zeroFlag = false;
        }
        else
        {
            maxFlag = false;
        }
    }

    public float GetRate()
    {
        return value / max;
    }

    private void Update()
    {
        if( zeroFlag && !maxFlag )
        {
            image.color = _color;
        }
        else
        {
            image.color = Color.white;
        }
    }
}
