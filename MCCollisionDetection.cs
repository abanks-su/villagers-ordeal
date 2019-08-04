using UnityEngine;
using System.Collections;

/*
 * This script controls what happens when the main character
 * is hit by a projectile shot by an enemy
 */

public class MCCollisionDetection : MonoBehaviour {

	private MCHealth myHealthScript;

	// Use this for initialization
	void Start () {
		//get a refrence to the MCHealth Script
		myHealthScript = this.GetComponentInParent<MCHealth>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other)
	{

		Debug.Log ("Touch");
		//if the main character collides with an enemy projectile
		if ((other.gameObject.tag == "EnemyProjectile")) {

			Debug.Log ("Hit");

			//get data from the projectile
			ProjectileData hitData = other.gameObject.GetComponent<ProjectileData> ();

			//take damage based on the projectile data
			myHealthScript.takeDamage (hitData.getDamage ());

			//if the projectile is to be destroyed on hit destroy it
			if (hitData.getDestroyOnHit ()) {
				Destroy (other.gameObject);
			}
		}
	}
}
