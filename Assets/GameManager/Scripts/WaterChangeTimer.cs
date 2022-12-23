using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//水位変更のクールタイム設定
public class WaterChangeTimer : MonoBehaviour
{
    [SerializeField] private Image barimage;    //ゲージ画像
    [SerializeField] private GameObject okImage;     //OK画像

    [SerializeField] private Timer timer;

    public bool GetChangeFlag()
	{
        return timer.IsEnd();
	}

	public void ResetTimer()
	{
        timer.Reset();
        okImage.SetActive(false);
        barimage.fillAmount = timer.GetRate();
	}

    public void DoUpdate( float deltaTime )
	{
        timer.DoUpdate(Time.deltaTime);
        barimage.fillAmount = timer.GetRate();
        if (timer.IsEnd())
        {
            okImage.SetActive(true);
        }
    }
}
