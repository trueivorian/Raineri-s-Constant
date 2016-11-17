using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Animal : MonoBehaviour, IAttackable, IInteractive {

    protected Rigidbody2D myBody;
    protected Animator anim;
    protected Health health;
    protected JobQueue animalJobQueue;
    protected string description;
    protected List<string> dialogue;

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
}
