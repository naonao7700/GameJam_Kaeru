using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
    [SerializeField] private RectTransform rect;
    [SerializeField] private Image image;

    [SerializeField] private Vector3 waterMaxPos;
    [SerializeField] private Vector3 waterMinPos;
    [SerializeField] private Timer waterTimer;
    [SerializeField] private AnimationCurve waterCurve;

    private Vector3 startPos;
    private Vector3 endPos;

    public void SetWaterFlag( bool value )
    {
        waterTimer.Reset();
        if( value )
        {
            startPos = waterMinPos;
            endPos = waterMaxPos;
        }
        else
        {
            startPos = waterMaxPos;
            endPos = waterMinPos;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        waterTimer.DoUpdate(Time.deltaTime);
        if( !waterTimer.IsEnd() )
		{
            var t = waterTimer.GetRate();
            t = waterCurve.Evaluate(t);
            rect.anchoredPosition = Vector3.Lerp(startPos, endPos, t);
		}
        
    }
}
