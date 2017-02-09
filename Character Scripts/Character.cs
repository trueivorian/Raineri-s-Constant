using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour, IAttackable, IMoveable, IAttacking {

	protected Rigidbody2D myBody;
	protected Animator anim;
    protected Status status;
	protected Inventory inventory;
    protected Attribute attribute;
    protected float movementSpeed;
    protected float currentDirection;
    protected float pauseDuration;
    //protected List<Item> inventory;

    void Awake() {
		
	}

	// Update is called once per frame
	void Update () {

	}
		
	public Status getStatus() {
		return this.status;
	}

    public Health getHealth() {
        return this.status.health;
    }

    public Attribute getAttribute() {
        return this.attribute;
    }

	public void attack (IAttackable victim){
        DamageManager damageManager;
        if (GameManager.getDamageManager() != null) {
            damageManager = GameManager.getDamageManager();
        } else {
            damageManager = new DamageManager();
            GameManager.setDamageManager(damageManager);
        }
        damageManager.callAttack(this, victim);
	}

    //TODO: implement calculateDamage()
    public float calculateDamage () {
        return 1.0f;
    }

    public Animator getAnimator () {
        return this.anim;
    }

    // Move the player object
    public void move (float speed, float direction) {
        Vector3 moveVector = new Vector2(speed * Mathf.Cos(direction), speed * Mathf.Sin(direction));
        this.myBody.velocity = new Vector2(moveVector.x, moveVector.y);
    }

    // Move the player object
    public void move (float direction) {
        move(movementSpeed, direction);
    }

    public void stop () {
        move(0.0f, currentDirection);
    }

    public float getCurrentDirection () {
        return currentDirection;
    }

    public abstract bool isAttackable ();

    // Not implemented for player
    public float getPauseDuration () {
        return this.pauseDuration;
    }
}