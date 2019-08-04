using UnityEngine;
using System.Collections;

public class DisableOnServantContact : MonoBehaviour {

	public GameObject[] objectsToDisableOnContact;

	void OnTriggerEnter(Collider coll) {
		if (coll.tag == "Servant") {
			DisableObjects ();
		}
	}

	void DisableObjects () {
		foreach (GameObject item in objectsToDisableOnContact) {
			item.SetActive (false);
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
