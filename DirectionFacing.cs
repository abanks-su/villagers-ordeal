using UnityEngine;
using System.Collections;

public class DirectionFacing : MonoBehaviour {

	//this is for determining left and right direction
	private bool facingRight;

	//this is for determining up or down preference from the player
	//-1 will be totally down on the pad
	//0 will be totally centered on the pad
	//1 will be totally up on the pad
	private float yAxisValue;

	// Use this for initialization
	void Start () {
	
		facingRight = true;
		yAxisValue = 0f;
	}
	
	public void SetFacingRight() {
		facingRight = true;
	}

	public void SetFacingLeft() {
		facingRight = false;
	}

	public bool getFacingRight() {
		return facingRight;
	}

	public bool getFacingLeft() {
		return !facingRight;
	}

	//from here on everything is focused on whether there is any preference up or down for
	//the player firing a projectile.
	//this will be used to determine whether to shoot in a vertical direction rather than a horizontal one.

	void Update () {
		yAxisValue = Input.GetAxis ("Vertical");
	}

	public bool getTiltedUp() {
		if (yAxisValue > 0.5f) {
			return true;
		}
		return false;
	}

	public bool getTiltedDown() {
		if (yAxisValue < -0.5f) {
			return true;
		}
		return false;
	}

	public bool getPressingDown() {
		if (yAxisValue < -0.8f) {
			return true;
		}
		return false;
	}
}
