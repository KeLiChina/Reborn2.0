﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ROLE_TYPE
{
	NULL = -1,
	SHIELD = 0,
	THIEF = 1,
	ZHUJUE = 2,
	SIZE
}
public class Role : MonoBehaviour {

	public GameObject fire;
	public float bulletSpeed = 1000f;
	public Damager norDamage;
	public Damager souDamage;
	private float m_HP = 100;
	public float m_PSValue = 5000;
	public ROLE_TYPE  m_RoleType = ROLE_TYPE.NULL; //1 shield 2, thief
	
	private float moveSpeed = 20f;

	private float crash = 70;

	private float m_AddForce = 700;

	public float m_JumpForce = 700;

	private float bulletCost = 40;
	private bool protect = false;
	private Rigidbody2D m_Rigidbody2D;
	public Transform m_AtkForward;
	private float m_protateTime = 0.6f;

	private RoleMovment m_RoleMovment;
	private Transform TargetSoul;

	public bool isPlayer = false;

	public CharacterController2D m_characterController2d;
	private Light m_light ;
	 private ParticleSystem ps;
	private float m_Max_Light = 100;
	private float m_Cur_Light =  100;
	private float m_MIN_Light = 100;
	private float m_Max_HP;
	void Awake () {
		m_characterController2d = GetComponentInChildren<CharacterController2D>();
		m_RoleMovment = GetComponent<RoleMovment>();
		m_light = GetComponentInChildren<Light>();
		ps = fire.GetComponent<ParticleSystem>();
	}
	
	void Start () {
		Init();
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetLightPower(float value)
	{
		
		var emission = ps.emission;
        emission.rateOverTime = (value/m_Max_HP	) * m_PSValue;
	}
	public void Init()
	{
		if (m_RoleType == ROLE_TYPE.SHIELD)
		{
			m_HP = 140;
			bulletCost = 40f;
			m_AddForce = 700;
			m_protateTime = 0.6f;
			moveSpeed = 20f;
			crash = 80;
			bulletSpeed= 1100;
			m_Max_Light = 6;
			 m_Cur_Light =  100;
			 m_MIN_Light = 100;
			 m_Max_HP = m_HP;
			 m_JumpForce = 600;
			

		}
		else if (m_RoleType ==ROLE_TYPE.THIEF)
		{

			m_HP = 100;
			bulletCost = 40f;
			m_AddForce = 700;
			m_protateTime = 0.6f;
			moveSpeed = 20f;
			crash = 70;
			bulletSpeed= 1000;
			 m_Cur_Light =  100;
			 m_MIN_Light = 100;
			 m_Max_Light = 6;
			  m_Max_HP = m_HP;
			  m_JumpForce = 600;
		}
		else if (m_RoleType ==ROLE_TYPE.ZHUJUE)
		{

			m_HP = 120;
			bulletCost = 40f;
			m_AddForce = 700;
			m_protateTime = 0.6f;
			moveSpeed = 20f;
			crash = 70;
			bulletSpeed= 1300;
			 m_Cur_Light =  100;
			 m_Max_Light = 6;
			  m_Max_HP = m_HP;
			   m_JumpForce = 600;
		}
		// else if (m_RoleType == 4)
		// {

		// 	m_HP = 100f;
		// 	bulletCost = 40f;
		// 	m_AddForce = 700;
		// 	m_protateTime = 0.6f;
		// 	moveSpeed = 20f;
		// 	crash = 70;
		// }

		if (GlobalManager.instance.m_Player == transform)
		{
			StartCoroutine(IE_LifeCountDown());
			SetLightPower(m_Max_HP);
			fire.SetActive(true);
		
		}
		else
			{
				GlobalManager.instance.AddEnemy(this);
				SetLightPower(0);
				fire.SetActive(false);
			}
	}

	public void ShootBullet()
	{
		if ( m_HP > 0 )
		{
			m_HP -= bulletCost;
			HP_Changer(m_HP);
		}
		if (m_HP<= 0)
		{
			LogicDie();
			SetMove(false);
		}

	}
	public void GetHurt(Transform ts)
	{
		// play hurt()
		// add force;
		//protect time
		if (protect)
		{
			return;
		}
		float  addForce = m_AddForce;
		if (!m_characterController2d.m_FacingRight)
		{
			addForce = -m_AddForce;
		}
	
		m_Rigidbody2D.AddForce(new Vector2(addForce,0f ));
		protect = true;
		 StartCoroutine(IE_PortectTime());
		
	}

	public void LogicDie()
	{
		// play Die()
		SetLightPower(0);
		protect = true;
		GlobalManager.instance.RemoveEnemy(this);
		StartCoroutine(IE_Destroy());
		if (GlobalManager.instance.m_Player == transform)
		{
			GlobalManager.instance.GameStart();
		}
		
	}	

	public void normalAtk()
	{
		// play atk()
		var noratk = Instantiate(norDamage,m_AtkForward.position,m_AtkForward.rotation);
		noratk.transform.parent = m_AtkForward;
		
	}	
	public void soulAtk()
	{
		// play atk()
		var noratk = Instantiate(souDamage,m_AtkForward.position,m_AtkForward.rotation);
		//noratk.transform.parent = m_AtkForward;
		noratk.m_Role = this;
		Rigidbody2D r2d = noratk.gameObject.GetComponent<Rigidbody2D>();
		
		float xforce = bulletSpeed + bulletSpeed * Mathf.Abs(Input.GetAxisRaw("Horizontal"));
		float yforce = bulletSpeed+ bulletSpeed * Mathf.Abs(Input.GetAxisRaw("Vertical")*2) ;
		if (!m_characterController2d.m_FacingRight)
		{
			xforce = -xforce;
		}
		if (!protect)
		{
			r2d.AddForce(new Vector2(xforce,yforce ));
			
		}
		
		
	}

	public void Reborn()
	{
		// play hurt()
		// add force;
		//protect time
		protect = true;
		float  addForce = m_AddForce;
		if (!GetIsForWardRight())
		{
			addForce = -m_AddForce;
		}
		if (!protect)
		{
			m_Rigidbody2D.AddForce(new Vector2(addForce,0f ));
			protect = true;
			StartCoroutine(IE_PortectTime());
		}
	}

	IEnumerator IE_PortectTime()
    {
        // if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        // {
        //     m_AnimatorState = AnimatorState.Idle;
        //     m_Animator.Play(m_Idle);
        // }
        // yield return new WaitForEndOfFrame();

        yield return new WaitForSeconds(m_protateTime);
		protect = false;
    }
	IEnumerator IE_Destroy()
    {
        // if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        // {
        //     m_AnimatorState = AnimatorState.Idle;
        //     m_Animator.Play(m_Idle);
        // }
        // yield return new WaitForEndOfFrame();

        yield return new WaitForSeconds(1f);
		Destroy(gameObject);
    }

	IEnumerator IE_LifeCountDown()
    {
  
		while(true)
		{
  			yield return new WaitForSeconds(1f);
			if ( m_HP > 0 )
			{
				HP_Changer(-5);
			}
			else
			{
			LogicDie();
			SetMove(false);	
			}
			
		}
		
    }

	public void HP_Changer(float value)
	{
		m_HP = m_HP + value;
		SetLightPower(m_HP);
	}	


	public bool GetIsForWardRight()
	{
		return (transform.position.x - m_AtkForward.position.x) > 0;
	}
	public void SetMove(bool start)
	{
		if (start)
		{

		}
		else
		{

		}
	}
	public void EnemyMove(Transform tf)
	{
		TargetSoul = tf ;
		if (GlobalManager.instance.m_Player != transform)
		{
			StartCoroutine(IE_EnemyMove());
		}
	}

		IEnumerator IE_EnemyMove()
    {
		float moveTime = 4f;
		bool signe = true;
		while(signe)
		{
  			yield return new WaitForSeconds(0.2f);
			
			if ( moveTime > 0 && Vector3.Distance(TargetSoul.position,transform.position) > 0.2 )
			{
				moveTime =  moveTime - 0.2f;
				float dis = TargetSoul.position.x -transform.position.x;
				float enemyMoveSpeed = 0.2f;
				if (dis<=0 )
				{
					m_RoleMovment.OnMove((float) -0.3,"IsAttack");
					// m_RoleMovment.controller.Move((float) -0.2 * m_RoleMovment.runSpeed * Time.fixedDeltaTime, m_RoleMovment.crouch, m_RoleMovment.jump);
					// m_RoleMovment.jump = false;
					// transform.Translate((TargetSoul.position-transform.position).normalized*Time.deltaTime*400f);
					 Vector3 v3 = new Vector3(transform.position.x - 0.3f,transform.position.y,transform.position.z);
				
	 				transform.position = v3;
				}
				else{
				m_RoleMovment.OnMove((float) 0.3,"IsAttack");
				// m_RoleMovment.controller.Move((float) 0.2 * m_RoleMovment.runSpeed * Time.fixedDeltaTime, m_RoleMovment.crouch, m_RoleMovment.jump);
				// 	m_RoleMovment.jump = false;
				// transform.Translate((TargetSoul.position-transform.position).normalized*Time.deltaTime*400f);
				 Vector3 v3 = new Vector3(transform.position.x + 0.3f,transform.position.y,transform.position.z);
				 	 transform.position = v3;
				}
			}
			else
			{
			signe = false;	
			StopCoroutine(IE_EnemyMove());
			}
		}
      
	
		
    }
}
