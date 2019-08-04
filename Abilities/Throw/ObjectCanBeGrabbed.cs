using UnityEngine;
using System.Collections;

public class ObjectCanBeGrabbed : MonoBehaviour {


	//public float throwSpeed;
	public float throwForce;

	private bool amIbeingHeld;

	//grab range data
	private float horizontalDistance;
	private float topDistance;
	private float bottomDistance;

	private float offsetWhenHeldX;
	private float offsetWhenHeldY;

	//Component Data from Main Character for movement and script interaction
	private GameObject mainCharacterObject;
	private Transform mainCharacterTransform;
	private GrabPlayerData mainCharacterData;
	private DirectionFacing mainCharacterDirection;

	//Component Data for current object
	private Transform myTransform;
	private BoxCollider myCollider;
	private Rigidbody myRigidbody;


	// Use this for initialization
	void Start () {
	
		amIbeingHeld = false;

		horizontalDistance = 40f;
		topDistance = 15f;
		bottomDistance = -15f;

		offsetWhenHeldX = 0f;
		offsetWhenHeldY = 30f;

		mainCharacterObject = GameObject.FindGameObjectWithTag ("Player");
		mainCharacterTransform = mainCharacterObject.GetComponent<Transform> ();
		mainCharacterData = mainCharacterObject.GetComponent<GrabPlayerData> ();
		mainCharacterDirection = mainCharacterObject.GetComponent<DirectionFacing> ();

		myTransform = this.GetComponent<Transform> ();
		myCollider = this.GetComponent<BoxCollider> ();
		myRigidbody = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (amIbeingHeld) {
			CenterOnMainCharacter();
		}

		if (Input.GetButtonDown ("GrabBox")) {
			//IMPORTANT
			//*****This is just for testing this will literally marth grab any box*****
			if (!amIbeingHeld) {
				//check if the box is within the grab range
				float verticalComparison = myTransform.position.y - mainCharacterTransform.position.y;
				if ((verticalComparison < topDistance) && (verticalComparison > bottomDistance)) {
					float horizontalComparison = myTransform.position.x - mainCharacterTransform.position.x;
					if (mainCharacterDirection.getFacingRight()) {
						if ((horizontalComparison <= horizontalDistance) && (horizontalComparison >= 0f)) {
						TryToBePickedUp ();
						}
					} else if ((horizontalComparison >= -horizontalDistance) && (horizontalComparison <= 0f)) {
						TryToBePickedUp ();
					}
				}
			} else {
				Throw ();
			}
		}
	}

	public void TryToBePickedUp () {
		
		if (mainCharacterData.IWouldLikeToBePickedUp ()) { //will return true if the main character isn't holding an object
			PickMeUp();
		}
	}

	private void PickMeUp () {
		amIbeingHeld = true;
		CenterOnMainCharacter ();
		myCollider.enabled = false;
	}

	private void CenterOnMainCharacter () {
		myTransform.position = new Vector3 (mainCharacterTransform.position.x + offsetWhenHeldX,
											mainCharacterTransform.position.y + offsetWhenHeldY,
											mainCharacterTransform.position.z);
	}

	public void Throw () {
		myCollider.enabled = true;
		amIbeingHeld = false;
		mainCharacterData.ImBeingThrown ();
		myRigidbody.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
		if (mainCharacterDirection.getFacingRight ()) {
			//myRigidbody.velocity = new Vector3 (throwSpeed, 0.0f, 0.0f);
			myRigidbody.AddForce(transform.right * throwForce);
		} else {
			//myRigidbody.velocity = new Vector3 (-throwSpeed, 0.0f, 0.0f);
			myRigidbody.AddForce(transform.right * -throwForce);
		}
	}
}
