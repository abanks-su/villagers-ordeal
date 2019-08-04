using UnityEngine;
using System.Collections;

public class CastleSetupScene : MonoBehaviour {

	private GameObject playerObjectInScene;
	private Transform playerTransform;

	private PlayerPrefsInteractions myPlayerPrefsInteractor;
	private int checkpointToLoadInto;

	//Objects that might be dissabled on Load
	public GameObject topButtonBlockade;
	public GameObject botButtonBlockade;

	//Variables for individual CheckPoints
	//Checkpoint 1
	private Vector3 cp1Position = new Vector3 (650.0f, 110.0f, 0.0f);

	private void InitializeRefrences () {
		playerObjectInScene = GameObject.FindGameObjectWithTag ("Player");
		playerTransform = playerObjectInScene.GetComponent<Transform> ();

		myPlayerPrefsInteractor = GetComponent<PlayerPrefsInteractions> ();
		checkpointToLoadInto = myPlayerPrefsInteractor.GetCheckpointCounter ();
	}

	private void InitializeCastleKeys () {

		PlayerPrefs.SetInt ("CastleSetupListExistKey", 1);

		PlayerPrefs.SetInt ("TopButtonBlockadeEnabledKey", 1);
		PlayerPrefs.SetInt ("BotButtonBlockadeEnabledKey", 1);
	}

	// Use this for initialization
	void Start () {

		InitializeRefrences ();
		if (!PlayerPrefs.HasKey("CastleSetupListExistKey")) {
			InitializeCastleKeys ();
		}
		SetLevelForKeys ();
		SetLevelForCheckpoint ();

	}

	private void SetLevelForKeys () {
		
		if (PlayerPrefs.GetInt ("TopButtonBlockadeEnabledKey") == 0) {
			topButtonBlockade.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("BotButtonBlockadeEnabledKey") == 0) {
			botButtonBlockade.SetActive (false);
		}
	}

	private void SetLevelForCheckpoint () {
		if (checkpointToLoadInto == 1) {
			CheckPoint1 ();
		}
	}

	private void CheckPoint1 () {
		playerTransform.position = cp1Position;
	}

	public void PlayerCollectPushyServantEmblem () {
		myPlayerPrefsInteractor.PlayerAcquiredPushyServant ();
	}

	public void DisableTopButtonBlockade () {
		PlayerPrefs.SetInt ("TopButtonBlockadeEnabledKey", 0);
		//Debug.Log ("TOP");
	}

	public void DisableBottomButtonBlockade () {
		PlayerPrefs.SetInt ("BotButtonBlockadeEnabledKey", 0);
		//Debug.Log ("BOT");
	}

	//DISABLE OBJECTS ON LOAD

}
