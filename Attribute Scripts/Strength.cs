/**
 * Strength
 *
**/

public class Strength {
    private float value;

    public Strength (float _str) {
        this.value = _str;
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