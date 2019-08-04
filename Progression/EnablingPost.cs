using UnityEngine;
using System.Collections;

public class EnablingPost : MonoBehaviour {

	public GameObject[] objectsToEnableOnCollect;

	void OnTriggerEnter(Collider coll) {
		if (coll.tag == "Player") {
			EnableObjects ();
			Destroy (this.gameObject);
		}
	}

	private void EnableObjects () {
		foreach (GameObject item in objectsToEnableOnCollect) {
			item.SetActive (true);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
