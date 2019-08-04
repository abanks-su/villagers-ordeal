using UnityEngine;
using System.Collections;

public class FloatCollectable : MonoBehaviour {

	private GameObject myPlayerPrefsInteractor;
	private PlayerPrefsInteractions myPlayerPrefsScript;

	// Use this for initialization
	void Start () {

		myPlayerPrefsInteractor = GameObject.FindGameObjectWithTag("PlayerPrefsInteractor");
		if (myPlayerPrefsInteractor != null) {
			myPlayerPrefsScript = myPlayerPrefsInteractor.GetComponent<PlayerPrefsInteractions> ();
		}
	}

	void OnTriggerEnter(Collider coll) {
		if (myPlayerPrefsScript != null) {
			if (coll.tag == "Player") {
				myPlayerPrefsScript.PlayerAcquiredFloat ();
				Destroy (this.gameObject);
			}
		}
	}
}
