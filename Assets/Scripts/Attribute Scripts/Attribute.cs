using UnityEngine;
using System.Collections;

public class Attribute : MonoBehaviour {

    private string attribteName;
    private float attributeValue;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public float getAttributeValue() {
        return attributeValue;
    }

    public void setAttributeValue (float _attributeValue) {
        this.attributeValue = _attributeValue;
    }
}
