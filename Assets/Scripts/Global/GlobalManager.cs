using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	 private IEnumerator IE_WaiteAndLoadScene(float t, int sceneID)
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene(sceneID);
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
		 StartCoroutine(IE_WaiteAndLoadScene(2f, 0));
	}
	

}
 	
