using UnityEngine;
using System.Collections;

public class pigEnclosureDoor : MonoBehaviour {

	protected Animator anim;

	// Use this for initialization
	void Awake () {
		this.anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter2D (Collider2D target){
		if (target.tag == "Player") {
			anim.SetBool ("isTouchingDoor", true);
			GameObject.FindGameObjectWithTag("pigEnclosureDoorCollider").GetComponent<BoxCollider2D>().enabled = false;
		}
	}

	private void OnTriggerExit2D (Collider2D target){
		if (target.tag == "Player") {
			anim.SetBool ("isTouchingDoor", false);
			GameObject.FindGameObjectWithTag("pigEnclosureDoorCollider").GetComponent<BoxCollider2D>().enabled = true;
		}
	}
}
