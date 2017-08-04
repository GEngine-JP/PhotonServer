using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GDGeek;

public class Test : MonoBehaviour {
    public GameObject cube;

    private string msg;

    private void Awake()
    {
        cube = GameObject.Find("Cube");
    }

    void Start () {
        
	}

    // Update is called once per frame
    void Update()
    {
        Debug.Log("进入update");
        {
            if (Input.GetKey(KeyCode.Q))
            {
                cube.transform.position = transform.TransformPoint(0, 0, 2);
                cube.transform.parent = transform;
                cube.GetComponent<Rigidbody>().isKinematic = true;
            }
            msg = Input.mousePosition.ToString();

            if (Input.GetKey(KeyCode.E))
            {
                if (cube.transform.parent = this.transform) {
                    cube.GetComponent<Rigidbody>().isKinematic = false;
                    transform.DetachChildren();
                    Vector3 direction = transform.TransformDirection(0, 0, 50);
                    cube.GetComponent<Rigidbody>().AddForce(direction,ForceMode.Force);
                   
                }
            }
        }
    }


    public void mover() {
        StartCoroutine("HeavyTask");
    }
    IEnumerable HeavyTask() {

        // 耗时操作
        yield return null;
    }


    private void OnGUI()
    {
        GUILayout.TextArea("Game time :" + Time.time, 200);
        GUILayout.TextArea("Game timeSinceLevelLoad :" + Time.timeSinceLevelLoad.ToString(), 200);
        GUILayout.TextArea("Delta time :" + Time.deltaTime, 200);
        GUILayout.TextArea("Fixed time :" + Time.fixedTime, 200);
        GUILayout.TextArea("real time :" + Time.realtimeSinceStartup, 200);
        GUILayout.TextArea("鼠标的位置 :" + msg, 200);
       
    }
}
