using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour {

   	public static GlobalManager instance { get; set; }
	public bool isG = false;
	public bool GetG ()
	{
		return isG;
	}
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
		// if (Input.GetAxisRaw("Horizontal")!= 0)
		// {
		// 	SetG(true);
		// } 
		// else SetG(false);
	}
	public void SetG (bool bl)
	{
		 isG = bl;
	}

}
