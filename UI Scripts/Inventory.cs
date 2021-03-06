using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory {

	private Image[] icons;
	private int numIcons = 0;

	public Inventory(){
		GameObject[] inventoryItems;
		numIcons = 16;
		inventoryItems = GameObject.FindGameObjectsWithTag ("InventorySpace");
		numIcons = inventoryItems.Length;
		icons = new Image[numIcons];

		for (int i = 0; i < numIcons; i++) {
			icons [i] = inventoryItems [i].GetComponent<Image> ();
		}
	}

	public void addInventoryItem(Item _item){
		if (this.hasEmptySpaces ()) {
			int n = getNextEmptySpace ();
			Debug.Log ("Empty Space is at" + n);
			this.icons [n].sprite = _item.getItemIcon ();
			this.icons [n].color = Color.white;
		}
	}

	public bool hasEmptySpaces(){
		for (int i = 0; i < this.numIcons; i++) {
			if (this.icons [i].color != Color.white) {
				Debug.Log ("Has an empty space");
				return true;
			} else {
				Debug.Log ("Has no empty space at " + this.icons [i]);
			}
		}

		Debug.Log ("Has no empty spaces");

		return false;
	}

	public int getNextEmptySpace(){
		for (int i = 0; i < this.numIcons; i++) {
			if (this.icons [i].color != Color.white) {
				return i;
			}
		}

		return -1;
	}

	public int getNumIcons(){
		return numIcons;
	}
}
