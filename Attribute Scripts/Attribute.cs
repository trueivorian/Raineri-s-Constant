using UnityEngine;
using System.Collections;

public class Attribute : MonoBehaviour {
    public enum attr { DEX, INT, STR, VIT }

    private float dexterity;
    private float intelligence;
    private float strength;
    private float vitality;

    public float getAttribute (Attribute.attr _attr) {
        switch (_attr) {
            case attr.DEX:
                return this.dexterity;
            case attr.INT:
                return this.intelligence;
            case attr.VIT:
                return this.vitality;
            case attr.STR:
                return this.strength;
            default:
                return 0.0f;
        }
    }

    public void modifyAttribute (Attribute.attr _attr, float change) {
        switch (_attr) {
            case attr.DEX:
                this.dexterity += change;
                break;
            case attr.INT:
                this.intelligence += change;
                break;
            case attr.VIT:
                this.vitality += change;
                break;
            case attr.STR:
                this.strength += change;
                break;
        }
    }

}
