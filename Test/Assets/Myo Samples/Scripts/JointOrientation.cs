using UnityEngine;
using System.Collections;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;




// Orient the object to match that of the Myo armband.
// Compensate for initial yaw (orientation about the gravity vector) and roll (orientation about
// the wearer's arm) by allowing the user to set a reference orientation.
// Making the fingers spread pose or pressing the 'r' key resets the reference orientation.



public class JointOrientation : MonoBehaviour
{

	static public bool loss = false;

	public LineRenderer lineRenderer;

	public GameObject defaultSphere;

	public GameObject spawner;

	public GameObject projectileSphere;
	public GameObject spark;
	public float sparkFireRate = 5;
	private double nextSparkFire = 0;
	private bool sparkCharge = false;
	bool updateReference = false;

	public bool testing = true;

	public float thrust;

	private bool endGameHappened = false;

	private Vector3 spawnStart;

	static public int score = 0;


	void playGame() {
		endGameHappened = false;
		spawnStart = new Vector3 (10.0f, 0.348f, 40.26f);
		Instantiate (spawner, spawnStart, GameObject.Find("Floor").transform.rotation);
	}

	void endGame() {
		if (!endGameHappened) {
			Destroy (spawner);
		}
		endGameHappened = true;
	}


	//Instantiate the fireball with a specific orientation so when it is launched it flies in that direction
	void throwFireball(){
		Destroy (GameObject.Find("newSphere"));
		GameObject shotSphere = Instantiate(projectileSphere, GameObject.Find ("SpawnSphere").transform.position, GameObject.Find ("Joint").transform.rotation);
		Destroy (shotSphere, 3);
	}

	void Start(){

		playGame ();
	}

    // Update is called once per frame.
    void Update (){

		GameObject SpawnSphere = GameObject.Find ("SpawnSphere");

        if (Input.GetKeyDown ("p")) {
			if (SpawnSphere.transform.childCount == 0) {
				GameObject newSphere = Instantiate (defaultSphere);
				newSphere.name = "newSphere";
				newSphere.transform.parent = SpawnSphere.transform;
				newSphere.transform.position = SpawnSphere.transform.position;
			}
		}
		if ((Input.GetKeyDown ("i")) && Time.time > nextSparkFire) {
			GameObject box = GameObject.Find ("Box");
			sparkCharge = true;
			nextSparkFire = Time.time + 1.5;
			GameObject newSpark = Instantiate (spark);
			newSpark.name = "newSpark";
			newSpark.transform.parent = box.transform;
			newSpark.transform.position = box.transform.position;
			Destroy (newSpark, 2);
	
		}
			
        
		

		if (SpawnSphere.transform.childCount > 0) {
			if (Input.GetKeyDown ("o")) {
				if (SpawnSphere.transform.childCount == 1) {
					throwFireball ();
				}
			}
		}

		if (sparkCharge && Time.time > nextSparkFire) {
			nextSparkFire = Time.time + sparkFireRate;
			sparkCharge = false;
			Instantiate (lineRenderer, transform.position, transform.rotation);
		}
			
		Vector2 mousePos = Input.mousePosition;
		transform.LookAt(Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 20)));


		if (loss) {
			endGame ();
		}
    }

    
}
