using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�Q�[���𑍍��I�ɊǗ�����N���X
//��Ɉ�����̂��̂�����
public class GameManager : MonoBehaviour
{
    private static GameManager gameManager; //�V���O���g���ɂ���

    [SerializeField] private OxygenBar oxygenBar;   //�_�f�Q�[�W
    [SerializeField] private GameTimer gameTimer;    //�Q�[���^�C�}�[
    [SerializeField] private Water water;   //��

    private float timer;
    private bool waterFlag;

    //�����t���O���擾����
    public static bool GetWaterFlag()
    {
        return gameManager.waterFlag;
    }

    //�����ɐ؂�ւ��邷��(waterFlag==true�Ő����Afalse�Œn��֐؂�ւ���)
    public static void OnWaterChange( bool waterFlag )
    {
        gameManager.waterFlag = waterFlag;
        gameManager.water.SetWaterFlag(waterFlag);
    }

    //�_�f�Q�[�W���擾����
    public static float GetOxygenValue()
    {
        return gameManager.oxygenBar.GetValue();
    }

    //�_�f�Q�[�W�����Z����
    public static void AddOxygenValue( float value )
    {
        gameManager.oxygenBar.AddValue(value);
    }

    //�_�f�Q�[�W��ݒ肷��
    public static void SetOxygenValue( float value )
    {
        gameManager.oxygenBar.SetValue(value);
    }

    private void Start()
    {
        gameManager = this;
        GameInit();
    }

    private void Update()
    {
        gameTimer.UpdateTimer(Time.deltaTime);
    }

    //�Q�[���̏���������
    private void GameInit()
    {
        SetOxygenValue(100);
        gameTimer.ResetTimer();
        OnWaterChange(false);
    }
}
