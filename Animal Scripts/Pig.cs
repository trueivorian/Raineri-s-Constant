using UnityEngine;
using System.Collections;

public class Pig : Animal {

	private Pig pigInstance;

	// Use this for initialization
	void Awake () {
		if (pigInstance == null) {
			pigInstance = this;
		}

		this.health = new Health (100.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Pig getPigInstance(){
		return this.pigInstance;
	}

    
}
