using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Character {

    // Public reference to the player instance
    public static Player instance;

    // Player movement parameters
    private float playerSpeed;
    private float playerMoveDistance;
    private float currentDirection;

    // For interactionController. Currently for pig only
    private bool isTouchingPig;

    // Called on script instance creation
    private void Awake () {

        // Assign the current instance of the script to this variable if one hasn't been created
        if (instance == null) {
            instance = this;
        }

		//Initialise Character Components
		this.anim = this.GetComponent<Animator>();
		this.myBody = this.GetComponent<Rigidbody2D>();
		this.inventory = new Inventory();

        // Initialise player components
        this.currentDirection = Direction.E;
        this.playerSpeed = 5.0f;
        this.playerMoveDistance = 5.0f;
        this.isTouchingPig = false;

//		for (int i = 0; i < this.inventory.getNumIcons(); i++) {
//			this.inventory.addInventoryItem (this.inventory [i]);
//		}
    }

    // Update is called once per frame
    private void Update () {

        // This determines the direction the player faces
        chooseDirection();

        if (isTouchingPig) {
            if (Input.GetKeyDown(KeyCode.X)) {
                this.examine(GameObject.FindGameObjectWithTag("Pig").GetComponent<Pig>().getPigInstance());
            }
        }
    }

    private void FixedUpdate () {

    }

    /*
	 * Assign the currentDirection variable with one of the constant values if the arrow keys are pressed and change the 
	 * Mechanim state machine variables created in Unity 
	 */
    private void chooseDirection () {

        if (Input.GetKeyDown("up")) {
            anim.SetBool("upPressed", true);
        }

        if (Input.GetKeyUp("up")) {
            anim.SetBool("upPressed", false);
        }

        if (Input.GetKeyDown("down")) {
            anim.SetBool("downPressed", true);
        }

        if (Input.GetKeyUp("down")) {
            anim.SetBool("downPressed", false);
        }

        if (Input.GetKeyDown("left")) {
            anim.SetBool("leftPressed", true);
        }

        if (Input.GetKeyUp("left")) {
            anim.SetBool("leftPressed", false);
        }

        if (Input.GetKeyDown("right")) {
            anim.SetBool("rightPressed", true);
        }

        if (Input.GetKeyUp("right")) {
            anim.SetBool("rightPressed", false);
        }

    }

    // Move the player object
    public void movePlayer (float speed, float direction) {

        Vector3 moveVector = new Vector2(speed * Mathf.Cos(direction), speed * Mathf.Sin(direction));

        this.myBody.velocity = new Vector2(moveVector.x, moveVector.y);
    }

    // Move the player object
    public void movePlayer (float direction) {
        movePlayer(playerSpeed, direction);
    }

    public void stopPlayer () {
        movePlayer(0.0f, currentDirection);
    }

    public float getCurrentDirection () {
        return currentDirection;
    }

    // Called when a GameObject enters the player's collider space
    private void OnTriggerEnter2D (Collider2D target) {
		if (target.tag == "Pig") {
			GameObject pig = GameObject.FindGameObjectWithTag ("Pig");
			this.attack (pig.GetComponent<Pig> ().getPigInstance ());
			this.isTouchingPig = true;
		} else if (target.tag == "DroppedItem") {
			//this.inventory.Add (target.GetComponent<Item>());
			this.inventory.addInventoryItem (target.GetComponent<Item> ());
			target.gameObject.SetActive (false);
			Debug.Log ("Item Added to Inventory");
		}
    }

    private void OnTriggerExit2D (Collider2D target) {
        if (target.tag == "Pig") {
            this.isTouchingPig = false;
        }
    }

    public void interact (IInteractive target) {
        InteractionController.startInteraction(this, target);
    }

    public void examine (IInteractive target) {
        InteractionController.startDescription(this, target);
    }
}
