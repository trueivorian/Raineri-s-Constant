using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FarmerBot : Bot {

    private FarmerBot famerBotInstance;
    private float farmerSpeed;

    // Use this for initialization
    void Awake () {
        if (famerBotInstance == null) {
            famerBotInstance = this;
        }

        this.health = new Health(100.0f);
        //TODO: Add some better description for the bot.
        this.description = "This is a farmer.";
        this.dialogue = new List<string>();
        this.initializeDialogue(dialogue);
        this.farmerSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update () {
	
	}

    public FarmerBot getFarmerBotInstance () {
        return this.famerBotInstance;
    }

    public override void initializeDialogue(List<string> _dialogue) {
        _dialogue.Add("Hello...");
        _dialogue.Add("You can call be farmer Bill...");
        _dialogue.Add("I am a very boring farmer who tills the farm all day long...");
    }

}
