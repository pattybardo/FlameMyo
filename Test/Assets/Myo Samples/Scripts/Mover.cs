using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Mover : MonoBehaviour {

	public float speed;

	void Update () {
		transform.Translate(Vector3.forward * speed * Time.deltaTime);

		if (gameObject.transform.position.z <= -13) {
			JointOrientation.loss = true;
		}

		if (JointOrientation.loss) {
			DestroyImmediate (gameObject,true);
		}
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.name != gameObject.name)
		//Animator.StringToHash ("Die"); //double check this line once our collision detection is fixed
		Destroy (gameObject);
		JointOrientation.score += 100;
	}

}
