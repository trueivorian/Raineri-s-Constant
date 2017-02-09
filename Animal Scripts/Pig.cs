using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pig : Animal {

    private Pig pigInstance;
    private bool isDead;

    // Extend to multiple aggressors
    private GameObject touchedAggressor;
    private GameObject prevAggressor;

    [SerializeField]
    private GameObject pork;

    private bool clearQueueFlag;

    private Vector3 startingPos;
    private float designatedRange;

    //Temporary variable for implementation purposes
    private float currentTime;
    private float oldHealth;
    private int attackCounter;
    private int prevAttackCounter;

    // Use this for initialization
    void Awake () {

        // Initialise Animal Components
        this.gameController = FindObjectOfType<GameController>();

        // Initialise pig components
        if (pigInstance == null) {
            pigInstance = this;
        }

        // Unity components
        this.anim = this.GetComponent<Animator>();
        this.myBody = this.GetComponent<Rigidbody2D>();

        // Pig variables
        this.status = new Status(100.0f);
        this.movementSpeed = 5.0f;
        this.currentDirection = Direction.E;
        this.pauseDuration = 2.0f;
        this.droppedItems = new List<GameObject>();
        this.droppedItems.Add(pork);
        this.startingPos = this.transform.position;
        this.designatedRange = 4.0f;

        // Diaglogues
        this.description = "This is a pig.";
        this.dialogue = new List<string>();
        this.isTouchingAggressor = false;

        // Hidden components
        this.animalJobQueue = new JobQueue();
        this.npcBehaviourManager = new NPCBehaviourManager();

        // Temporary variables
        this.clearQueueFlag = false;
        this.attackCounter = 0;
        this.prevAttackCounter = 0;
    }

    // Update is called once per frame
    void Update () {
        this.checkDeath();

        //Retaliation queue
        if (this.isOutOfRange()) {
            this.animalJobQueue.clear();
            this.lostAggression();

        } else if (this.isBeingAttacked()) {

            if (currentTime == 0.0f) {
                currentTime = Time.time;
            } else if (this.oldHealth > this.getHealth().getHealthPoints() || attackCounter > prevAttackCounter) {
                Debug.Log("Attack counter vs prevAttackCounter " + attackCounter + " " + prevAttackCounter);
                currentTime = 0.0f;
            } else if ((Time.time - currentTime) >= 10.0f) {
                currentTime = 0.0f;
                Debug.Log("Time aggression lost");
                this.lostAggression();
            }


            // Check if distance to player is close. If far, then move towards it.
            // Move towards aggressor if aggressor left area.
            if (this.touchedAggressor == null) {
                var heading = this.prevAggressor.transform.position - this.getLocalInstance().transform.position;
                var distance = heading.magnitude;
                var direction = heading / distance;
                this.npcBehaviourManager.moveTowards(this.pigInstance, this.animalJobQueue, direction);
                this.animalJobQueue.work();

            } else {
                prevAggressor = this.touchedAggressor;
            }

            if (!clearQueueFlag) {
                // Stop all movements when first attacked
                this.animalJobQueue.clear();
                this.clearQueueFlag = true;
            }

            this.prevAttackCounter = this.attackCounter;
            this.npcBehaviourManager.retaliate(this.pigInstance, this.animalJobQueue, this.touchedAggressor);
            this.oldHealth = this.getHealth().getHealthPoints();


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
    private void OnTriggerEnter2D (Collider2D target) {
        //this.touchedAggressor = targetObject.GetComponent<MonoBehaviour>();
        Debug.Log("XXXXXXXXXXX" + target);
        if (target.gameObject.CompareTag("Player")) {
            this.isTouchingAggressor = true;
            GameObject targetObject = GameObject.FindGameObjectWithTag(target.tag);
            this.touchedAggressor = targetObject;
        }

    }

    private void OnTriggerExit2D (Collider2D target) {
        this.isTouchingAggressor = false;
        this.touchedAggressor = null;
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

    // Currently it stays permanently true after being attacked once.
    public bool isBeingAttacked () {
        if (this.status.health.getIsReduced()) {
            return true;
        } else {
            return false;
        }
    }

    private bool isOutOfRange () {
        var heading = this.transform.position - this.startingPos;
        var distance = heading.magnitude;
        if (distance >= this.designatedRange) {
            return true;
        } else {
            return false;
        }
    }

    public void incAttackCounter (int count) {
        this.attackCounter += count;
        Debug.Log("Attack counter is : " + attackCounter);
    }

    private void lostAggression () {
        Debug.Log("Return to original position");
        //Implement return to original position
        //Temporary implementation
        GameObject pigObject = GameObject.FindGameObjectWithTag("Pig");
        npcBehaviourManager.moveToStartingPosition(pigObject, this.animalJobQueue, this.startingPos);
        // End temporary
        this.getHealth().setIsReduced(false);
        this.getHealth().setHealthPoints(100.0f);
        this.clearQueueFlag = false;
        this.attackCounter = 0;
    }
}