using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GDGeek;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.forward = transform.forward + 2 * transform.forward * Time.deltaTime;
	}

}
