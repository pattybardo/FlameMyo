using UnityEngine;
using System.Collections;

// Draw simple instructions for sample scene.
// Check to see if a Myo armband is paired.
public class SampleSceneGUI : MonoBehaviour
{
    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myo = null;


    // Draw some basic instructions.
    void OnGUI ()
    {
        GUI.skin.label.fontSize = 20;

        ThalmicHub hub = ThalmicHub.instance;

        // Access the ThalmicMyo script attached to the Myo object.
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		if (!hub.hubInitialized) {
			GUI.Label (new Rect (12, 8, Screen.width, Screen.height),
				"Cannot contact Myo Connect. Is Myo Connect running?\n" +
				"Press Q to try again."
			);
		} else if (!thalmicMyo.isPaired) {
			GUI.Label (new Rect (12, 8, Screen.width, Screen.height),
				"No Myo currently paired."
			);
		} else if (!thalmicMyo.armSynced) {
			GUI.Label (new Rect (12, 8, Screen.width, Screen.height),
				"Perform the Sync Gesture."
			);

		} else if (JointOrientation.loss) {
			GUI.Label (new Rect (12, 8, Screen.width, Screen.height),
				""
			);
		}else {
			GUI.Label (new Rect (12, 8, Screen.width, Screen.height),
				"Your score is: " + JointOrientation.score
                /*"Fist: Cast Lightning Spell\n" +
                "Double tap: Reset box orientation\n" +
                "Fingers spread: Cast Fireball Spell\n" +
				"Trigger Accellerometer: Throw Fireball"
				*/
            );
        }

    }

    void Update ()
    {
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

        ThalmicHub hub = ThalmicHub.instance;

        if (Input.GetKeyDown ("q")) {
            hub.ResetHub();
        }


    }
}
