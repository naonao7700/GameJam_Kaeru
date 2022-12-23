using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ゲームを総合的に管理するクラス
//主に一つだけのものを扱う
public class GameManager : MonoBehaviour
{
    //=====================================================================
    //変数の宣言
    //=====================================================================

    private static GameManager gameManager; //シングルトンにする

    [SerializeField] private OxygenBar oxygenBar;   //酸素ゲージ
    [SerializeField] private GameTimer gameTimer;    //ゲームタイマー
    [SerializeField] private Water water;   //水
    //[SerializeField] private WaterChangeTimer waterTimer;   //水位変更のクールタイムタイマー

    [SerializeField] private Timer oxygenTimer; //時間経過で変わる酸素のタイマー
    [SerializeField] private float oxygenDownValue; //酸素減少量
    [SerializeField] private float oxygenUpValue;   //酸素回復量

    //変数
    private float timer;
    [SerializeField] private bool gameClearFlag;
    private bool gameOverFlag;
    private bool onWaterUpFlag; //水位を上げているフラグ

    //=====================================================================
    //外部参照用関数(プログラマー班はここの関数を呼び出して下さい)
    //=====================================================================

    //水中フラグを取得する
    public static bool GetWaterFlag() => false;//gameManager.water.GetWaterFlag();

    //水中に切り替えるする(waterFlag==trueで水中、falseで地上へ切り替える)
    public static void OnWaterChange(bool waterFlag) => gameManager.SetWaterFlag(waterFlag);

    //酸素ゲージを取得する
    public static float GetOxygenValue() => gameManager.oxygenBar.GetValue();

    //酸素ゲージを加算する
    public static void AddOxygenValue(float value) => gameManager.oxygenBar.AddValue(value);

    //酸素ゲージを設定する
    public static void SetOxygenValue(float value) => gameManager.oxygenBar.SetValue(value);

    //ゲームをクリアしたときに呼び出す関数
    public static void OnGameClear() => gameManager.OnClear();

    //ゲームオーバーの時に呼び出す関数
    public static void OnGameOver() => gameManager.OnMiss();

    //水位を挙げる関数
    public static void OnWaterUp() => gameManager.OnWaterUpCore();

    //ゲーム時間を取得する
    public static float GetTime() => gameManager.timer;

    //ゲーム時間のテキストを取得する
    public static string GetTimeText(float time) => gameManager.gameTimer.GetTimeText(time);


    //=====================================================================
    //関数の実装
    //=====================================================================

    //ゲームの初期化処理
    private void GameInit()
    {
        onWaterUpFlag = false;

        //タイムを初期化
        gameTimer.ResetTimer();
        //酸素ゲージを初期化
        SetOxygenValue(100);

        //クールタイムをリセットする
        //waterTimer.ResetTimer();

        //水位をリセットする
        water.SetWaterValue(0.0f);
        //water.SetWaterFlag(false);
    }

    //ゲームの実行処理
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
            if( Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("GameScene");
            }
        }

        //ゲームタイムを更新
        gameTimer.UpdateTimer(Time.deltaTime);

        //酸素ゲージを更新
        oxygenTimer.DoUpdate(Time.deltaTime);
        if (oxygenTimer.IsEnd())
        {
            var value = oxygenUpValue;
            if (GetWaterFlag()) value = -oxygenDownValue;
            AddOxygenValue(value);
            oxygenTimer.Reset();
        }

        //水位を自然に落とす]
        if( onWaterUpFlag )
        {
            onWaterUpFlag = false;
        }
        else
        {
            water.AddWaterValue(-0.01f);
        }

        //水位クールタイムを更新
        //waterTimer.DoUpdate(deltaTime);

    }

    //ゲームをクリアしたときの処理
    private void OnClear()
    {
        gameClearFlag = true;
        //タイムを止める
    }

    //ゲームオーバー時の処理
    private void OnMiss()
    {
        gameOverFlag = true;
    }
    
    //水位を上げる処理
    private void OnWaterUpCore()
    {
        onWaterUpFlag = true;
        water.AddWaterValue(0.01f);
    }


    //水位を変更する処理(クールタイム中は無効)
    private void SetWaterFlag( bool waterFlag )
	{
        ////クールタイム中は無効
        //if (!waterTimer.GetChangeFlag()) return;

        ////水位を変更する
        //water.SetWaterFlag(waterFlag);

        ////クールタイムを設定する
        //waterTimer.ResetTimer();
	}


    //=====================================================================
    //Unityの関数
    //=====================================================================

    private void Start()
    {
        Application.targetFrameRate = 60;
        gameManager = this;

        //ゲームの初期化処理
        GameInit();
    }

    private void Update()
    {
        GameUpdate(Time.deltaTime);
    }

}
