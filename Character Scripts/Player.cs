using UnityEngine;
using System.Collections;

public class Player : Character {

	// Public reference to the player instance
	public static Player instance;

	// Player movement parameters
	private float playerSpeed;
	private float playerMoveDistance;
	private float moveError;
	private float moveTime;
	private bool isMoving;
	private float currentDirection;

	// Called on script instance creation
	private void Awake(){

		// Assign the current instance of the script to this variable if one hasn't been created
		if (instance == null) {
			instance = this;
		}

		// Initialise player components
		this.anim = this.GetComponent<Animator> ();
		//this.animState = this.GetComponent<Animation> ();
		this.myBody = this.GetComponent<Rigidbody2D> ();
		this.moveError = 0.2f;
		this.moveTime = 0.0f;
		this.isMoving = false;
		this.currentDirection = RainerisConstants.E;
		this.playerSpeed = 5.0f;
		this.playerMoveDistance = 5.0f;

	}

	// Update is called once per frame
	private void Update	() {

		move ();

	}

	private void FixedUpdate(){

	}

	// Translate the player in a specific direction
	private void move(){
		
//		moveStart ();
//
		chooseDirection ();
//
//		moving (currentDirection);

	}

	// Set the isMoving variable to true if an arrow key is pressed
	private void moveStart(){
		
		if (Input.GetKeyDown ("up") || Input.GetKeyDown ("down") || Input.GetKeyDown ("left") || Input.GetKeyDown ("right")) {
			isMoving = true;
		}

	}

	/*
	 * Assign the currentDirection variable with one of the constant values if the arrow keys are pressed and change the 
	 * Mechanim state machine variables created in Unity 
	 */
	private void chooseDirection(){

		if (Input.GetKeyDown ("up")) {
			anim.SetBool ("upPressed", true);
			this.currentDirection = RainerisConstants.N;
		}

		if (Input.GetKeyUp ("up")) {
			anim.SetBool ("upPressed", false);
		}

		if (Input.GetKeyDown ("down")) {
			anim.SetBool ("downPressed", true);
			this.currentDirection = RainerisConstants.S;
		}

		if (Input.GetKeyUp ("down")) {
			anim.SetBool ("downPressed", false);
		}

		if (Input.GetKeyDown ("left")) {
			anim.SetBool ("leftPressed", true);
			this.currentDirection = RainerisConstants.W;
		}

		if (Input.GetKeyUp ("left")) {
			anim.SetBool ("leftPressed", false);
		}

		if (Input.GetKeyDown ("right")) {
			anim.SetBool ("rightPressed", true);
			this.currentDirection = RainerisConstants.E;
		}

		if (Input.GetKeyUp ("right")) {
			anim.SetBool ("rightPressed", false);
		}

	}

	// Move the player object until they reach the playerMoveDistance
	public void movePlayer(float direction){

		Vector3 moveVector = new Vector2 (playerSpeed * Mathf.Cos (direction), playerSpeed * Mathf.Sin (direction));

		this.myBody.velocity = new Vector2 (moveVector.x, moveVector.y);

		//Debug.Log ("Moving " + (180.0f * direction) / Mathf.PI + " degrees");

	}

	// Move the player object by a specified speed until they reach the playerMoveDistance
	public void movePlayer(float speed, float direction){
		
		Vector3 moveVector = new Vector2 (speed * Mathf.Cos (direction), speed * Mathf.Sin (direction));

		this.myBody.velocity = new Vector2 (moveVector.x, moveVector.y);
	}

	public float getCurrentDirection(){

		return currentDirection;

	}

	// Called when a GameObject enters the player's collider space
	private void onTriggerEnter2D(Collider2D target){
		
		if (target.tag == "pig") {
			GameObject pig = GameObject.FindGameObjectWithTag ("pig");
			this.attack (pig.GetComponent<Pig>().getPigInstance());
		}

	}

}
