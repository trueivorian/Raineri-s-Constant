using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Pig : Animal, IMoveable {

    private Pig pigInstance;
    private float pigSpeed;
    private float currentDirection;
	private bool isDead;
    private IEnumerator coroutine;
    
    [SerializeField]
    private GameObject pork;

    // Use this for initialization
    void Awake () {

		// Initialise Animal Components
		this.anim = this.GetComponent<Animator>();
		this.myBody = this.GetComponent<Rigidbody2D>();
		this.gameController = FindObjectOfType<GameController> ();

		// Initialise pig components
        if (pigInstance == null) {
            pigInstance = this;
        }
		
        this.animalJobQueue = new JobQueue();
        this.npcBehaviourManager = new NPCBehaviourManager();
		this.dialogue = new List<string>();
        this.health = new Health(100.0f);
		this.droppedItems = new List<GameObject> ();
        this.pigSpeed = 5.0f;
        this.currentDirection = Direction.E;
        this.pauseDuration = 2.0f;
        this.description = "This is a pig.";
		this.droppedItems.Add (pork);

    }

    // Update is called once per frame
    void Update () {

        checkDeath();

        // TODO: Invoking methods from a queue
        if (animalJobQueue.isJobless()) {
            // print("Jobless");
            this.npcBehaviourManager.wander(this.pigInstance, this.animalJobQueue);
        } else {
            this.animalJobQueue.work();
        }
    }
		
    public Pig getPigInstance () {
        return this.pigInstance;
    }

    // Move the pig object
    public void movePig (float speed, float direction) {
        Vector2 moveVector = new Vector2(speed * Mathf.Cos(direction), speed * Mathf.Sin(direction));

        this.myBody.velocity = new Vector2(moveVector.x, moveVector.y);
    }

    // Move the pig object
    public void movePig (float direction) {
        movePig(pigSpeed, direction);
    }

    public void stopPig () {
        movePig(0.0f, currentDirection);
    }

    public float getCurrentDirection () {
        return currentDirection;
    }

    public override void initializeDialogue (List<string> _dialogue) {
        _dialogue.Add("Oink!");
        _dialogue.Add("Oink! Oink!");
        _dialogue.Add("Oink! Oink! Oink!");
    }
}