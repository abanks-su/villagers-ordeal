using UnityEngine;
using System.Collections;

public class SuitChangeScript : MonoBehaviour {

	private GameObject myPlayerPrefsInteractor;
	private PlayerPrefsInteractions myPlayerPrefsScript;
	private CollectedAbilities myCollectedAbilities;
	private EnabledAbilities myEnabledAbilities;

	// Use this for initialization
	void Start () {
		myCollectedAbilities = GetComponent<CollectedAbilities> ();
		myEnabledAbilities = GetComponent<EnabledAbilities> ();

		myPlayerPrefsInteractor = GameObject.FindGameObjectWithTag("PlayerPrefsInteractor");
		if (myPlayerPrefsInteractor != null) {
			myPlayerPrefsScript = myPlayerPrefsInteractor.GetComponent<PlayerPrefsInteractions> ();
		}
	}

	public void collectRogueSuit () {
		
	}

	public void collectKingSuit () {
		
	}

	public void setVillagerSuit () {
		myPlayerPrefsScript.setVillagerSuit ();
		updateEnabledAbilities ();
	}

	public void setRogueSuit () {
		if (myPlayerPrefsScript.getHasCollectedRogueSuit()) {
			myPlayerPrefsScript.setRogueSuit ();
			updateEnabledAbilities ();
		}
	}

	public void setKingSuit () {
		if (myPlayerPrefsScript.getHasCollectedKingSuit ()) {
			myPlayerPrefsScript.setKingSuit ();
			updateEnabledAbilities ();
		}
	}

	public void updateEnabledAbilities () {
		disableAllAbilities ();

		if (myPlayerPrefsScript.getIsVillagerSuit ()) { //villager
			if (myCollectedAbilities.getCanDoubleJump ()) {
				myEnabledAbilities.setCanDoubleJump (true);
			}
			if (myCollectedAbilities.getCanFloat ()) {
				myEnabledAbilities.setCanFloat (true);
			}
			if (myCollectedAbilities.getCanThrowBlocks ()) {
				myEnabledAbilities.setCanThrowBlocks (true);
			}
		}
		if (myPlayerPrefsScript.getIsRogueSuit ()) { //rogue
			if (myCollectedAbilities.getCanFireBolt ()) {
				myEnabledAbilities.setCanFireBolt (true);
			}
			if (myCollectedAbilities.getCanFireGrapple ()) {
				myEnabledAbilities.setCanFireGrapple (true);
			}
			if (myCollectedAbilities.getCanDodgeRoll ()) {
				myEnabledAbilities.setCanDodgeRoll (true);
			}
		}
		if (myPlayerPrefsScript.getIsKingSuit ()) { //king
			if (myCollectedAbilities.getCanBombServant ()) {
				myEnabledAbilities.setCanBombServant (true);
			}
			if (myCollectedAbilities.getCanPushyServant ()) {
				myEnabledAbilities.setCanPushyServant (true);
			}
		}
	}

	private void disableAllAbilities () {
		myEnabledAbilities.setCanBombServant (false);
		myEnabledAbilities.setCanDodgeRoll (false);
		myEnabledAbilities.setCanDoubleJump (false);
		myEnabledAbilities.setCanFireBolt (false);
		myEnabledAbilities.setCanFireGrapple (false);
		myEnabledAbilities.setCanFloat (false);
		myEnabledAbilities.setCanPushyServant (false);
		myEnabledAbilities.setCanThrowBlocks (false);
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
