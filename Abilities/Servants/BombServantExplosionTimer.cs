using UnityEngine;
using System.Collections;

public class BombServantExplosionTimer : MonoBehaviour {

	public float delayBeforeExplosion;
	public float durationOfExplosion;

	private float totalLifespanOfServant;

	private float timer;

	private GameObject myChildObject;

	// Use this for initialization
	void Start () {

		totalLifespanOfServant = delayBeforeExplosion + durationOfExplosion;

		timer = 0f;

		foreach (Transform child in transform) {
			myChildObject = child.gameObject;
		}

		myChildObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
		timer += Time.deltaTime;
		if (timer >= delayBeforeExplosion) {
			myChildObject.SetActive (true);
		}
		if (timer >= totalLifespanOfServant) {
			Destroy (myChildObject);
			Destroy (this.gameObject);
		}
	}
}
