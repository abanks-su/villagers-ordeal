using UnityEngine;
using System.Collections;

public class ServantMovment : MonoBehaviour {

	private GameObject playerChar;
	private DirectionFacing playerDirection;
	private Rigidbody myRigidbody;
	public float servantMoveSpeed;

	// Use this for initialization
	void Start () {
	
		playerChar = GameObject.FindGameObjectWithTag ("Player");
		playerDirection = playerChar.GetComponent<DirectionFacing> ();
		myRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (playerDirection.getFacingRight ()) {
			myRigidbody.velocity = new Vector3 (servantMoveSpeed, myRigidbody.velocity.y, 0);
		} else {
			myRigidbody.velocity = new Vector3 (-servantMoveSpeed, myRigidbody.velocity.y, 0);
		}
	}
}
