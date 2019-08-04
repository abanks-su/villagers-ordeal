using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public int checkpointID;
	public GameObject nextCheckpoint;

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
				myPlayerPrefsScript.SetCheckpointCounter (checkpointID);
				if (nextCheckpoint != null) {
					nextCheckpoint.SetActive (true);
				}
				Destroy (this.gameObject);
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
