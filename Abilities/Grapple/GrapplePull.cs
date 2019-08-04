using UnityEngine;
using System.Collections;

public class GrapplePull : MonoBehaviour {

	private GameObject playerObject;
	private Transform playerTransform;

	// Use this for initialization
	void Start () {
	
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		playerTransform = playerObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		/*
		if (other.tag == "GrapplePoint") {
			playerTransform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			Destroy (this.gameObject);
			*/

		if (other.tag == "GrapplePoint") {

			Transform otherTransform = other.GetComponent<Transform> ();

			playerTransform.position = new Vector3 (otherTransform.position.x, otherTransform.position.y, otherTransform.position.z);
			Destroy (this.gameObject);
		}
	}
}
