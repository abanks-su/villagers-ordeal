using UnityEngine;
using System.Collections;

public class DodgeRollCollectable : MonoBehaviour {

	private GameObject myPlayerPrefsInteractor;
	private CaveSetupScene myCaveSetup;

	// Use this for initialization
	void Start () {

		myPlayerPrefsInteractor = GameObject.FindGameObjectWithTag("PlayerPrefsInteractor");
		if (myPlayerPrefsInteractor != null) {
			myCaveSetup = myPlayerPrefsInteractor.GetComponent<CaveSetupScene> ();
		}
	}

	void OnTriggerEnter(Collider coll) {
		if (myCaveSetup != null) {
			if (coll.tag == "Player") {
				myCaveSetup.PlayerCollectDodgeRollEmblem ();
				Destroy (this.gameObject);
			}
		}
	}
}
