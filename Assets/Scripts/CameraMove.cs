using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {


    public GameObject camTargerPoint;
    public float chaseSpeed = 10f;
    public Transform test;


    private static GameObject MonoSingletionRoot;
    private static CameraMove instance;
    public static CameraMove Instance
    {
        get
        {
            if (MonoSingletionRoot == null)
            {
                MonoSingletionRoot = GameObject.Find("Main Camera");
                if (MonoSingletionRoot == null)
                {
                    MonoSingletionRoot = new GameObject();
                    MonoSingletionRoot.name = "Main Camera";
                    DontDestroyOnLoad(MonoSingletionRoot);
                }
            }

            if (instance == null)
            {
                instance = MonoSingletionRoot.GetComponent<CameraMove>();
                if (instance == null)
                {
                    instance = MonoSingletionRoot.AddComponent<CameraMove>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {


    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.position = Vector3.Slerp(new Vector3(transform.position.x, transform.position.y, transform.position.z),
             new Vector3(camTargerPoint.transform.position.x, camTargerPoint.transform.position.y, transform.position.z),
             chaseSpeed * Time.deltaTime);


        //测试
        if (Input.GetMouseButtonDown(0))
        {
            changeTarget(test);
        }
    }

    public void changeTarget(Transform trans)
    {
        camTargerPoint.GetComponent<Chase>().playerTrans = trans;

    }

}
