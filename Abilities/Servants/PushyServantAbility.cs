using UnityEngine;
using System.Collections;

public class PushyServantAbility : MonoBehaviour {

	public GameObject PushyServantPrefab;
	public float xOffset;

	private DirectionFacing myDirectionFacing;
	private EnabledAbilities myEnabledAbilities;

	// Use this for initialization
	void Start () {
		myDirectionFacing = this.GetComponent<DirectionFacing> ();
		myEnabledAbilities = this.GetComponent<EnabledAbilities> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown ("PushyServant")) {
			if (myEnabledAbilities.getCanPushyServant ()) {
				if (null == GameObject.FindGameObjectWithTag ("Servant")) {
					//there are no servants in the game
					SpawnServant ();
				}
			}
		}
	}

	private void SpawnServant () {

		Vector3 servantStartingPosition;
		if (myDirectionFacing.getFacingRight()) {
			servantStartingPosition = new Vector3 (this.transform.position.x + xOffset, this.transform.position.y, this.transform.position.z);
		} else {
			servantStartingPosition = new Vector3 (this.transform.position.x - xOffset, this.transform.position.y, this.transform.position.z);
		}
		Instantiate (PushyServantPrefab, servantStartingPosition, Quaternion.identity);
	}
}
