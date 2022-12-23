using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private float groundSpeed;	//�n��̈ړ��X�s�[�h
	[SerializeField] private float groundJumpPower;	//�n��̃W�����v��
	[SerializeField] private float waterSpeed;	//�����ړ��X�s�[�h
	[SerializeField] private float waterJumpPower;	//�����̃W�����v��
	[SerializeField] private float waterAirJumpPower;   //�����̋󒆂ł̃W�����v��

	[SerializeField] private Vector2 velocity;  //�ړ���

	[SerializeField] private int groundCount;//�G��Ă���n�ʂ̐�

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		velocity = Vector2.zero;
	}

	//���n���Ă��邩����
	private bool IsGround()
	{
		return groundCount > 0;
	}

	private void Update()
	{
		//���ʂ�؂�ւ���
		if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
		{
			var gravity = 1.0f;
			GameManager.OnWaterChange(!GameManager.GetWaterFlag());
			if (GameManager.GetWaterFlag()) gravity = 0.5f;
			rb.gravityScale = gravity;
		}

		//�ړ�
		Move();

		//�W�����v����
		if( Input.GetKeyDown(KeyCode.Space))
		{
			OnJump();
		}
	}

	//�W�����v����
	void OnJump()
	{
		var jumpPower = groundJumpPower;
		if (GameManager.GetWaterFlag()) jumpPower = waterJumpPower;

		if ( GameManager.GetWaterFlag() )
		{
			if (!IsGround()) jumpPower = waterAirJumpPower;	//�󒆃W�����v
		}
		else
		{
			//�n��ł́A���n������Ȃ��ƃW�����v�s��
			if (!IsGround()) return;
		}
		var v = Vector2.up * jumpPower;
		rb.velocity += v;
	}

	//�ړ�����
	void Move()
	{

		velocity = rb.velocity;

		//�������̈ړ�
		var inputX = Input.GetAxis("Horizontal");
		var moveSpeed = groundSpeed;
		if (GameManager.GetWaterFlag()) moveSpeed = waterSpeed;
		velocity.x = moveSpeed * inputX;
		rb.velocity = velocity;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		groundCount++;
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		groundCount--;
	}

}
