using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour, IAttackable {

	protected Rigidbody2D myBody;
	protected Animator anim;
	protected Health health;

	// Update is called once per frame
	void Update () {

	}
		
	public Health getHealth() {
		return health;
	}

	public void attack (IAttackable victim){
		victim.getHealth().modifyStatus (-30.0f);
	}

    //TODO: implement calculateDamage()
    public float calculateDamage () {
        return 1.0f;
    }

    public Animator getAnimator () {
        return this.anim;
    }
}