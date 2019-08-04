using UnityEngine;
using System.Collections;

public class CrossbowCollectable : MonoBehaviour {

	private GameObject myPlayerPrefsInteractor;
	private PlayerPrefsInteractions myPlayerPrefsScript;

	public GameObject[] objectsToEnableOnCollect;

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
				myPlayerPrefsScript.PlayerAcquiredCrossbow ();
				EnableObjects ();
				Destroy (this.gameObject);
			}
		}
	}

	private void EnableObjects () {
		foreach (GameObject item in objectsToEnableOnCollect) {
			item.SetActive (true);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
