using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private float groundSpeed; //地上の移動スピード
	[SerializeField] private GameObject model;  //モデル
	[SerializeField] private Animator animator; //アニメーター
	[SerializeField] private PlayerSound sound;

	//[SerializeField] private float groundJumpPower;	//地上のジャンプ力
	//[SerializeField] private float waterSpeed;	//水中移動スピード
	//[SerializeField] private float waterJumpPower;	//水中のジャンプ力
	//[SerializeField] private float waterAirJumpPower;   //水中の空中でのジャンプ力
	//[SerializeField] private float groundGravityScale;  //地上での重力
	//[SerializeField] private float waterGravityScale;	//水中での重力

	[SerializeField] private Vector2 velocity;  //移動量

	//[SerializeField] private int groundCount;//触れている地面の数

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		velocity = Vector2.zero;
	}

	////着地しているか判定
	//private bool IsGround()
	//{
	//	return groundCount > 0;
	//}

	private void Update()
	{
		if (!GameManager.CanPlay())
		{
			animator.SetBool("Move", false);
			animator.SetBool("Swim", false);
			rb.velocity = Vector2.zero;
			return;
		}

		//水位を切り替える
		if( Input.GetKey( KeyCode.Space))
        {
			GameManager.OnWaterUp();
        }
		//if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
		//{
		//	var gravity = groundGravityScale;
		//	GameManager.OnWaterChange(!GameManager.GetWaterFlag());
		//	if (GameManager.GetWaterFlag()) gravity = waterGravityScale;
		//	rb.gravityScale = gravity;
		//}

		//移動
		Move();

		////ジャンプ処理
		//if( Input.GetKeyDown(KeyCode.Space))
		//{
		//	OnJump();
		//}
	}

	//ジャンプする
	//void OnJump()
	//{
	//	var jumpPower = groundJumpPower;
	//	if (GameManager.GetWaterFlag()) jumpPower = waterJumpPower;

	//	if ( GameManager.GetWaterFlag() )
	//	{
	//		if (!IsGround()) jumpPower = waterAirJumpPower;	//空中ジャンプ
	//	}
	//	else
	//	{
	//		//地上では、着地中じゃないとジャンプ不可
	//		if (!IsGround()) return;
	//	}
	//	var v = Vector2.up * jumpPower;
	//	rb.velocity += v;
	//}

	//移動する
	void Move()
	{

		velocity = rb.velocity;

		//横方向の移動
		var inputX = Input.GetAxis("Horizontal");
		var moveSpeed = groundSpeed;
		//if (GameManager.GetWaterFlag()) moveSpeed = waterSpeed;
		velocity.x = moveSpeed * inputX;
		rb.velocity = velocity;

		float x = Mathf.Sign(velocity.x);
		model.transform.rotation = Quaternion.Euler(0, 90 * x, 0);

		animator.SetBool("Move", velocity.x != 0.0f);

	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("Swim", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
		animator.SetBool("Swim", false);
	}

}
