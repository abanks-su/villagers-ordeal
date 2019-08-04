using UnityEngine;
using System.Collections;

public class FireGrapple : MonoBehaviour {

	public Transform myGrappleBoltPrefab;
	public float abilityEndLag;

	private GameObject playerObject;
	private CooldownFromAbilitiesHandler myCooldownHandler;
	private EnabledAbilities myPlayerEnabledAbilities;

	// Use this for initialization
	void Start () {

		playerObject = GameObject.FindGameObjectWithTag ("Player");
		myCooldownHandler = playerObject.GetComponent<CooldownFromAbilitiesHandler> ();
		myPlayerEnabledAbilities = playerObject.GetComponent<EnabledAbilities> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("FireGrapple")) {
			if (myPlayerEnabledAbilities.getCanFireGrapple ()) {
				if (myCooldownHandler.AttemptMovementWithGivenCooldown (abilityEndLag)) {
					Instantiate (myGrappleBoltPrefab, this.transform.position, Quaternion.identity);
					Debug.Log ("BANG!");
				}
			}
		}
	}
}
