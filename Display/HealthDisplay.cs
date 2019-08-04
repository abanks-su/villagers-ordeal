using UnityEngine;
using System.Collections;

public class HealthDisplay : MonoBehaviour {

	public GameObject heartPrefab;

	private MCHealth playerHealthScript;

	private GameObject heart1;
	private GameObject heart2;
	private GameObject heart3;
	private GameObject heart4;

	private Vector3 heartPosition1 = new Vector3 (-210.0f, 132.0f);
	private Vector3 heartPosition2 = new Vector3 (-190.0f, 132.0f);
	private Vector3 heartPosition3 = new Vector3 (-170.0f, 132.0f);
	private Vector3 heartPosition4 = new Vector3 (-150.0f, 132.0f);

	public void SetupDisplay (MCHealth passedHealthScript) {
		//this should be used instead of start and called
		//by MCHealth to make sure there isn't a Start()
		//dependancy situation in which execusion order matters

		playerHealthScript = passedHealthScript;

		heart1 = Instantiate (heartPrefab, transform) as GameObject;
		heart1.transform.localPosition = heartPosition1;

		heart2 = Instantiate (heartPrefab, transform) as GameObject;
		heart2.transform.localPosition = heartPosition2;

		heart3 = Instantiate (heartPrefab, transform) as GameObject;
		heart3.transform.localPosition = heartPosition3;

		heart4 = Instantiate (heartPrefab, transform) as GameObject;
		heart4.transform.localPosition = heartPosition4;

	}



	public void RedisplayCorrectHealth () {

		int maxHealth = playerHealthScript.getMaxHealth ();
		int currentHealth = playerHealthScript.getCurrentHealth ();

		if (currentHealth == maxHealth) {
			heart1.SetActive (true);
			heart2.SetActive (true);
			heart3.SetActive (true);
			heart4.SetActive (true);
			return;
		} else if (currentHealth == 0) {
			heart1.SetActive (false);
			heart2.SetActive (false);
			heart3.SetActive (false);
			heart4.SetActive (false);
			return;
		}

		int healthRatio = (maxHealth / currentHealth);

		if (healthRatio == 1) {

			heart1.SetActive (true);
			heart2.SetActive (true);
			heart3.SetActive (true);
			heart4.SetActive (false);
			return;
		} else if (healthRatio == 2) {

			heart1.SetActive (true);
			heart2.SetActive (true);
			heart3.SetActive (false);
			heart4.SetActive (false);
			return;
		} else {

			heart1.SetActive (true);
			heart2.SetActive (false);
			heart3.SetActive (false);
			heart4.SetActive (false);
			return;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
