using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DAMAGER_TYPE
{
	NULL = -1,
    NORMAL = 0,
    SOUL = 1,
    SIZE
}
public class Damager : MonoBehaviour {
	public DAMAGER_TYPE m_DamagerType = DAMAGER_TYPE.NULL;// 1 灵魂 2 普通攻击
	public Role m_Role;
	private BoxCollider2D m_BoxCollider2D;
	public GameObject soul;
	void Start () {
		// m_Role = transform.GetComponentInParent<Role>();
		if (m_DamagerType == DAMAGER_TYPE.NORMAL)
		{
			StartCoroutine(IE_Destroy());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D obj)
	{
		Role objRole = obj.transform.GetComponentInParent<Role>();
		if (objRole == null)
		{
			if (obj.tag == "plane")
			{
				GameObject sou = Instantiate(soul,transform.position,transform.rotation);
				soul.transform.parent = GlobalManager.instance.transform;
			}
			Destroy(gameObject);
		}
		else if ( objRole.m_RoleType != m_Role.m_RoleType)
		{
			bool onEnemyBack  = false;
			if (objRole.m_characterController2d.m_FacingRight &&(obj.transform.position.x- m_Role.transform.position.x > 0)
			|| !objRole.m_characterController2d.m_FacingRight &&(obj.transform.position.x- m_Role.transform.position.x < 0)
			)
			{
			 onEnemyBack = true;
			}
			
			if (m_DamagerType == DAMAGER_TYPE.SOUL) 
			{
				if (onEnemyBack )
				{
					GlobalManager.instance.SetPlayer(obj.transform);
					objRole.Init();
				}
				Destroy(gameObject);
			
			}
			else if (m_DamagerType == DAMAGER_TYPE.NORMAL)
			{
				if (!onEnemyBack)
				{
					objRole.GetHurt(m_Role.transform);
				}
				else 
				{
					objRole.LogicDie();
				}
			}
			
		}
	}

	IEnumerator IE_Destroy()
    {
        // if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        // {
        //     m_AnimatorState = AnimatorState.Idle;
        //     m_Animator.Play(m_Idle);
        // }
        // yield return new WaitForEndOfFrame();

        yield return new WaitForSeconds(0.1f);
		Destroy(gameObject);
    }
}
