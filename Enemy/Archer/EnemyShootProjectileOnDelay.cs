using UnityEngine;
using System.Collections;

public class EnemyShootProjectileOnDelay : MonoBehaviour {

	public float timeBetweenAttacks;
	public GameObject projectilePrefab;

	private float countdown;

	// Use this for initialization
	void Start () {
		
		countdown = timeBetweenAttacks;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		countdown = countdown - Time.deltaTime;

		if (countdown <= 0.0f) {
			DoAnAttack ();
			countdown = timeBetweenAttacks;
		}
	}

	void DoAnAttack () {
		Instantiate (projectilePrefab, this.transform.position, Quaternion.identity);
	}
}
