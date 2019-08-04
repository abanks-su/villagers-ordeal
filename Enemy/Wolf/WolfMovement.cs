using UnityEngine;
using System.Collections;

public class WolfMovement : MonoBehaviour {

	public float normalMoveSpeed;
	public float attackMoveSpeed;
	public float attackJumpForce;
	public float timeBetweenAttacks;
	public float timeBetweenDirectionShift;
	public float attackDuration;
	public float hitboxOffset;
	public bool flipSpriteOnMove = false;

	private float myAttackTimer;
	private float myDirectionTimer;
	private bool amIAttacking;
	private bool amIMovingRight;

	private float normalMovementRight;
	private float normalMovementLeft;
	private float attackMovementRight;
	private float attackMovementLeft;

	private float hitboxOffsetRight;
	private float hitboxOffsetLeft;

	private Rigidbody myRigidbody;
	private Transform myTransform;
	private SpriteRenderer mySpriteRenderer;
	private GameObject playerInScene;
	private Transform playerTransform;

	private Transform myChildTransform;
	private GameObject myChildObject;

	// Use this for initialization
	void Start () {
	
		foreach (Transform child in transform) {
			myChildTransform = child;
			myChildObject = child.gameObject;
		}

		myChildObject.SetActive (false);

		normalMovementRight = normalMoveSpeed;
		normalMovementLeft = -normalMoveSpeed;
		attackMovementRight = attackMoveSpeed;
		attackMovementLeft = -attackMoveSpeed;

		hitboxOffsetLeft = -hitboxOffset;
		hitboxOffsetRight = hitboxOffset;

		myRigidbody = GetComponent<Rigidbody> ();
		myTransform = GetComponent<Transform> ();
		mySpriteRenderer = GetComponent<SpriteRenderer> ();
		playerInScene = GameObject.FindGameObjectWithTag ("Player");
		playerTransform = playerInScene.GetComponent<Transform> ();

		amIAttacking = false;
		amIMovingRight = false;
		myAttackTimer = timeBetweenAttacks;
		myDirectionTimer = timeBetweenDirectionShift;
	}
	
	// Update is called once per frame
	void Update () {
	
		//Debug.Log (amIMovingRight);
		//timers are decremented by the time elapsed since the last frame
		myAttackTimer = myAttackTimer - Time.deltaTime;
		if (!amIAttacking) {
			myDirectionTimer = myDirectionTimer - Time.deltaTime;
		}

		//if the direction timer has reached zero the wolf turns around
		if (myDirectionTimer < 0) {
			amIMovingRight = !amIMovingRight;
			myDirectionTimer = timeBetweenDirectionShift;
		}

		//if the attack timer has reached zero one of two things will happen:
		//	if the wolf is already attacking the wolf will stop attacking
		//  if the wolf is not attacking then the wolf will do an attack
		if (myAttackTimer < 0) {
			if (amIAttacking) {
				StopAttacking ();
			} else {
				DoAnAttack ();
			}
		}

		//the wolfs hitbox position is updated based on the wolfs direction and hitbox offset
		if (amIMovingRight) {
			myChildTransform.localPosition = new Vector3 (hitboxOffsetRight, myChildTransform.localPosition.y, myChildTransform.localPosition.z);
		} else {
			myChildTransform.localPosition = new Vector3 (hitboxOffsetLeft, myChildTransform.localPosition.y, myChildTransform.localPosition.z);
		}

		//the wolfs movement is updated based on the wolfs direction and the wolfs attack state.
		if (amIAttacking) {
			if (amIMovingRight) {
				myRigidbody.velocity = new Vector3 (attackMovementRight, myRigidbody.velocity.y, 0.0f);
			} else {
				myRigidbody.velocity = new Vector3 (attackMovementLeft, myRigidbody.velocity.y, 0.0f);
			}
		} else {
			if (amIMovingRight) {
				myRigidbody.velocity = new Vector3 (normalMovementRight, myRigidbody.velocity.y, 0.0f);
			} else {
				myRigidbody.velocity = new Vector3 (normalMovementLeft, myRigidbody.velocity.y, 0.0f);
			}
		}

		if (flipSpriteOnMove) {
			//set the sprite flip based on the direction
			if (amIMovingRight) {
				mySpriteRenderer.flipX = true;
			} else {
				mySpriteRenderer.flipX = false;
			}
		}
	}

	void StopAttacking () {
		amIAttacking = false;
		myChildObject.SetActive (false);
		myAttackTimer = timeBetweenAttacks;
		myDirectionTimer = timeBetweenDirectionShift;
	}

	void DoAnAttack () {
		amIAttacking = true;
		myChildObject.SetActive (true);
		myAttackTimer = attackDuration;
		myRigidbody.AddForce (attackJumpForce * transform.up);

		if (playerTransform.position.x < myTransform.position.x) {
			amIMovingRight = false;
		} else {
			amIMovingRight = true;
		}
	}
}
