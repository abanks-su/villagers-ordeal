using UnityEngine;
using System.Collections;

public class GrabPlayerData : MonoBehaviour {

	private bool amIHoldingSomething;
	private bool throwingObject;
	private float throwDelay;
	private float countdown;
	private GameObject myPlayer;
	private EnabledAbilities myEnabledAbilities;

	// Use this for initialization
	void Start () {
	
		amIHoldingSomething = false;
		throwDelay = 0.2f;
		myPlayer = this.gameObject;
		myEnabledAbilities = myPlayer.GetComponent<EnabledAbilities> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (throwingObject) {
			countdown = countdown - Time.deltaTime;
			if (countdown < 0f) {
				//the throw is completed and objects can be picked up again
				throwingObject = false;
				amIHoldingSomething = false;
			}
		}
	}

	//this function is called by an object that can be grabbed in ObjectCanBeGrabbed.cs 
	//if the player is not holding anything then that object will be picked up
	public bool IWouldLikeToBePickedUp () {

		if (myEnabledAbilities.getCanThrowBlocks()) {
			if (!amIHoldingSomething) {
				amIHoldingSomething = true;
				return true;
			} else {
				return false;
			}
		}
		return false;
	}

	//Lets the main character know that the object is being thrown
	//and that the main character is no longer holding anything
	public void ImBeingThrown () {
		throwingObject = true;
		countdown = throwDelay;
		//before an object can be picked up again there is a slight time delay
		//implemented by a countdown
	}
}
