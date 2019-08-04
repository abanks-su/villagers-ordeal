using UnityEngine;
using System.Collections;

public class ChangingBooth : MonoBehaviour {

	private GameObject playerObjectInScene;
	private SuitChangeScript mySuitChangeScript;

	// Use this for initialization
	void Start () {
	
		playerObjectInScene = GameObject.FindGameObjectWithTag ("Player");
		mySuitChangeScript = playerObjectInScene.GetComponent<SuitChangeScript> ();
	}


	void OnTriggerStay(Collider coll) {
		if (coll.tag == "Player") {

			if (Input.GetButtonDown ("VillagerSuit")) {
				mySuitChangeScript.setVillagerSuit ();
			}
			if (Input.GetButtonDown ("RogueSuit")) {
				mySuitChangeScript.setRogueSuit ();
			}
			if (Input.GetButtonDown ("KingSuit")) {
				mySuitChangeScript.setKingSuit ();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
