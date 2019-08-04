using UnityEngine;
using System.Collections;

public class DisableOnDeath : MonoBehaviour {

	public GameObject[] objectsToDisable;

	public void disableObjects () {
		foreach (GameObject item in objectsToDisable) {
			item.SetActive (false);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
