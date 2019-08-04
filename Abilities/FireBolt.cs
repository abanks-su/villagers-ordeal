using UnityEngine;
using System.Collections;

public class FireBolt : MonoBehaviour {

	public Transform myCrossbowBoltPrefab;
	public float abilityEndLag;

	private GameObject playerObject;
	private CooldownFromAbilitiesHandler myCooldownHandler;
	private EnabledAbilities myEnabledAbilities;

	// Use this for initialization
	void Start () {
	
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		myCooldownHandler = playerObject.GetComponent<CooldownFromAbilitiesHandler> ();
		myEnabledAbilities = playerObject.GetComponent<EnabledAbilities> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown("FireBolt")) {
			if (myEnabledAbilities.getCanFireBolt ()) {
				if (myCooldownHandler.AttemptAbilityWithGivenCooldown (abilityEndLag)) {
					Instantiate (myCrossbowBoltPrefab, this.transform.position, Quaternion.identity);
					Debug.Log ("BANG!");
				}
			}
		}
	}
}
