using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawLine : MonoBehaviour {


	private LineRenderer lineRenderer;

	private float counter;
	private float dist;

	public Transform origin;
	public Transform destination;

	private Vector3 pointA;
	private Vector3 pointB;


	public float lineDrawSpeed = 4f;
	// Use this for initialization
	void Start () {
		origin = GameObject.Find ("Box").transform;
		destination = GameObject.Find ("ReticleDestination").transform;
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.SetPosition(0,origin.position);
		lineRenderer.SetPosition(1,origin.position);
		lineRenderer.SetWidth (1f, 1f);
	

		//lineRenderer.transform.parent = origin.transform;

		dist = Vector3.Distance (origin.position, destination.position);
		pointA = origin.position;
		pointB = destination.position;


	}
	
	// Update is called once per frame
	void Update () {


		if (counter < 2) {
			//collider
			counter += .8f / lineDrawSpeed;

			float x = Mathf.Lerp (0, dist, counter);

			Vector3 pointAlongLine = x * Vector3.Normalize (pointB - pointA) + pointA;


			lineRenderer.SetPosition (1, pointAlongLine);

			Debug.Log (counter);
		} else {
			Debug.Log("DestroyingRenderer");
			counter = 0;
			Destroy (gameObject);

		}
	}
}
