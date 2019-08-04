using UnityEngine;
using System.Collections;

/*
 * EnemyCollisionDetection.cs notices when an enemy has been hit
 * by a projectile fired by the main character and changes the enemy's
 * health accordingly.
 */

public class EnemyCollisionDetection : MonoBehaviour {

	private EnemyHealth myHealthScript;

	// Use this for initialization
	void Start () {
		myHealthScript = GetComponent<EnemyHealth>(); //get a reference to the enemy's health
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//on collision
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "AllyProjectile") {//if the projectile is an ally projectile

			//find the projectiles data
			ProjectileData hitData = other.gameObject.GetComponent<ProjectileData> ();

			//deal damage according to its data
			myHealthScript.takeDamage (hitData.getDamage());

			//if the projectile is DestroyOnHit destroy the projectile
			if (hitData.getDestroyOnHit ()) {
				Destroy (other.gameObject);
			}
		}
	}
}
