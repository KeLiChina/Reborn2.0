using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleMovment : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	public float horizontalMove = 0f;
	public bool jump = false;
 	public bool crouch = false;
	public bool hurt = false;

	// public float m_Horizontal = 0;

	// public bool m_Jump = false;

	// public bool m_Crouch = false;

	// public bool m_Hurt = false;
	public bool m_IsPlayer = false;
	public float m_HP = 100;
	public bool m_atk = false;
	public float JumpFroce = 400;

	public virtual void OnMove(float horizontal,string actionName)
	{
		horizontalMove = horizontal * runSpeed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
	}
	public virtual void OnJump(bool Jump)
	{
		if (Jump)
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}
	}

	public virtual void OnAttack(bool atk)
	{
		
			
		animator.SetBool("IsAttack", atk);
		m_atk = true;
		
	}


	public virtual void OnCrouch(bool Crouch)
	{
		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
	}
	public virtual void OnHurt(bool Hurt)
	{
		if (Hurt)
		{
			hurt = true;
			animator.SetBool("IsHurting", true);
		}
	}
	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

	//
}
