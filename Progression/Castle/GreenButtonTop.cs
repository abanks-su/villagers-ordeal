using UnityEngine;
using System.Collections;

public class GreenButtonTop : MonoBehaviour {

	private GameObject myPlayerPrefsInteractor;
	private PlayerPrefsInteractions myPlayerPrefsScript;
	private CastleSetupScene myCastleSetupScript;

	// Use this for initialization
	void Start () {

		myPlayerPrefsInteractor = GameObject.FindGameObjectWithTag("PlayerPrefsInteractor");
		if (myPlayerPrefsInteractor != null) {
			myPlayerPrefsScript = myPlayerPrefsInteractor.GetComponent<PlayerPrefsInteractions> ();
			myCastleSetupScript = myPlayerPrefsInteractor.GetComponent<CastleSetupScene> ();
		}
	}


	void OnTriggerStay(Collider coll) {
		if (myPlayerPrefsScript != null) {
			if (coll.tag == "Player") {
				myCastleSetupScript.DisableTopButtonBlockade ();
			}
		}
	}


}
