using UnityEngine;
using System.Collections;

public class BoxThrowCollectable : MonoBehaviour {

	public int collectableID;

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

				if (collectableID == 1) {
					myVillageSetup.PlayerCollectBoxThrowEmblem1 ();
				}

				if (collectableID == 2) {
					myVillageSetup.PlayerCollectBoxThrowEmblem2 ();
				}

				if (collectableID == 3) {
					myVillageSetup.PlayerCollectBoxThrowEmblem3 ();
				}

				if (collectableID == 4) {
					myVillageSetup.PlayerCollectBoxThrowEmblem4 ();
				}

				Destroy (this.gameObject);
			}
		}
	}


	// Update is called once per frame
	void Update () {
	
	}
}
