using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour {
	private int rnd;
	public GameObject moving;

	public int interval;

	private double nextSpawn =0;
	public double spawnRate = 2;
	void Update () {
		if (Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			rnd = Random.Range (0, interval);
			Instantiate (moving, new Vector3(-10 + rnd, 1 , 40), transform.rotation);
		}

		if (JointOrientation.score == 2000) {
			spawnRate = 3.5;
		} else if (JointOrientation.score == 4000){
			spawnRate = 2.5;
		} else if (JointOrientation.score == 6000){
			spawnRate = 1;
		}
	}    
}
	