using UnityEngine;
using System.Collections;

public class Pig : Animal {

	private Pig pigInstance;
	private float pigSpeed;
	private float currentDirection;

	// Use this for initialization
	void Awake () {
		if (pigInstance == null) {
			pigInstance = this;
		}

		this.health = new Health (100.0f);
		this.pigSpeed = 5.0f;
		this.currentDirection = Direction.E;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Pig getPigInstance(){
		return this.pigInstance;
	}

	// Move the pig object
	public void movePig(float speed, float direction){

		Vector3 moveVector = new Vector2 (speed * Mathf.Cos (direction), speed * Mathf.Sin (direction));

		this.myBody.velocity = new Vector2 (moveVector.x, moveVector.y);
	}

	// Move the pig object
	public void movePig(float direction){
		movePig (pigSpeed, direction);
	}

	public void stopPig(){
		movePig (0.0f, currentDirection);
	}

	public float getCurrentDirection(){
		return currentDirection;
	}

    
}
