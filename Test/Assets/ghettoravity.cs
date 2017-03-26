using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghettoravity : MonoBehaviour {

	// Use this for initialization
	public float mag = 1000;
	private Vector3 dir = new Vector3(0, -1, 0);

	// Update is called once per frame
	void Update () {
		transform.position -= transform.up * mag * Time.deltaTime;
	}
}
