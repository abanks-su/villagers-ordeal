using UnityEngine;
using System.Collections;

public class DodgeRoll : MonoBehaviour {

	public float durationOfRoll;
	public float speedWhenRollingX;
	public float speedWhenRollingY;
	public float abilityEndLag;

	private Vector3 speedWhenRollingVector;
	private float countdown;
	private bool currentlyRolling;

	private GameObject playerObject;
	private CooldownFromAbilitiesHandler myCooldownHandler;
	private Movement myPlayerMovement;
	private DirectionFacing myPlayerDirection;
	private MCCollisionNew myPlayerCollisionHandler;
	private EnabledAbilities myPlayerEnabledAbilities;

	// Use this for initialization
	void Start () {
	
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		myCooldownHandler = playerObject.GetComponent<CooldownFromAbilitiesHandler> ();
		myPlayerMovement = playerObject.GetComponent<Movement> ();
		myPlayerDirection = playerObject.GetComponent<DirectionFacing> ();
		myPlayerCollisionHandler = playerObject.GetComponentInChildren<MCCollisionNew> ();
		myPlayerEnabledAbilities = playerObject.GetComponent<EnabledAbilities> ();

		currentlyRolling = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (currentlyRolling) {
			countdown -= Time.deltaTime;
			if (countdown <= 0) {
				EndTheRoll ();
			}
		}

		if (Input.GetButtonDown ("Roll")) {
			if (myPlayerEnabledAbilities.getCanDodgeRoll()) {
				if (myCooldownHandler.AttemptMovementTwoWithGivenCooldown (abilityEndLag)) {
					DoARoll ();
				}
			}
		}
	}

	private void DoARoll() {

		currentlyRolling = true;
		countdown = durationOfRoll;

		if (myPlayerDirection.getFacingRight ()) {
			speedWhenRollingVector = new Vector3 (speedWhenRollingX, speedWhenRollingY, 0.0f);
		} else {
			speedWhenRollingVector = new Vector3 (-speedWhenRollingX, speedWhenRollingY, 0.0f);
		}
		myPlayerMovement.SetVelocityOfMainCharacterforGivenDuration (speedWhenRollingVector, durationOfRoll);
		myCooldownHandler.FreezeAttackingForGivenDuration (durationOfRoll);
		myPlayerCollisionHandler.DisableHitbox ();
	}

	private void EndTheRoll() {
		currentlyRolling = false;

		myPlayerCollisionHandler.EnableHitbox ();
	}
}
