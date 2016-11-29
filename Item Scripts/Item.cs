using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour {
	[SerializeField] 
	protected Sprite icon;

	// Use this for initialization
	void Awake () {
		this.icon = gameObject.GetComponent<SpriteRenderer> ().sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Sprite getItemIcon(){
		return this.icon;
	}
}
