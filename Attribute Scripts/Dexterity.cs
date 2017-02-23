/**
 * Dexterity
 *
**/

public class Dexterity {
    private float value;

    public Dexterity (float _dex) {
        this.value = _dex;
    }

    public float getValue () {
        return this.value;
    }

    public void setValue (float _val) {
        this.value = _val;
    }

    public void modifyValue (float change) {
        this.value += change;
    }
}