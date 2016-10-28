using UnityEngine;
using System.Collections;
using System;

public abstract class Animal : MonoBehaviour, IAttackable {

	protected Health health;

	public Health getHealth() {
		return health;
	}

	public void attack (IAttackable victim){        
	    victim.getHealth ().modifyStatus (30.0f);
	}

    public float calculateDamage () {
        return 1.0f;
    }
}
