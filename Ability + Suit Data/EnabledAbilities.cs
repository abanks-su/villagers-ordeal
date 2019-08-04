using UnityEngine;
using System.Collections;

public class EnabledAbilities : MonoBehaviour {

	//A script that keeps track of the abilities that are currently active.
	//This is not all the abilities that have been collected and are available across all suits,
	//    that is stored in collected abilities.
	//The abilities that are enabled in this script are based on the suit the player is currently in.

	public bool canDoubleJump;
	public bool canFloat;
	public bool canThrowBlocks;
	public bool canFireBolt;
	public bool canFireGrapple;
	public bool canDodgeRoll;
	public bool canPushyServant;
	public bool canBombServant;

	//setters
	public void setCanDoubleJump(bool newSetting) {
		canDoubleJump = newSetting;
	}

	public void setCanFloat(bool newSetting) {
		canFloat = newSetting;
	}

	public void setCanThrowBlocks(bool newSetting) {
		canThrowBlocks = newSetting;
	}

	public void setCanFireBolt(bool newSetting) {
		canFireBolt = newSetting;
	}

	public void setCanFireGrapple(bool newSetting) {
		canFireGrapple = newSetting;
	}

	public void setCanDodgeRoll(bool newSetting) {
		canDodgeRoll = newSetting;
	}

	public void setCanPushyServant(bool newSetting) {
		canPushyServant = newSetting;
	}

	public void setCanBombServant(bool newSetting) {
		canBombServant = newSetting;
	}

	//getters
	public bool getCanDoubleJump () {
		return canDoubleJump;
	}

	public bool getCanFloat () {
		return canFloat;
	}

	public bool getCanThrowBlocks () {
		return canThrowBlocks;
	}

	public bool getCanFireBolt () {
		return canFireBolt;
	}

	public bool getCanFireGrapple () {
		return canFireGrapple;
	}

	public bool getCanDodgeRoll () {
		return canDodgeRoll;
	}

	public bool getCanPushyServant () {
		return canPushyServant;
	}

	public bool getCanBombServant () {
		return canBombServant;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
