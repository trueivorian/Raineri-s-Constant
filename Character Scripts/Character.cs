using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour, IAttackable, IInteractive {

	protected Rigidbody2D myBody;
	protected Animator anim;
	//protected BoxCollider2D boxCollider;
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

    //TODO: implement dialogue
    public string getDialogue () {
        return "dialogue";
    }

    //TODO: implement description
    public string getDescription () {
        return "description";
    }
}