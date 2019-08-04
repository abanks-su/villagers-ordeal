using UnityEngine;
using System.Collections;

public class WallProjectileInteractions : MonoBehaviour {

	//This script goes on Walls and Floors and takes care of any interactions with projectiles

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		GameObject otherObject = other.gameObject;
		if (otherObject.tag == "EnemyProjectile" || otherObject.tag == "AllyProjectile") {
			ProjectileData otherInfo = other.gameObject.GetComponent<ProjectileData> ();
			if (otherInfo.destroyOnWall) {
				Destroy (other.gameObject);
			}
		}
	}
}
