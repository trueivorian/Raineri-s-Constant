﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Pig : Animal {

	private Pig pigInstance;
	private float pigSpeed;
	private float currentDirection;

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
		this.animalJobQueue.setIsWorking (true);

		for (int i = 0; i < 50; i++) {
			this.animalJobQueue.addJob (() => {
				this.anim.SetBool ("upPressed", true);
			});
		}

		for (int i = 0; i < 50; i++) {
			this.animalJobQueue.addJob (() => {
				this.anim.SetBool("upPressed", false);

				this.anim.SetBool ("downPressed", true);
			});
		}

		this.animalJobQueue.addJob(() => {this.anim.SetBool("downPressed", false);});

	}

	// Update is called once per frame
	void Update () {
		// TODO: Invoking methods from a queue
		this.animalJobQueue.work ();
	}

	public Pig getPigInstance () {
		return this.pigInstance;
	}

	// Move the pig object
	public void movePig (float speed, float direction){

		Vector2 moveVector = new Vector2 (speed * Mathf.Cos (direction), speed * Mathf.Sin (direction));

		this.myBody.velocity = new Vector2 (moveVector.x, moveVector.y);
	}

	// Move the pig object
	public void movePig (float direction){
		movePig (pigSpeed, direction);
	}

	public void stopPig (){
		movePig (0.0f, currentDirection);
	}

	public float getCurrentDirection (){
		return currentDirection;

	}    
}

