﻿/**
 * Player
 *
 * Defines the statuses, attributes and unity components for players. Currently, there are many temporary variables 
 * included.
**/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Character {

    // Public reference to the player instance
    public static Player instance;

    // For interactionController
    private bool isTouchingNPC;
    private GameObject touchedNPC;

    // Called on script instance creation
    private void Awake () {

        // Assign the current instance of the script to this variable if one hasn't been created
        if (instance == null) {
            instance = this;
        }

        // Unity components
        this.anim = this.GetComponent<Animator>();
        this.myBody = this.GetComponent<Rigidbody2D>();

        // Player variables
        this.status = new Status(1000.0f, 5000.0f, 5000.0f);
        this.attribute = new Attribute(10, 10, 10, 10);
        this.movementSpeed = 3.5f;
        this.inventory = new Inventory();
        this.currentDirection = Direction.E;

        // Temp variables
        this.isTouchingNPC = false;
        this.attack_type = A_TYPE.PHYSICAL;
        //		for (int i = 0; i < this.inventory.getNumIcons(); i++) {
        //			this.inventory.addInventoryItem (this.inventory [i]);
        //		}
    }

    // Update is called once per frame
    private void Update () {

        // This determines the direction the player faces
        chooseDirection();

        // Let touchedNPC be pig for now since there is some issue with NPC not being a pig
        if (isTouchingNPC && touchedNPC != null && touchedNPC.tag == "Pig") {
            if (Input.GetKeyDown(KeyCode.X)) {
                if (touchedNPC.GetComponent<IInteractive>().isInteractable()) {
                    this.examine(this.touchedNPC.GetComponent<IInteractive>());
                }
            } else if (Input.GetKeyDown(KeyCode.C)) {
                if (touchedNPC.GetComponent<IAttackable>().isAttackable()) {
                    this.attack(touchedNPC.GetComponent<IAttackable>());
                    Debug.Log(touchedNPC.GetComponent<IAttackable>().getStatus().health.getHealthPoints());
                }
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
            Direction.moveThere(Direction.Dir.N, this);
        }

        if (Input.GetKeyUp("up")) {
            Direction.andStopThere(Direction.Dir.N, this);
        }

        if (Input.GetKeyDown("down")) {
            Direction.moveThere(Direction.Dir.S, this);
        }

        if (Input.GetKeyUp("down")) {
            Direction.andStopThere(Direction.Dir.S, this);
        }

        if (Input.GetKeyDown("left")) {
            Direction.moveThere(Direction.Dir.W, this);
        }

        if (Input.GetKeyUp("left")) {
            Direction.andStopThere(Direction.Dir.W, this);
        }

        if (Input.GetKeyDown("right")) {
            Direction.moveThere(Direction.Dir.E, this);
        }

        if (Input.GetKeyUp("right")) {
            Direction.andStopThere(Direction.Dir.E, this);
        }

    }

    // Called when a GameObject enters the player's collider space
    private void OnTriggerEnter2D (Collider2D target) {
        this.isTouchingNPC = true;
        GameObject targetObject = GameObject.FindGameObjectWithTag(target.tag);
        this.touchedNPC = targetObject;
        Debug.Log(targetObject);
		if (target.tag == "DroppedItem") {
            this.inventory.addInventoryItem(target.GetComponent<Item>());
            target.gameObject.SetActive(false);
            Debug.Log("Item Added to Inventory");
        }
    }

    private void OnTriggerStay2D (Collider2D target) {
        if (target.gameObject.CompareTag("Pig")) {
            this.isTouchingNPC = true;
            GameObject targetObject = GameObject.FindGameObjectWithTag(target.tag);
            this.touchedNPC = targetObject;
        }
    }

    private void OnTriggerExit2D (Collider2D target) {
        this.isTouchingNPC = false;
        this.touchedNPC = null;
    }

    public void interact (IInteractive target) {
        InteractionController.startInteraction(this, target);
    }

    public void examine (IInteractive target) {
        InteractionController.startDescription(this, target);
    }

    public override bool isAttackable () {
        return true;
    }
}
