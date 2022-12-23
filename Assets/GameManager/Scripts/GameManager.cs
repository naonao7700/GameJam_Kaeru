using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�Q�[���𑍍��I�ɊǗ�����N���X
//��Ɉ�����̂��̂�����
public class GameManager : MonoBehaviour
{
    //=====================================================================
    //�ϐ��̐錾
    //=====================================================================

    private static GameManager gameManager; //�V���O���g���ɂ���

    [SerializeField] private OxygenBar oxygenBar;   //�_�f�Q�[�W
    [SerializeField] private WaterBar waterBar; //���ʃQ�[�W
    [SerializeField] private GameTimer gameTimer;    //�Q�[���^�C�}�[
    [SerializeField] private Water water;   //��
    [SerializeField] private GameOverObject gameOverObject;
    //[SerializeField] private WaterChangeTimer waterTimer;   //���ʕύX�̃N�[���^�C���^�C�}�[

    [SerializeField] private Timer oxygenTimer; //���Ԍo�߂ŕς��_�f�̃^�C�}�[
    [SerializeField] private float oxygenDownValue; //�_�f������
    [SerializeField] private float oxygenUpValue;   //�_�f�񕜗�

    //�ϐ�
    //private float timer;
    [SerializeField] private bool gameClearFlag;
    private bool gameOverFlag;
    private bool onWaterUpFlag; //���ʂ��グ�Ă���t���O

    //=====================================================================
    //�O���Q�Ɨp�֐�(�v���O���}�[�ǂ͂����̊֐����Ăяo���ĉ�����)
    //=====================================================================

    //�����t���O���擾����
    public static bool GetWaterFlag() => false;//gameManager.water.GetWaterFlag();

    //�����ɐ؂�ւ��邷��(waterFlag==true�Ő����Afalse�Œn��֐؂�ւ���)
    public static void OnWaterChange(bool waterFlag) => gameManager.SetWaterFlag(waterFlag);

    //�_�f�Q�[�W���擾����
    public static float GetOxygenValue() => gameManager.oxygenBar.GetValue();

    //�_�f�Q�[�W�����Z����
    public static void AddOxygenValue(float value) => gameManager.oxygenBar.AddValue(value);

    //�_�f�Q�[�W��ݒ肷��
    public static void SetOxygenValue(float value) => gameManager.oxygenBar.SetValue(value);

    //�Q�[�����N���A�����Ƃ��ɌĂяo���֐�
    public static void OnGameClear() => gameManager.OnClear();

    //�Q�[���I�[�o�[�̎��ɌĂяo���֐�
    public static void OnGameOver() => gameManager.OnMiss();

    //���ʂ�������֐�
    public static void OnWaterUp() => gameManager.OnWaterUpCore();

    //�Q�[�����Ԃ��擾����
    //public static float GetTime() => gameManager.timer;

    //�Q�[�����Ԃ̃e�L�X�g���擾����
    public static string GetTimeText(float time) => gameManager.gameTimer.GetTimeText(time);

    //�v���C���[�𓮂����邩����
    public static bool CanPlay() => !(gameManager.gameOverFlag || gameManager.gameClearFlag);

    public static TimeSave GetTimeSave() => TimeSave.timeSave;

    //=====================================================================
    //�֐��̎���
    //=====================================================================

    //�Q�[���̏���������
    private void GameInit()
    {
        onWaterUpFlag = false;

        //�^�C����������
        gameTimer.ResetTimer();
        //�_�f�Q�[�W��������
        SetOxygenValue(100);

        //�N�[���^�C�������Z�b�g����
        //waterTimer.ResetTimer();

        //���ʂ����Z�b�g����
        water.SetWaterValue(0.0f);
        //water.SetWaterFlag(false);
    }

    //�Q�[���̎��s����
    private void GameUpdate( float deltaTime )
	{
        if (gameClearFlag)
        {
            //if( Input.GetKeyDown(KeyCode.Space))
            //{
            //    SceneManager.LoadScene("GameScene");
            //}
            return;
        }
        else if( gameOverFlag )
        {
            if (!gameOverObject.IsEnd()) return;

            if( Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Title");
            }
            return;
        }

        //�Q�[���^�C�����X�V
        gameTimer.UpdateTimer(Time.deltaTime);

        ////�_�f�Q�[�W���X�V
        //oxygenTimer.DoUpdate(Time.deltaTime);
        //if (oxygenTimer.IsEnd())
        //{
        //    var value = oxygenUpValue;
        //    if (GetWaterFlag()) value = -oxygenDownValue;
        //    AddOxygenValue(value);
        //    oxygenTimer.Reset();
        //}

        //���ʂ����R�ɗ��Ƃ�]
        if( onWaterUpFlag )
        {
            onWaterUpFlag = false;
        }
        else
        {
            water.AddWaterValue(-0.01f);
            waterBar.AddValue(0.01f);
        }

        //���ʃN�[���^�C�����X�V
        //waterTimer.DoUpdate(deltaTime);

    }

    //�Q�[�����N���A�����Ƃ��̏���
    private void OnClear()
    {
        gameClearFlag = true;
        //�^�C�����~�߂�
        TimeSave.timeSave.SetTime(gameTimer.GetTime());
    }

    //�Q�[���I�[�o�[���̏���
    private void OnMiss()
    {
        gameOverFlag = true;
        gameOverObject.OnGameOver();
    }
    
    //���ʂ��グ�鏈��
    private void OnWaterUpCore()
    {
        if( waterBar.GetRate() > 0.0f )
        {
            return;
        }
        onWaterUpFlag = true;
        water.AddWaterValue(0.01f);
        waterBar.AddValue(-0.01f);
        
    }


    //���ʂ�ύX���鏈��(�N�[���^�C�����͖���)
    private void SetWaterFlag( bool waterFlag )
	{
        ////�N�[���^�C�����͖���
        //if (!waterTimer.GetChangeFlag()) return;

        ////���ʂ�ύX����
        //water.SetWaterFlag(waterFlag);

        ////�N�[���^�C����ݒ肷��
        //waterTimer.ResetTimer();
	}


    //=====================================================================
    //Unity�̊֐�
    //=====================================================================

    private void Start()
    {
        Application.targetFrameRate = 60;
        gameManager = this;

        //�Q�[���̏���������
        GameInit();
    }

    private void Update()
    {
        GameUpdate(Time.deltaTime);
    }

}
