using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {

    // statusName like healthPoints, stamina
    private string statusName;
    private float statusValue;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public float getStatusValue() {
        return statusValue;
    }

    public void setStatusValue (float _statusValue) {
        this.statusValue = _statusValue;
    }
}
