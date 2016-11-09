using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Pig : Animal {

	private Pig pigInstance;
	private float pigSpeed;
	private float currentDirection;
	//private delegate void job();

	// Use this for initialization
	void Awake () {
		if (pigInstance == null) {
			pigInstance = this;
		}

		this.anim = this.GetComponent<Animator> ();
		this.myBody = this.GetComponent<Rigidbody2D> ();
		this.animalJobQueue = new JobQueue ();

		this.health = new Health (100.0f);
		this.pigSpeed = 5.0f;
		this.currentDirection = Direction.E;
		this.animalJobQueue.setIsWorking(true);

		// Attempt to simulate 4 up button presses
		this.animalJobQueue.addJob (delegate() {this.anim.SetBool ("upPressed", true);});
		this.animalJobQueue.addJob (delegate() {this.anim.SetBool ("upPressed", true);});
		this.animalJobQueue.addJob (delegate() {this.anim.SetBool ("upPressed", true);});
		this.animalJobQueue.addJob (delegate() {this.anim.SetBool ("upPressed", true);});
	}
	
	// Update is called once per frame
	void Update () {

		// TODO: Invoking methods from a queue
		//pigInstance.anim.SetBool ("upPressed", true);
		this.animalJobQueue.addJob (delegate() {pigInstance.anim.SetBool ("upPressed", true);});
		this.animalJobQueue.work ();
	}

	public Pig getPigInstance(){
		return this.pigInstance;
	}

	// Move the pig object
	public void movePig(float speed, float direction){

		Vector2 moveVector = new Vector2 (speed * Mathf.Cos (direction), speed * Mathf.Sin (direction));

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
