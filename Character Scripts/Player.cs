using UnityEngine;
using System.Collections;

public class Player : Character {

	public static Player instance;
	public float playerSpeed;
	public float playerMoveDistance;

	private Camera playerCamera;
	private float moveError;
	private float moveTime;

	private bool isMoving = false; 
	private float N = 0.663225f,
	NE = 0.331613f,
	E = 0.0f,
	SE = 0.663225f + Mathf.PI + 0.331613f,
	S = 0.663225f + Mathf.PI,
	SW = 0.663225f + Mathf.PI - 0.331613f,
	W = Mathf.PI,
	NW = 0.663225f + 0.331613f,
	currentDirection;

	void Awake(){
		if (instance == null) {
			instance = this;
		}

		//Initialise player components
		this.anim = this.GetComponent<Animator> ();
		this.myBody = this.GetComponent<Rigidbody2D> ();
		this.moveError = 0.2f;
		this.moveTime = 0.0f;
		this.isMoving = false;
		this.currentDirection = NE;	

	}

	// Update is called once per frame
	void Update	() {
		if (Input.GetKeyDown ("up") || Input.GetKeyDown ("down") || Input.GetKeyDown ("left") || Input.GetKeyDown ("right")) {
			isMoving = true;
		}

		changeDirection ();

		if (isMoving) {
			moveTime += Time.deltaTime;
			move (currentDirection);
		}
	}

	public void changeDirection(){

		if (Input.GetKeyDown ("up")) {
			anim.SetBool ("upPressed", true);
			if (Input.GetKey ("up")) {
				anim.SetBool ("upHeld", true);
				currentDirection = N;
			} else if (Input.GetKeyDown ("right")) {
				anim.SetBool ("rightPressed", true);
				if(Input.GetKey("right")){
					anim.SetBool("rightHeld", true);
					currentDirection = NE;
				} 
			}else if(Input.GetKeyDown("left")){
				anim.SetBool("leftPressed", true);
				if(Input.GetKey("left")){
					anim.SetBool("leftHeld", true);
					currentDirection = NW;
				}
			}
		}else if (Input.GetKeyDown ("down")) {
			anim.SetBool ("downPressed", true);
			if (Input.GetKey ("down")) {
				anim.SetBool ("downHeld", true);
				currentDirection = S;
			} else if (Input.GetKeyDown ("right")) {
				anim.SetBool ("rightPressed", true);
				if(Input.GetKey("right")){
					anim.SetBool("rightHeld", true);
					currentDirection = SE;
				} 
			}else if(Input.GetKeyDown("left")){
				anim.SetBool("leftPressed", true);
				if(Input.GetKey("left")){
					anim.SetBool("leftHeld", true);
					currentDirection = SW;
				}
			}
		} else if (Input.GetKeyDown ("left")) {
			anim.SetBool ("leftPressed", true);
			if (Input.GetKey ("left")) {
				anim.SetBool ("leftHeld", true);
				currentDirection = W;
			} else if (Input.GetKeyDown ("up")) {
				anim.SetBool ("upPressed", true);
				if(Input.GetKey("up")){
					anim.SetBool("upHeld", true);
					currentDirection = NW;
				} 
			}else if(Input.GetKeyDown("down")){
				anim.SetBool("downPressed", true);
				if(Input.GetKey("down")){
					anim.SetBool("downHeld", true);
					currentDirection = SW;
				}
			}
		}else if (Input.GetKeyDown ("right")) {
			anim.SetBool ("rightPressed", true);
			if (Input.GetKey ("right")) {
				anim.SetBool ("rightHeld", true);
				currentDirection = E;
			} else if (Input.GetKeyDown ("up")) {
				anim.SetBool ("upPressed", true);
				if(Input.GetKey("up")){
					anim.SetBool("upHeld", true);
					currentDirection = NE;
				} 
			}else if(Input.GetKeyDown("down")){
				anim.SetBool("downPressed", true);
				if(Input.GetKey("down")){
					anim.SetBool("downHeld", true);
					currentDirection = SE;
				}
			}
		}

		if (Input.GetKeyUp ("up")) {
			anim.SetBool ("upPressed", false);
			anim.SetBool ("upHeld", false);
			this.isMoving = false;
			this.myBody.velocity = new Vector2 (0.0f, 0.0f);
		}
		if (Input.GetKeyUp ("down")) {
			anim.SetBool ("downPressed", false);
			anim.SetBool ("downHeld",false);
			this.isMoving = false;
			this.myBody.velocity = new Vector2 (0.0f, 0.0f);
		}
		if (Input.GetKeyUp ("left")) {
			anim.SetBool ("leftPressed", false);
			anim.SetBool ("leftHeld", false);
			this.isMoving = false;
			this.myBody.velocity = new Vector2 (0.0f, 0.0f);
		}
		if(Input.GetKeyUp("right")){
			anim.SetBool("rightPressed", false);
			anim.SetBool ("rightHeld", false);
			this.isMoving = false;
			this.myBody.velocity = new Vector2 (0.0f, 0.0f);
		}
		//		if (Input.GetKeyUp ("up") && Input.GetKeyUp ("down") && Input.GetKeyUp ("left") && Input.GetKeyUp ("right")) {
		//			isMoving = false;
		//		}

	}

	public void move(float direction){

		Vector3 moveVector = new Vector3 (playerSpeed*Mathf.Cos(direction), playerSpeed*Mathf.Sin(direction), 0);

		this.myBody.velocity = new Vector2 (moveVector.x, moveVector.y);

		float moveDistance = playerSpeed * moveTime;
		//Debug.Log ("moveDistance: " + moveDistance);
		//Debug.Log ("playerMoveDistance: " + playerMoveDistance);

		if (moveDistance >= this.playerMoveDistance) {
			//this.myBody.velocity = new Vector2 (0.0f, 0.0f);
			this.isMoving = false;
			moveTime = 0.0f;
			Debug.Log ("Stopped Moving");
		}


		Debug.Log ("Moving " + (180.0f * direction) / Mathf.PI + " degrees");

	}

	void onTriggerEnter2D(Collider2D target){
		if (target.tag == "pig") {
			GameObject pig = GameObject.FindGameObjectWithTag ("pig");
			this.attack (pig.GetComponent<Pig>().getPigInstance());
		}
	}

}
