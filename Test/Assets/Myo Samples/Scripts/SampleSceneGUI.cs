using UnityEngine;
using System.Collections;

// Draw simple instructions for sample scene.
// Check to see if a Myo armband is paired.
public class SampleSceneGUI : MonoBehaviour
{
    // Draw some basic instructions.
    void OnGUI ()
    {
        GUI.skin.label.fontSize = 20;
		GUI.Label (new Rect (12, 8, Screen.width, Screen.height),
			"Your score is: " + JointOrientation.score
		);
    }
}
