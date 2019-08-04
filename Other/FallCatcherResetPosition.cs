using UnityEngine;
using System.Collections;

public class FallCatcherResetPosition : MonoBehaviour {

	public float ResetPositionX;
	public float ResetPositionY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.tag == "Player") {
			GameObject player = coll.gameObject;
			Transform playerTransform = player.GetComponent<Transform> ();
			Rigidbody playerRigidbody = player.GetComponent<Rigidbody> ();
			playerTransform.position = new Vector3 (ResetPositionX, ResetPositionY, playerTransform.position.z);
			playerRigidbody.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
		}
	}
}
