using UnityEngine;
using System.Collections;

public class Health : Status {
	private float healthPoints;

	public Health(float _healthPoints){
		this.healthPoints = _healthPoints;
	}

	public float getHealthPoints () {
		return healthPoints;
	}

	public override void modifyStatus(float change) {
		healthPoints += change;
	}


}
