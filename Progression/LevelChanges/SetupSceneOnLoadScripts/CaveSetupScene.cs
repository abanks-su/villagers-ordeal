using UnityEngine;
using System.Collections;

public class CaveSetupScene : MonoBehaviour {

	private GameObject playerObjectInScene;
	private Transform playerTransform;

	private PlayerPrefsInteractions myPlayerPrefsInteractor;
	private int checkpointToLoadInto;

	public GameObject[] objectsToEnableOnCollectDodgeRoll;

	//Variables for individual CheckPoints
	//Checkpoint 1
	private Vector3 cp1Position = new Vector3 (-30.0f, 50.0f, 0.0f);
	//Checkpoint 2
	private Vector3 cp2Position = new Vector3 (-790.0f, 345.0f, 0.0f);
	public GameObject[] objectsToEnableOnCp2Load;
	public GameObject[] objectsToDisableOnCp2Load;

	private void InitializeRefrences () {
		playerObjectInScene = GameObject.FindGameObjectWithTag ("Player");
		playerTransform = playerObjectInScene.GetComponent<Transform> ();

		myPlayerPrefsInteractor = GetComponent<PlayerPrefsInteractions> ();
		checkpointToLoadInto = myPlayerPrefsInteractor.GetCheckpointCounter ();
	}

	// Use this for initialization
	void Start () {

		InitializeRefrences ();
		SetLevelForCheckpoint ();
	}

	private void SetLevelForCheckpoint () {
		if (checkpointToLoadInto == 1) {
			CheckPoint1 ();
		}
		if (checkpointToLoadInto == 2) {
			Checkpoint2 ();
		}
	}

	private void CheckPoint1 () {
		playerTransform.position = cp1Position;
	}

	private void Checkpoint2 () {
		playerTransform.position = cp2Position;
		foreach (GameObject item in objectsToEnableOnCp2Load) {
			item.SetActive (true);
		}
		foreach (GameObject item in objectsToDisableOnCp2Load) {
			item.SetActive (false);
		}
	}

	public void PlayerCollectGrappleEmblem () {

		myPlayerPrefsInteractor.PlayerAcquiredGrapple ();
	}

	public void PlayerCollectDodgeRollEmblem () {
		
		myPlayerPrefsInteractor.PlayerAcquiredDodgeRoll ();

		foreach (GameObject item in objectsToEnableOnCollectDodgeRoll) {
			item.SetActive (true);
		}
	}


	// Update is called once per frame
	void Update () {

	}
}
