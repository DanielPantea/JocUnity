using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCarCtrl : MonoBehaviour {
	
	public Animator anim;
	public RuntimeAnimatorController shooting;
	public RuntimeAnimatorController not_shooting;
	private CharacterController controller;
	public float speed;
	public float turnSpeed;

	public Text scoreText;
	public float score;

	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;
	public float jumpForce = 8f;
	private bool canJump = true;

	public bool godmode = false;

	private GameController gameControl;


	private int difficulty = 1;
	private int maxDifficulty = 5;
	private int scoreToNext = 10;

	// Use this for initialization
	void Start () {
		
		anim = gameObject.GetComponent<Animator> ();
		controller = gameObject.GetComponent<CharacterController> ();
		gameControl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (0))
		{
			anim.runtimeAnimatorController = shooting as RuntimeAnimatorController;
		}
		if (Input.GetMouseButtonUp (0))
		{
			anim.runtimeAnimatorController = not_shooting as RuntimeAnimatorController;
		}
			
		//get the horizontal and vertical inputs
		float h = Input.GetAxis ("Horizontal");

		//only walk forward
		//Rotate the player based on the horizontal inputs

		var rotationVector = transform.rotation.eulerAngles;
		rotationVector.y  = 45 * h;
		transform.rotation = Quaternion.Euler(rotationVector);
		//if the player is on the ground
		if (controller.isGrounded)
		{

			moveDirection = Vector3.forward;
			//transform the new direction into a global direction
			moveDirection = transform.TransformDirection (moveDirection);

			moveDirection *= speed;
		
			if (Input.GetButtonDown("Jump") && canJump)
			{
				anim.SetBool("Jumping", true);

				moveDirection.y = jumpForce;

				canJump = false;
			}
		
		}
		//take from the Y direction the gravity
		moveDirection.y -= gravity * Time.deltaTime;
		//move the controller based on the new direction
		controller.Move (moveDirection * Time.deltaTime);

		if (score > scoreToNext && difficulty < maxDifficulty)
		{
			difficulty++;
			scoreToNext = difficulty * 10;

			speed ++;
		}
		switch (difficulty) {
		case 1:	
			score += Time.deltaTime;
			break;
		case 2:
			score += Time.deltaTime * difficulty / 1.33f;
			break;
		case 3:
			score += Time.deltaTime * difficulty / 1.5f;
			break;
		case 4:
			score += Time.deltaTime * difficulty / 2;
			break;
		case 5:
			score += Time.deltaTime * difficulty / 2;
			break;
			
		}
		scoreText.text =((int) score).ToString ();

		if(transform.position.y < -5)
			gameControl.PlayerDied ();
		
		if (Input.GetKey( KeyCode.Q))
		if(Input.GetKeyDown( KeyCode.W) && godmode == false)
			godmode = true;
	}


	// LateUpdate is called after Update
	void LateUpdate()
	{
		
		if(!controller.isGrounded)
			anim.SetBool ("Jumping", false);
		canJump = true;
	}


	public void OnControllerColliderHit(ControllerColliderHit other)
	{
		
		if (other.gameObject.tag != "Ground" && godmode == false)
			gameControl.PlayerDied ();
	}
}
