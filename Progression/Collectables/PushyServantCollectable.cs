using UnityEngine;
using System.Collections;

public class PushyServantCollectable : MonoBehaviour {

	private GameObject myPlayerPrefsInteractor;
	private CastleSetupScene myCastleSeutup;

	// Use this for initialization
	void Start () {

		myPlayerPrefsInteractor = GameObject.FindGameObjectWithTag("PlayerPrefsInteractor");
		if (myPlayerPrefsInteractor != null) {
			myCastleSeutup = myPlayerPrefsInteractor.GetComponent<CastleSetupScene> ();
		}
	}

	void OnTriggerEnter(Collider coll) {
		if (myCastleSeutup != null) {
			if (coll.tag == "Player") {
				myCastleSeutup.PlayerCollectPushyServantEmblem ();
				Destroy (this.gameObject);
			}
		}
	}
}
