﻿using System.Collections;
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

	public float m_Horizontal = 0;

	public bool m_Jump = false;

	public bool m_Crouch = false;

	public bool m_Hurt = false;

	// Update is called once per frame
	void Update () {

		//horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		//animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		//OnMove(m_Horizontal);
		//OnJump(m_Jump);
		//OnHurt(m_Hurt);
		//OnCrouching(m_Crouch);
/* 
		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}
	

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
*/
	}

	public virtual void OnMove(float horizontal)
	{
		 Debug.Log("horizontalMove..."+horizontal);
		 horizontalMove = horizontal * runSpeed;
		 Debug.Log("horizontalMove...."+horizontalMove);
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
		if (hurt)
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
}
