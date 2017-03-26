using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPostition = new Vector3( GameObject.Find ("Stick").transform.position.x, 
			this.transform.position.y, 
			GameObject.Find ("Stick").transform.position.z ) ;
		this.transform.LookAt( targetPostition ) ;
	}
}
