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
		this.currentDirection = Direction.E;
		this.playerSpeed = 5.0f;
		this.playerMoveDistance = 5.0f;
		Debug.Log ("Screen Width: " + Screen.currentResolution.width);
		Debug.Log("Screen Height: " + Screen.currentResolution.height);

	}

	// Update is called once per frame
	private void Update	() {

		// This determines the direction the player faces
		chooseDirection(); 

	}

	private void FixedUpdate(){

	}

	/*
	 * Assign the currentDirection variable with one of the constant values if the arrow keys are pressed and change the 
	 * Mechanim state machine variables created in Unity 
	 */
	private void chooseDirection(){

		if (Input.GetKeyDown ("up")) {
			anim.SetBool ("upPressed", true);
		}

		if (Input.GetKeyUp ("up")) {
			anim.SetBool ("upPressed", false);
		}

		if (Input.GetKeyDown ("down")) {
			anim.SetBool ("downPressed", true);
		}

		if (Input.GetKeyUp ("down")) {
			anim.SetBool ("downPressed", false);
		}

		if (Input.GetKeyDown ("left")) {
			anim.SetBool ("leftPressed", true);
		}

		if (Input.GetKeyUp ("left")) {
			anim.SetBool ("leftPressed", false);
		}

		if (Input.GetKeyDown ("right")) {
			anim.SetBool ("rightPressed", true);
		}

		if (Input.GetKeyUp ("right")) {
			anim.SetBool ("rightPressed", false);
		}

	}

	// Move the player object
	public void movePlayer(float speed, float direction){
		
		Vector3 moveVector = new Vector2 (speed * Mathf.Cos (direction), speed * Mathf.Sin (direction));

		this.myBody.velocity = new Vector2 (moveVector.x, moveVector.y);
	}

	// Move the player object
	public void movePlayer(float direction){
		movePlayer (playerSpeed, direction);
	}

	public void stopPlayer(){
		movePlayer (0.0f, currentDirection);
	}

	public float getCurrentDirection(){
		return currentDirection;
	}

	// Called when a GameObject enters the player's collider space
	private void OnTriggerEnter2D(Collider2D target){
		
		if (target.tag == "Pig") {
			GameObject pig = GameObject.FindGameObjectWithTag ("Pig");
			this.attack (pig.GetComponent<Pig>().getPigInstance());
			// Debug.Log (pig.GetComponent<Pig>().getPigInstance().getHealth().getHealthPoints());
		}

	}

    public void interact (IInteractive target) {
        InteractionController.startInteraction(this, target);
    }

    public void examine (IInteractive target) {
        InteractionController.startDescription(this, target);
    }
}
