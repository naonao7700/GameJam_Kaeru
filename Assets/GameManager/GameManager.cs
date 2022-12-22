using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ゲームを総合的に管理するクラス
//主に一つだけのものを扱う
public class GameManager : MonoBehaviour
{
    private static GameManager gameManager; //シングルトンにする

    [SerializeField] private OxygenBar oxygenBar;   //酸素ゲージ
    [SerializeField] private GameTimer gameTimer;    //ゲームタイマー

    private float timer;
    private bool waterFlag;

    //水中フラグを取得する
    public static bool GetWaterFlag()
    {
        return gameManager.waterFlag;
    }

    //水中に切り替えるする(waterFlag==trueで水中、falseで地上へ切り替える)
    public static void OnWaterChange( bool waterFlag )
    {
        gameManager.waterFlag = waterFlag;
    }

    //酸素ゲージを取得する
    public static float GetOxygenValue()
    {
        return gameManager.oxygenBar.GetValue();
    }

    //酸素ゲージを加算する
    public static void AddOxygenValue( float value )
    {
        gameManager.oxygenBar.AddValue(value);
    }

    //酸素ゲージを設定する
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

    //ゲームの初期化処理
    private void GameInit()
    {
        SetOxygenValue(100);
        gameTimer.ResetTimer();
    }
}
