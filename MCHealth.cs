using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * this script handles the main characters health
 * and the events that occur based on changes
 * in health.
 */

public class MCHealth : MonoBehaviour {

	public int maxHealth = 100;
	private int currentHealth;
	//private GameObject gameover;
	//private RestartGame restartScript;

	public float timeSpentRed = .1f;
	private SpriteRenderer myRenderer;
	private Color myWhite = Color.white;
	private Color myRed = Color.red;
	private float countdownTimer;
	private bool amIRed;

	private HealthDisplay myHealthDisplay;

	// Use this for initialization
	void Start () {
		//initialize variables and get object references
		currentHealth = maxHealth;
		//gameover = GameObject.FindGameObjectWithTag ("GameOver");
		//restartScript = gameover.GetComponent<RestartGame> ();
		myRenderer = GetComponent<SpriteRenderer> ();
		countdownTimer = timeSpentRed;

		myHealthDisplay = GetComponent<HealthDisplay> ();
		if (myHealthDisplay.enabled) {
			myHealthDisplay.SetupDisplay (this);
		}
	}

	// Update is called once per frame
	void Update () {
		//if the character is currently highlighted red from being hit
		if (amIRed) {
			//update the timer
			countdownTimer = countdownTimer - Time.deltaTime;
			//if the timer has reached 0 change the main character back to standard colors
			if (countdownTimer <= 0) {
				myRenderer.color = myWhite;
				amIRed = false;
			}
		}
	}

	public int getCurrentHealth () {

		return currentHealth;
	}

	public int getMaxHealth () {

		return maxHealth;
	}

	public void takeDamage (int damage) {

		//remove the amount of health specified
		currentHealth = currentHealth - damage;
		//if health is less than or equal to 0 call the die function
		if (currentHealth <= 0) {
			die ();
		}

		//make the character red to indicate that damage has been taken
		amIRed = true;
		myRenderer.color = myRed;
		countdownTimer = timeSpentRed;
		if (myHealthDisplay.enabled) {
			myHealthDisplay.RedisplayCorrectHealth ();
		}
	}

	private void die() {
		//tell the restart script to restart the game
		//restartScript.Restart ();
		//deactivate the main character
		this.gameObject.SetActive (false);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
}
