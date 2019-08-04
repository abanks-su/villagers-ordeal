using UnityEngine;
using System.Collections;

/*
 * keeps track of an enemys health and 
 * updates its status related to changes
 * in health
 */

public class EnemyHealth : MonoBehaviour {

	public int maxHealth = 100;
	public float timeSpentRed = .1f;
	private int currentHealth;
	private SpriteRenderer myRenderer;
	//this will be null if the enemy doesn't disable any other objects when it dies
	private DisableOnDeath myDisableOtherObjectsScript;
	private EnableOnDeath myEnableOtherObjectsScript;
	private Color myWhite = Color.white;
	private Color myRed = Color.red;
	private float countdownTimer;
	private bool amIRed;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		myRenderer = GetComponent<SpriteRenderer> ();
		myDisableOtherObjectsScript = GetComponent<DisableOnDeath> ();
		myEnableOtherObjectsScript = GetComponent<EnableOnDeath> ();
		countdownTimer = timeSpentRed;
	}
	
	// Update is called once per frame
	void Update () {
		//if the enemy is red
		if (amIRed) {
			//change the countdown based on time elapsed
			countdownTimer = countdownTimer - Time.deltaTime;
			//if the enemy has been red for long enough put it back to its origianl color
			if (countdownTimer <= 0) {
				myRenderer.color = myWhite;
				amIRed = false;
			}
		}
	}
	//function that allows other scripts to reduce the enemy's health
	public void takeDamage (int damage) {

		//reduce health
		currentHealth = currentHealth - damage;

		//if health is less then zero call the die funcion
		if (currentHealth <= 0) {
			die ();
		}

		//set the enemy to red to indicate damage taken
		amIRed = true;
		myRenderer.color = myRed;
		countdownTimer = timeSpentRed;
	}

	private void die() {
		//deactivate the enemy
		this.gameObject.SetActive (false);
		if (myDisableOtherObjectsScript != null) {
			myDisableOtherObjectsScript.disableObjects ();
		}
		if (myEnableOtherObjectsScript != null) {
			myEnableOtherObjectsScript.EnableObjects ();
		}
	}
}
