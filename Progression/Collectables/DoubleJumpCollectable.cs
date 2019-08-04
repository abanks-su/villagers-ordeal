using UnityEngine;
using System.Collections;

public class DoubleJumpCollectable : MonoBehaviour {

	private GameObject myPlayerPrefsInteractor;
	private VillageSetupScene myVillageSetup;

	// Use this for initialization
	void Start () {
		
		myPlayerPrefsInteractor = GameObject.FindGameObjectWithTag("PlayerPrefsInteractor");
		if (myPlayerPrefsInteractor != null) {
			myVillageSetup = myPlayerPrefsInteractor.GetComponent<VillageSetupScene> ();
		}
	}

	void OnTriggerEnter(Collider coll) {
		if (myVillageSetup != null) {
			if (coll.tag == "Player") {
				myVillageSetup.PlayerCollectDoubleJumpEmblem ();
				Destroy (this.gameObject);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
