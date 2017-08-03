using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GDGeek;

public class Test : MonoBehaviour {
    public float MoveSpeed = 20;
    public float RotateSpeed = 80;
    // Use this for initialization
    void Start () {
        
	}

    // Update is called once per frame
    void Update()
    {
        Debug.Log("进入update");
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(Vector3.back * Time.deltaTime * RotateSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.right * Time.deltaTime * RotateSpeed);
            }
         
        }
    }
}
