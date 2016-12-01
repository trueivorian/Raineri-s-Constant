using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Pig : Animal, IMoveable, IRetaliation {

    private Pig pigInstance;
    private bool isDead;

    private IAttacking touchedAggressor;

    [SerializeField]
    private GameObject pork;

    // Use this for initialization
    void Awake () {

        // Initialise Animal Components
        this.gameController = FindObjectOfType<GameController>();

        // Initialise pig components
        if (pigInstance == null) {
            pigInstance = this;
        }

        this.anim = this.GetComponent<Animator>();
        this.myBody = this.GetComponent<Rigidbody2D>();
        this.animalJobQueue = new JobQueue();
        this.npcBehaviourManager = new NPCBehaviourManager();

        this.health = new Health(100.0f);
        this.movementSpeed = 5.0f;
        this.currentDirection = Direction.E;
        this.pauseDuration = 2.0f;
        this.description = "This is a pig.";
        this.dialogue = new List<string>();
        this.isTouchingAggressor = false;

        this.droppedItems = new List<GameObject>();
        this.droppedItems.Add(pork);
    }

    // Update is called once per frame
    void Update () {

        this.checkDeath();

        //Retaliation queue
        if (this.isBeingAttacked()) {
            //Stop all movements
            this.animalJobQueue.clear();
            this.npcBehaviourManager.retaliate(this.pigInstance, this.animalJobQueue, this.touchedAggressor);


            //Normal wandering movement
        } else if (animalJobQueue.isJobless()) {
            this.npcBehaviourManager.wander(this.pigInstance, this.animalJobQueue);
        } else {
            this.animalJobQueue.work();
        }
    }

    public Pig getLocalInstance () {
        return this.pigInstance;
    }

    // Currently only allow for one aggressor. 
    //TODO: Add damage calculation so that the retaliation will be done to the aggressor with highest damage
    //private void OnTriggerEnter2D (Collider2D target) {
    //    this.isTouchingAggressor = true;
    //    GameObject targetObject = GameObject.FindGameObjectWithTag(target.tag);
    //    this.touchedAggressor = targetObject.GetComponent<IAttacking>();
    //}

    //private void OnTriggerExit2D (Collider2D target) {
    //    this.isTouchingAggressor = false;
    //    this.touchedAggressor = null;
    //}

    public override void initializeDialogue (List<string> _dialogue) {
        _dialogue.Add("Oink!");
        _dialogue.Add("Oink! Oink!");
        _dialogue.Add("Oink! Oink! Oink!");
    }

    public override bool isInteractable () {
        return true;
    }

    public override bool isAttackable () {
        return true;
    }

    // Currently it stays permanently true after being attacked once.
    public bool isBeingAttacked () {
        if (this.health.getIsReduced()) {
            return true;
        } else {
            return false;
        }
    }
}