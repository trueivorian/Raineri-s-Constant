using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public abstract class Character : NetworkBehaviour {

	protected Rigidbody2D myBody;
	protected Animator anim;
	//protected BoxCollider2D boxCollider;
	protected float health;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer) {
			return;
		}
	}

	public void takeDamage(){

	}

	public void jump(){}

	public void die(){

	}
}