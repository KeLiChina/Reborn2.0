using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour {

   	public static GlobalManager instance { get; set; }
	public Transform m_Player;

		

	protected void Awake()
    {
        if (GlobalManager.instance == null)
        {
            GlobalManager.instance = this;
        }
        else if (GlobalManager.instance != this)
        {
            Destroy(gameObject);
        }
    }
	
	void Update()
	{
	
	}
	public void SetPlayer(Transform ts)
	{
		m_Player = ts;
	}
	public void GameOver ()
	{

	}
	public void GameStart ()
	{
		
	}
	

}
