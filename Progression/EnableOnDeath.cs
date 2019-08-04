using UnityEngine;
using System.Collections;

public class EnableOnDeath : MonoBehaviour {

	public GameObject[] objectsToEnable;

	public void EnableObjects () {
		foreach (GameObject item in objectsToEnable) {
			item.SetActive (true);
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
