using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : NetworkBehaviour {

    protected Rigidbody2D myBody;
    protected Animator anim;
    //protected BoxCollider2D boxCollider;
    protected List<Item> inventoryItem;

    // Volatile Statuses that changes often
    protected Status healthPoints;
    protected Status stamina;
    protected Status inventoryWeight;

    // Non-volatile Attributes
    protected Attribute level;
    protected Attribute movementSpeed;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (!isLocalPlayer) {
            return;
        }
    }

    // All Characters are able to move, changeDir, takeDamage, and die (inclusive of NPCs). Not sure of jump though.
    public abstract void move (float direction);
    public abstract void changeDirection ();
    public abstract void takeDamage (float damageValue);
    public abstract void jump ();
    public abstract void die ();
}