using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Animal : MonoBehaviour, IAttackable {

	protected Rigidbody2D myBody;
	protected Animator anim;
	protected Health health;
	//protected QueueManager animalTaskManager;

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
