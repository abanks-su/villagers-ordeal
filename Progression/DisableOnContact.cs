using UnityEngine;
using System.Collections;

public class DisableOnContact : MonoBehaviour {


	public GameObject[] objectsToDisableOnContact;

	void OnTriggerEnter(Collider coll) {
		if (coll.tag == "Player") {
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
