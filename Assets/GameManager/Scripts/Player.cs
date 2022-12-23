using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private float groundSpeed; //�n��̈ړ��X�s�[�h
	[SerializeField] private GameObject model;  //���f��
	[SerializeField] private Animator animator; //�A�j���[�^�[
	[SerializeField] private PlayerSound sound;

	//[SerializeField] private float groundJumpPower;	//�n��̃W�����v��
	//[SerializeField] private float waterSpeed;	//�����ړ��X�s�[�h
	//[SerializeField] private float waterJumpPower;	//�����̃W�����v��
	//[SerializeField] private float waterAirJumpPower;   //�����̋󒆂ł̃W�����v��
	//[SerializeField] private float groundGravityScale;  //�n��ł̏d��
	//[SerializeField] private float waterGravityScale;	//�����ł̏d��

	[SerializeField] private Vector2 velocity;  //�ړ���

	//[SerializeField] private int groundCount;//�G��Ă���n�ʂ̐�

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		velocity = Vector2.zero;
	}

	////���n���Ă��邩����
	//private bool IsGround()
	//{
	//	return groundCount > 0;
	//}

	private void Update()
	{
		if (!GameManager.CanPlay())
		{
			rb.velocity = Vector2.zero;
			return;
		}

		//���ʂ�؂�ւ���
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

		//�ړ�
		Move();

		////�W�����v����
		//if( Input.GetKeyDown(KeyCode.Space))
		//{
		//	OnJump();
		//}
	}

	//�W�����v����
	//void OnJump()
	//{
	//	var jumpPower = groundJumpPower;
	//	if (GameManager.GetWaterFlag()) jumpPower = waterJumpPower;

	//	if ( GameManager.GetWaterFlag() )
	//	{
	//		if (!IsGround()) jumpPower = waterAirJumpPower;	//�󒆃W�����v
	//	}
	//	else
	//	{
	//		//�n��ł́A���n������Ȃ��ƃW�����v�s��
	//		if (!IsGround()) return;
	//	}
	//	var v = Vector2.up * jumpPower;
	//	rb.velocity += v;
	//}

	//�ړ�����
	void Move()
	{

		velocity = rb.velocity;

		//�������̈ړ�
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
