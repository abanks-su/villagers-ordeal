using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private DirectionFacing myDirectionScript;
	private Rigidbody myRigidbody;
	//private BoxCollider2D myBoxCollider;
	public float playerspeed = 75.0f;
	public float jumpForce = 80000.0f;
	private bool canJump;

	//variables for SetVelocityOfMainCharacter... function
	private bool isPlayerVelocitySet;
	private Vector3 controlledVelocity;
	private float controlOfPlayerCountdown;

	//variables for singleJump vs doubleJump
	private float singleJumpDelayTime = 0.2f;
	private float singleJumpCountdown;
	private EnabledAbilities myEnabledAbilitiesScript;
	private bool grounded = false;

	//variables for sound effects
	public AudioSource jumpSoundSource;
	public AudioSource footstepsSoundSource;

	// Use this for initialization
	void Start () {
	
		myDirectionScript = GetComponent<DirectionFacing> ();
		myRigidbody = GetComponent<Rigidbody> ();
		//myBoxCollider = GetComponent<BoxCollider2D> ();
		//playerspeed = 75.0f;
		//jumpForce = 80000.0f;
		canJump = true;

		isPlayerVelocitySet = false;

		singleJumpCountdown = 0f;
		myEnabledAbilitiesScript = GetComponent<EnabledAbilities> ();

	}
		
	public void SetVelocityOfMainCharacterforGivenDuration (Vector3 givenVelocity, float givenDuration) {
		isPlayerVelocitySet = true;
		controlledVelocity = givenVelocity;
		controlOfPlayerCountdown = givenDuration;
	}

	public void setGrounded (bool val) {
		grounded = val;
	}

	public void ResetJump () {
		if (myEnabledAbilitiesScript.getCanDoubleJump ()) {
			canJump = true;
		} else {
			if (singleJumpCountdown <= 0) {
				canJump = true;
			}
		}
	}

	/*
	public void CannotJumpBecauseInAir () {
		if (!myEnabledAbilitiesScript.getCanDoubleJump ()) {
			canJump = false;
		}
	}
	*/

	// Update is called once per frame
	void Update () {

		if (isPlayerVelocitySet) {
			controlOfPlayerCountdown -= Time.deltaTime;
			if (controlOfPlayerCountdown <= 0) {
				isPlayerVelocitySet = false;
			}
		}

		float yVelocity = myRigidbody.velocity.y;
		float xVelocity = Input.GetAxis ("Horizontal") * playerspeed;
		if (xVelocity > 0) {
			myDirectionScript.SetFacingRight ();
		} else if (xVelocity < 0) {
			myDirectionScript.SetFacingLeft ();
		}

		if (isPlayerVelocitySet) {
			myRigidbody.velocity = controlledVelocity;
		} else {
			myRigidbody.velocity = new Vector3 (xVelocity, yVelocity, 0);
		}

		if ((Input.GetButtonDown("Jump")) && (canJump)) {
			Jump ();
		}

		if (singleJumpCountdown >= 0f) {
			singleJumpCountdown -= Time.deltaTime;
		}

		//Set sound for footsteps
		if (grounded && ((Input.GetAxis ("Horizontal") <= -.2) || (Input.GetAxis ("Horizontal") >= .2))) {
			if (!footstepsSoundSource.isPlaying) {
				footstepsSoundSource.Play ();
			}
		} else {
			if (footstepsSoundSource.isPlaying) {
				footstepsSoundSource.Stop ();
			}
		}
	}

	private void Jump () {
		Debug.Log ("button pressed");
		myRigidbody.velocity = new Vector3 (myRigidbody.velocity.x, 0, 0);
		myRigidbody.AddForce(transform.up * jumpForce);
		canJump = false;
		singleJumpCountdown = singleJumpDelayTime;
		jumpSoundSource.Play ();
	}
}
