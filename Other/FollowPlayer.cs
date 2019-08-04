using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	private GameObject myPlayerObject;
	private Transform myPlayerTransform;
	private float xOffset;
	private float yOffset;
	private bool followX;
	private bool followY;

	// Use this for initialization
	void Start () {
	
		myPlayerObject = GameObject.FindGameObjectWithTag ("Player");
		myPlayerTransform = myPlayerObject.GetComponent<Transform> ();
		xOffset = 0.0f;
		yOffset = 20.0f;
		followX = true;
		followY = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		float newPositionX = transform.position.x;
		float newPositionY = transform.position.y;

		if (followX) {
			newPositionX = myPlayerTransform.position.x + xOffset;
		}

		if (followY) {
			newPositionY = myPlayerTransform.position.y + yOffset;
		}

		transform.position = new Vector3 (newPositionX, newPositionY, transform.position.z);
	}
}
