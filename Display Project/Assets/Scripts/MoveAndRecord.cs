using UnityEngine;

public class MoveAndRecord : MonoBehaviour {

	public float speed;

	Vector3 startRotation;
	Record record;

	void Awake(){
		// Lock at 30 fps
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 30;
		// Get component that will record for us
		record = Camera.main.gameObject.GetComponent<Record> ();
		// Store start rotation
		startRotation = transform.eulerAngles;
	}

	void FixedUpdate () {
		// Rotate
		transform.Rotate (0f, speed,0f);
		// Check if has completed a 360 rotation
		if( transform.eulerAngles.y == 0f || Vector3.Distance(transform.eulerAngles, startRotation) < 0.1f){
			// Make sure to stop at right position
			transform.rotation = Quaternion.Euler (0f,0f,0f);
			// Stop recording
			record.StopRecording ();
			// Stop this script
			enabled = false;
		}
	}
}
