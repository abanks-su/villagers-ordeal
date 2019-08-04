using UnityEngine;
using System.Collections;

public class CollectedAbilities : MonoBehaviour {

	//A script that keeps track of all abilities that the player has access to across all suits.
	//This is not a list of the abilities that the player can perform based on the current suit,
	//    that is stored in EnabledAbilities
	//The abilities enabled in this script are all of the abilites that the player has collected over
	//the course of the game and will be able to utilize once he is in the proper suit

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
