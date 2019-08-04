using UnityEngine;
using System.Collections;

public class _SetupSceneBasicTemplate : MonoBehaviour {

	private GameObject playerObjectInScene;
	private Transform playerTransform;

	private PlayerPrefsInteractions myPlayerPrefsInteractor;
	private int checkpointToLoadInto;

	//Variables for individual CheckPoints
	//Checkpoint 1
	private Vector3 cp1Position = new Vector3 (0.0f, 0.0f, 0.0f);

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
	}

	private void CheckPoint1 () {
		playerTransform.position = cp1Position;
	}
		

	// Update is called once per frame
	void Update () {

	}
}
