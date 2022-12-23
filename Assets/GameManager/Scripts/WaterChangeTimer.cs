using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���ʕύX�̃N�[���^�C���ݒ�
public class WaterChangeTimer : MonoBehaviour
{
    [SerializeField] private Image barimage;    //�Q�[�W�摜
    [SerializeField] private GameObject okImage;     //OK�摜

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
