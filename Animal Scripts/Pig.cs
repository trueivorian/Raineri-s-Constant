using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Pig : Animal, IMoveable {

    private Pig pigInstance;
    private float pigSpeed;
    private float currentDirection;
    private bool isDead;

    [SerializeField]
    private GameObject pork;

    // Use this for initialization
    void Awake () {

        // Initialise Animal Components
        this.anim = this.GetComponent<Animator>();
        this.myBody = this.GetComponent<Rigidbody2D>();
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
        //this.animalJobQueue.setIsWorking(true);

        this.description = "This is a pig.";
        this.dialogue = new List<string>();

        this.droppedItems = new List<GameObject>();
        this.droppedItems.Add(pork);
    }

    // Update is called once per frame
    void Update () {

        checkDeath();

        // TODO: Invoking methods from a queue
        if (animalJobQueue.isJobless()) {
            this.npcBehaviourManager.wander(this.pigInstance, this.animalJobQueue);
        } else {
            this.animalJobQueue.work();
        }
    }


    public void checkDeath () {
        if (this.getHealth().getHealthPoints() <= 0f) {
            //Debug.Log("Died!");
            //Vector3 spawnPosition = transform.TransformPoint(gameObject.transform.localPosition);
            Instantiate(rawPorkObject, this.transform.position, this.transform.rotation);

            //Instantiate(rawPorkObject, new Vector3(gameObject.transform.position.x-2.8f,gameObject.transform.position.y+0.19f,gameObject.transform.position.z), gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

    public Pig getLocalInstance () {
        return this.pigInstance;
    }

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
}