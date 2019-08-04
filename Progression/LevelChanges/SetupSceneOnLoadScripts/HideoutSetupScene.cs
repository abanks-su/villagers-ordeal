using UnityEngine;
using System.Collections;

public class HideoutSetupScene : MonoBehaviour {

	private GameObject playerObjectInScene;
	private Transform playerTransform;

	private PlayerPrefsInteractions myPlayerPrefsInteractor;
	private int checkpointToLoadInto;

	//Variables for individual CheckPoints
	//Checkpoint 1
	private Vector3 cp1Position = new Vector3 (820.0f, 0.0f, 0.0f);


	//Checkpoint 2
	private Vector3 cp2Position = new Vector3 (2150, 315, 0);
	public GameObject[] objsToEnableOnCp2Load;
	public GameObject[] objsToDisableOnCp2Load;

	//Checkpoint 3
	private Vector3 cp3Position = new Vector3 (980, 0, 0);
	public GameObject[] objsToEnableOnCp3Load;
	public GameObject[] objsToDisableOnCp3Load;

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
			CheckPoint2 ();
		}
		if (checkpointToLoadInto == 3) {
			CheckPoint3 ();
		}
	}

	private void CheckPoint1 () {
		playerTransform.position = cp1Position;
	}

	private void CheckPoint2 () {
		playerTransform.position = cp2Position;

		foreach (GameObject item in objsToEnableOnCp2Load) {
			item.SetActive (true);
		}

		foreach (GameObject item in objsToDisableOnCp2Load) {
			item.SetActive (false);
		}
	}

	private void CheckPoint3 () {
		playerTransform.position = cp3Position;

		foreach (GameObject item in objsToEnableOnCp3Load) {
			item.SetActive (true);
		}

		foreach (GameObject item in objsToDisableOnCp3Load) {
			item.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
