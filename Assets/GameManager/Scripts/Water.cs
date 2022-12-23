using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
	public Vector3 minPos;	//êÖà Ç™ç≈í·ÇÃç¿ïW
	public Vector3 maxPos;  //êÖà Ç™ç≈çÇÇÃç¿ïW

	[SerializeField] private float value;
	[SerializeField] private float max;

	public void SetWaterValue( float value )
    {
		if (value < 0.0f) value = 0.0f;
		else if (value > max) value = max;
		this.value = value;
		transform.localPosition = Vector3.Lerp(minPos, maxPos, this.value / max );
    }

	//êÖà Çâ¡éZÇ∑ÇÈèàóù
	public void AddWaterValue( float value )
    {
		this.value += value;
		if (this.value < 0.0f) this.value = 0.0f;
		if (this.value > max) this.value = max;
		transform.localPosition = Vector3.Lerp(minPos, maxPos, this.value / max );
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
