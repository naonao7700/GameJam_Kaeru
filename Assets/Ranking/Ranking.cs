using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Ranking : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Text text;
    string[] ranking = { "1��", "2��", "3��" };
    float[] rankingValue = new float[3];
    [SerializeField, Header("�\��������e�L�X�g")]
    Text[] rankingText = new Text[3];

    // Start is called before the first frame update
    void Start()
    {
        // GetRanking();
       float nowtime=TimeSave.timeSave.GetTime();
        if (nowtime < TimeSave.timeSave.GetRankingTime(0))
        {
            TimeSave.timeSave.SetRankingTime(TimeSave.timeSave.GetRankingTime(1), 2);
            TimeSave.timeSave.SetRankingTime(TimeSave.timeSave.GetRankingTime(0), 1);
            TimeSave.timeSave.SetRankingTime(nowtime, 0);
        }
        else if(nowtime < TimeSave.timeSave.GetRankingTime(1))
        {
            TimeSave.timeSave.SetRankingTime(TimeSave.timeSave.GetRankingTime(1), 2);
            TimeSave.timeSave.SetRankingTime(nowtime, 1);
        }
        else if(nowtime < TimeSave.timeSave.GetRankingTime(2))
        {
            TimeSave.timeSave.SetRankingTime(nowtime, 2);
        }
        for(int i = 0; i < 3; i++)
        {
            float time= TimeSave.timeSave.GetRankingTime(i);
            string text = TimeSave.timeSave.GetTimeText(time);
            rankingText[i].text = text;
        }
        //SetRanking(time);
        /*time = TimeSave.timeSave.GetTime();
        for (int i = 0; i < rankingText.Length; i++)
        {
            //rankingText[i].text = rankingValue[i].ToString();
            rankingText[i].text = TimeSave.timeSave.GetTimeText(time);
        }*/
    }
    /// <summary>
    /// �����L���O��������
    /// </summary>
    void SetRanking(float _value)
    {
        //�������ݗp
        for (int i = 0; i < ranking.Length; i++)
        {

            //�擾�����l��Ranking�̒l���r���ē���ւ�
            if (_value > rankingValue[i])
            {
                var change = rankingValue[i];
                rankingValue[i] = _value;
                _value = change;
            }
        }
    }
}
