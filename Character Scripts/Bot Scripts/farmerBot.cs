using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/**
 * Inherits from Bot
 * 
 * string getDescription()
 * List<string> getDialogues()
 */
public class FarmerBot : Bot, IMoveable {

    private FarmerBot farmerBotInstance;
    private float farmerSpeed;
    private float pauseDuration;

    // Use this for initialization
    void Awake () {
        if (farmerBotInstance == null) {
            farmerBotInstance = this;
        }

        this.myBody = this.GetComponent<Rigidbody2D>();
        this.health = new Health(100.0f);
        //TODO: Add some better description for the bot.
        this.description = "This is a farmer.";
        this.dialogue = new List<string>();
        this.initializeDialogue(dialogue);
        this.farmerSpeed = 5.0f;
        this.pauseDuration = 2.0f;

        this.botJobQueue = new JobQueue();
        this.npcBehaviourManager = new NPCBehaviourManager();
    }

    // Update is called once per frame
    void Update () {

        if (botJobQueue.isJobless()) {
            print("Jobless");
            this.npcBehaviourManager.wander(this.farmerBotInstance, this.botJobQueue);
        } else {
            this.botJobQueue.work();
        }

    }

    public FarmerBot getLocalInstance () {
        return this.farmerBotInstance;
    }

    public override void initializeDialogue (List<string> _dialogue) {
        _dialogue.Add("Hello...");
        _dialogue.Add("You can call be farmer Bill...");
        _dialogue.Add("I am a very boring farmer who tills the farm all day long...");
    }

    public override bool isInteractable() {
        return true;
    }

    public float getPauseDuration() {
        return this.pauseDuration;
    }

    public override bool isAttackable () {
        throw new NotImplementedException();
    }
}
