using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Animal : MonoBehaviour, IAttackable, IInteractive, IMoveable {

    protected Rigidbody2D myBody;
    protected Animator anim;
    protected Health health;
    protected JobQueue animalJobQueue;
    protected string description;
    protected List<string> dialogue;
    protected NPCBehaviourManager npcBehaviourManager;
    protected float pauseDuration;

    public Health getHealth () {
        return health;
    }

    public void attack (IAttackable victim) {
        victim.getHealth().modifyStatus(30.0f);
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

    public Animator getAnimator() {
        return this.anim;
    }

    public float getPauseDuration() {
        return this.pauseDuration;
    }
}
