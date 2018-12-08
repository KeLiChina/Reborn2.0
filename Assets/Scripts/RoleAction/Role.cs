using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : MonoBehaviour {

	public float m_HP = 100;

	public float m_OneShotCast = 40;

	public float m_AddForce = 700;
	private bool protect = false;
	private Rigidbody2D m_Rigidbody2D;
	public Transform m_AtkForward;
	private float m_protateTime = 0.6f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetHurt()
	{
		// play hurt()
		// add force;
		//protect time
		if (protect)
		{
			return;
		}
		float  addForce = m_AddForce;
		if (!GetIsForWardRight())
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
		protect = true;
		
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
}
