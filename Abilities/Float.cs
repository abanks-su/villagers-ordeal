using UnityEngine;
using System.Collections;

public class Float : MonoBehaviour {

	public float floatSpeed;
	private Rigidbody myRigidbody;
	//private Vector3 myVectorForce;
	private EnabledAbilities myEnabledAbilities;

	public AudioSource mySoundEffectSource;
	private bool soundPlayingFlag = false;

	// Use this for initialization
	void Start () {
	
		//myVectorForce = new Vector3 (0, floatForce, 0);
		myRigidbody = GetComponent<Rigidbody> ();
		myEnabledAbilities = GetComponent<EnabledAbilities> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButton("Float")) {
			if (myEnabledAbilities.getCanFloat ()) {
				Debug.Log ("inFloat");
				if (myRigidbody.velocity.y < floatSpeed) {
					Debug.Log ("inFloatFalling");
					Debug.Log (myRigidbody.velocity.y);
					myRigidbody.velocity = new Vector3 (myRigidbody.velocity.x, floatSpeed, 0);

					soundPlayingFlag = true;
					if (!mySoundEffectSource.isPlaying) {
						mySoundEffectSource.Play ();
					}
				}
			}
		}

		if (!soundPlayingFlag) {
			mySoundEffectSource.Stop ();
		}
		soundPlayingFlag = false;
	}
}
