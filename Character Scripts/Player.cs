using UnityEngine;
using System.Collections;

public class Player : Character {

	// Public reference to the player instance
	public static Player instance;

	// Player movement parameters
	// Private:
	public float playerSpeed;
	public float playerMoveDistance;
	private float moveError;
	private float moveTime;
	private bool isMoving = false;
	private float currentDirection;

	// Fixed directions of player travel (based on the angle ratios we're using for the map)
	private const float N = 0.663225f,
	NE = 0.331613f,
	E = 0.0f,
	SE = 0.663225f + Mathf.PI + 0.331613f,
	S = 0.663225f + Mathf.PI,
	SW = 0.663225f + Mathf.PI - 0.331613f,
	W = Mathf.PI,
	NW = 0.663225f + 0.331613f;

	// Called on script instance creation
	void Awake(){

		// Assign the current instance of the script to this variable if one hasn't been created
		if (instance == null) {
			instance = this;
		}

		// Initialise player components
		this.anim = this.GetComponent<Animator> ();
		this.myBody = this.GetComponent<Rigidbody2D> ();
		this.moveError = 0.2f;
		this.moveTime = 0.0f;
		this.isMoving = false;
		this.currentDirection = E;
		this.playerSpeed = 5.0f;
		this.playerMoveDistance = 5.0f;

	}

	// Update is called once per frame
	void Update	() {

		move ();

	}

	// Translate the player in a specific direction
	private void move(){
		
		moveStart ();

		chooseDirection ();

		moving (currentDirection);

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
			this.currentDirection = N;
		}

		if (Input.GetKeyUp ("up")) {
			anim.SetBool ("upPressed", false);
		}

		if (Input.GetKeyDown ("down")) {
			anim.SetBool ("downPressed", true);
			this.currentDirection = S;
		}

		if (Input.GetKeyUp ("down")) {
			anim.SetBool ("downPressed", false);
		}

		if (Input.GetKeyDown ("left")) {
			anim.SetBool ("leftPressed", true);
			this.currentDirection = W;
		}

		if (Input.GetKeyUp ("left")) {
			anim.SetBool ("leftPressed", false);
		}

		if (Input.GetKeyDown ("right")) {
			anim.SetBool ("rightPressed", true);
			this.currentDirection = E;
		}

		if (Input.GetKeyUp ("right")) {
			anim.SetBool ("rightPressed", false);
		}

	}

	// Move the player object until they reach the playerMoveDistance
	private void moving(float direction){

		if (isMoving) {
			
			moveTime += Time.deltaTime;		

			Vector3 moveVector = new Vector3 (playerSpeed * Mathf.Cos (direction), playerSpeed * Mathf.Sin (direction), 0);

			this.myBody.velocity = new Vector2 (moveVector.x, moveVector.y);

			float moveDistance = playerSpeed * moveTime;

			if (moveDistance >= this.playerMoveDistance) {
				this.isMoving = false;
				moveTime = 0.0f;
				Debug.Log ("Stopped Moving");
			}

			Debug.Log ("Moving " + (180.0f * direction) / Mathf.PI + " degrees");

		}

	}

	// Called when a GameObject enters the player's collider space
	private void onTriggerEnter2D(Collider2D target){
		
		if (target.tag == "pig") {
			GameObject pig = GameObject.FindGameObjectWithTag ("pig");
			this.attack (pig.GetComponent<Pig>().getPigInstance());
		}

	}

}
