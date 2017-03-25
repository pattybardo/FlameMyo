using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSpawn : MonoBehaviour {


	public GameObject cubeSprite;
	private float totalTime;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		totalTime += Time.deltaTime;
		if (totalTime % 10.0f < 0.1f) {
			Instantiate (cubeSprite, transform.position, transform.rotation);
			//cubeSprite.transform.position.x += 100;
		}
	}
}
