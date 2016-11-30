using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    [SerializeField]
    private const int sortingResolution = 100;
    private List<GameObject> allGameObjects;

    // Use this for initialization
    void Awake () {

		//Display Screen Resolution on the Console
		Debug.Log("Screen Width: " + Screen.currentResolution.width);
		Debug.Log("Screen Height: " + Screen.currentResolution.height);

        allGameObjects = new List<GameObject>();

		GameObject[] gameObjectArr = FindObjectsOfType<GameObject>();
        for (int i = 0; i < gameObjectArr.Length; i++) {
            allGameObjects.Add(gameObjectArr[i]);
        }
    }

    // Update is called once per frame
    void Update () {
        // Implement 2D Layer Sorting
        for (int i = 0; i < allGameObjects.Count; i++) {
            if (allGameObjects[i].GetComponent<SpriteRenderer>()) {
				if(allGameObjects[i].GetComponent<SpriteRenderer>().sortingLayerName == "Isometric"){
					allGameObjects[i].GetComponent<SpriteRenderer>().sortingOrder = -(int)(allGameObjects[i].transform.position.y * sortingResolution + allGameObjects[i].transform.position.z);
				}
            }
        }
    }

	public void addGameObject(GameObject _gameObject, Vector3 position, Quaternion rotation){
		Instantiate (_gameObject, position, rotation);
		allGameObjects.Add (_gameObject);
	}

	public void removeGameObject(GameObject _gameObject){
		allGameObjects.Remove (_gameObject);
		Destroy (_gameObject);
	}
}
