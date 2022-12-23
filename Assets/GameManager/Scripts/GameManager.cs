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
    [SerializeField] private GameTimer gameTimer;    //�Q�[���^�C�}�[
    [SerializeField] private Water water;   //��
    [SerializeField] private WaterChangeTimer waterTimer;   //���ʕύX�̃N�[���^�C���^�C�}�[

    [SerializeField] private Timer oxygenTimer; //���Ԍo�߂ŕς��_�f�̃^�C�}�[
    [SerializeField] private float oxygenDownValue; //�_�f������
    [SerializeField] private float oxygenUpValue;   //�_�f�񕜗�

    //�ϐ�
    private float timer;
    [SerializeField] private bool gameClearFlag;
    private bool gameOverFlag;

    //=====================================================================
    //�O���Q�Ɨp�֐�(�v���O���}�[�ǂ͂����̊֐����Ăяo���ĉ�����)
    //=====================================================================

    //�����t���O���擾����
    public static bool GetWaterFlag() => gameManager.water.GetWaterFlag();

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

    //=====================================================================
    //�֐��̎���
    //=====================================================================

    //�Q�[���̏���������
    private void GameInit()
    {
        //�^�C����������
        gameTimer.ResetTimer();
        //�_�f�Q�[�W��������
        SetOxygenValue(100);

        //�N�[���^�C�������Z�b�g����
        waterTimer.ResetTimer();

        //���ʂ����Z�b�g����
        water.SetWaterFlag(false);
    }

    //�Q�[���̎��s����
    private void GameUpdate( float deltaTime )
	{
        if (gameClearFlag)
        {
            if( Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("GameScene");
            }
            return;
        }

        //�Q�[���^�C�����X�V
        gameTimer.UpdateTimer(Time.deltaTime);

        //�_�f�Q�[�W���X�V
        oxygenTimer.DoUpdate(Time.deltaTime);
        if (oxygenTimer.IsEnd())
        {
            var value = oxygenUpValue;
            if (GetWaterFlag()) value = -oxygenDownValue;
            AddOxygenValue(value);
            oxygenTimer.Reset();
        }

        //���ʃN�[���^�C�����X�V
        waterTimer.DoUpdate(deltaTime);

    }

    //�Q�[�����N���A�����Ƃ��̏���
    private void OnClear()
    {
        gameClearFlag = true;
        //�^�C�����~�߂�
    }


    //���ʂ�ύX���鏈��(�N�[���^�C�����͖���)
    private void SetWaterFlag( bool waterFlag )
	{
        //�N�[���^�C�����͖���
        if (!waterTimer.GetChangeFlag()) return;

        //���ʂ�ύX����
        water.SetWaterFlag(waterFlag);

        //�N�[���^�C����ݒ肷��
        waterTimer.ResetTimer();
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
