using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    [SerializeField]
    private GameObject rawPorkObject;
    private const int sortingResolution = 100;
    private List<GameObject> allGameObjects;

    // Use this for initialization
    void Awake () {
        allGameObjects = new List<GameObject>();

        for (int i = 0; i < GameObject.FindObjectsOfType<GameObject>().Length; i++) {
            allGameObjects.Add(FindObjectsOfType<GameObject>()[i]);
        }
    }

    // Update is called once per frame
    void Update () {
        // Implement 2D Layer Sorting
        for (int i = 0; i < allGameObjects.Count; i++) {
            if (allGameObjects[i].GetComponent<SpriteRenderer>() && (allGameObjects[i].tag != "Background")) {
                allGameObjects[i].GetComponent<SpriteRenderer>().sortingOrder = -(int)(allGameObjects[i].transform.position.y * sortingResolution + allGameObjects[i].transform.position.z);
            }
        }
    }
}
