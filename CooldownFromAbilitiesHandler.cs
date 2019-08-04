using UnityEngine;
using System.Collections;

public class CooldownFromAbilitiesHandler : MonoBehaviour {

	private bool canDoAttackAbility;
	private bool canDoMovementAbilityOne;
	private bool canDoMovementAbilityTwo;
	private float attackCountdown;
	private float movementCountdownOne;
	private float movementCountdownTwo;

	// Use this for initialization
	void Start () {
	
		canDoAttackAbility = true;
		canDoMovementAbilityOne = true;
		canDoMovementAbilityTwo = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (attackCountdown >= 0) {
			attackCountdown = attackCountdown - Time.deltaTime;
		}

		if (attackCountdown <= 0) {
			canDoAttackAbility = true;
		}

		if (movementCountdownOne >= 0) {
			movementCountdownOne = movementCountdownOne - Time.deltaTime;
		}

		if (movementCountdownOne <= 0) {
			canDoMovementAbilityOne = true;
		}

		if (movementCountdownTwo >= 0) {
			movementCountdownTwo = movementCountdownTwo - Time.deltaTime;
		}

		if (movementCountdownTwo <= 0) {
			canDoMovementAbilityTwo = true;
		}
	}



	//keeps the player from executing an attack ability for a given duration
	public void FreezeAttackingForGivenDuration(float abilityCooldown) {
		if (abilityCooldown > attackCountdown) {
			attackCountdown = abilityCooldown;
			canDoAttackAbility = false;
		}
	}

	//asks the cooldown handler if it is possibele to do an attack ability
	//if so true is returned and the cooldown given is put on the cooldown for attack abilities
	public bool AttemptAbilityWithGivenCooldown(float abilityCooldown) {

		if (abilityCooldown < 0) {
			return false;
		}

		if (canDoAttackAbility) {

			attackCountdown = abilityCooldown;
			canDoAttackAbility = false;
			return true;
		}
		return false;
	}

	//asks the cooldown handler if it is possibele to do a movement ability
	//if so true is returned and the cooldown given is put on the cooldown for movement abilities
	public bool AttemptMovementWithGivenCooldown(float movementCooldown) {
		
		if (movementCooldown < 0) {
			return false;
		}

		if (canDoMovementAbilityOne) {

			movementCountdownOne = movementCooldown;
			canDoMovementAbilityOne = false;
			return true;
		}
		return false;
	}

	public bool AttemptMovementTwoWithGivenCooldown(float movementCooldown) {

		if (movementCooldown < 0) {
			return false;
		}

		if (canDoMovementAbilityTwo) {

			movementCountdownTwo = movementCooldown;
			canDoMovementAbilityTwo = false;
			return true;
		}
		return false;
	}
}
