using UnityEngine;
using System.Collections;

public class FarmerBot : Character {

    private FarmerBot famerBotInstance;

    // Use this for initialization
    void Awake () {
        if (famerBotInstance == null) {
            famerBotInstance = this;
        }

        this.health = new Health(100.0f);
    }

    // Update is called once per frame
    void Update () {
	
	}

    public FarmerBot getFarmerBotInstance () {
        return this.famerBotInstance;
    }

}
