using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
	public Vector3 minPos;	//水位が最低の座標
	public Vector3 maxPos;  //水位が最高の座標

	[SerializeField] private float value;

	public void SetWaterValue( float value )
    {
		if (value < 0.0f) value = 0.0f;
		else if (value > 1.0f) value = 1.0f;
		this.value = value;
		transform.localPosition = Vector3.Lerp(minPos, maxPos, this.value );
    }

	//水位を加算する処理
	public void AddWaterValue( float value )
    {
		this.value += value;
		if (this.value < 0.0f) this.value = 0.0f;
		if (this.value > 1.0f) this.value = 1.0f;
		transform.localPosition = Vector3.Lerp(minPos, maxPos, this.value );
	}

	//  [SerializeField] private RectTransform rect;
	//  [SerializeField] private Image image;

	//  [SerializeField] private Vector3 waterMaxPos;
	//  [SerializeField] private Vector3 waterMinPos;
	//  [SerializeField] private Timer waterTimer;
	//  [SerializeField] private AnimationCurve waterCurve;

	//  private Vector3 startPos;
	//  private Vector3 endPos;
	//  private bool waterFlag;

	//  public bool GetWaterFlag() => waterFlag;

	//  public void SetWaterFlag( bool value )
	//  {
	//      waterFlag = value;
	//      waterTimer.Reset();
	//      if( value )
	//      {
	//          startPos = waterMinPos;
	//          endPos = waterMaxPos;
	//      }
	//      else
	//      {
	//          startPos = waterMaxPos;
	//          endPos = waterMinPos;
	//      }
	//  }

	//  // Start is called before the first frame update
	//  void Start()
	//  {
	//      rect = GetComponent<RectTransform>();
	//  }

	//  // Update is called once per frame
	//  void Update()
	//  {
	//      waterTimer.DoUpdate(Time.deltaTime);
	//      if( !waterTimer.IsEnd() )
	//{
	//          var t = waterTimer.GetRate();
	//          t = waterCurve.Evaluate(t);
	//          rect.anchoredPosition = Vector3.Lerp(startPos, endPos, t);
	//}

	//  }
}
