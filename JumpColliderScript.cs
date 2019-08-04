using UnityEngine;
using System.Collections;

public class JumpColliderScript : MonoBehaviour {

	private GameObject myPlayer;
	private Movement playerMovementScript;

	private bool areWeGrounded = false;
	private int groundedCheckDuration = 5;
	private int groundedCheckCountdown;

	// Use this for initialization
	void Start () {
	
		myPlayer = GameObject.FindWithTag ("Player");
		playerMovementScript = myPlayer.GetComponent<Movement> ();
		groundedCheckCountdown = groundedCheckDuration;
	}

	void OnTriggerStay(Collider coll) {
		string tag = coll.tag;
		if ((tag == "Floor") || (tag == "Enemy") || (tag == "Box") || (tag == "Servant")) {
			Debug.Log ("reset");
			playerMovementScript.ResetJump ();
			areWeGrounded = true;
			groundedCheckCountdown = groundedCheckDuration;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if (areWeGrounded) {
			groundedCheckCountdown--;
			if (groundedCheckCountdown <= 0) {
				areWeGrounded = false;
			}
		}

		playerMovementScript.setGrounded (areWeGrounded);
	}

	public bool getAreWeGrounded () {
		return areWeGrounded;
	}
}
