using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Animal : MonoBehaviour, IAttackable, IInteractive, IMoveable, IAttacking {

    // Unity components
    protected Rigidbody2D myBody;
    protected Animator anim;

    // Animal variables
    protected Status status;
    protected float pauseDuration;
    protected float movementSpeed;
    protected float currentDirection;
    protected List<GameObject> droppedItems;

    // Dialogues
    protected string description;
    protected List<string> dialogue;

    // Hidden components
    protected JobQueue animalJobQueue;
    protected NPCBehaviourManager npcBehaviourManager;
    protected GameController gameController;

    // Temporary variables
    protected bool isTouchingAggressor;
    protected A_TYPE attack_type;

    void Awake () {


    }

    public Status getStatus() {
        return this.status;
    }

    public A_TYPE getAttackType() {
        return this.attack_type;
    }

    public void attack (IAttackable victim) {
        victim.getStatus().health.modifyStatus(30.0f);
    }

    public float calculateDamage () {
        return 1.0f;
    }

    public List<string> getDialogues () {
        return this.dialogue;
    }

    public string getDescription () {
        return this.description;
    }

    public abstract void initializeDialogue (List<string> _dialogue);

    public Animator getAnimator () {
        return this.anim;
    }

    public float getPauseDuration () {
        return this.pauseDuration;
    }

    public abstract bool isInteractable ();
    public abstract bool isAttackable ();

    // Move the Animal object
    public void move (float speed, float direction) {
        Vector2 moveVector = new Vector2(speed * Mathf.Cos(direction), speed * Mathf.Sin(direction));
        this.myBody.velocity = new Vector2(moveVector.x, moveVector.y);
    }

    // Move the Animal object
    public void move (float direction) {
        move(movementSpeed, direction);
    }

    public void stop () {
        move(0.0f, currentDirection);
    }

    public float getCurrentDirection () {
        return currentDirection;
    }
    public void checkDeath () {
        if (this.getStatus().health.getHealthPoints() <= 0f) {

            if (droppedItems.Count != 0) {

                for (int i = 0; i < droppedItems.Count; i++) {
                    this.gameController.addGameObject(droppedItems[i], this.transform.position, this.transform.rotation);
                }
            }

            this.gameController.removeGameObject(this.gameObject);
        }
    }

}
