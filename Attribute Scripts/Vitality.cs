/**
 * Vitality
 *
**/

public class Vitality {
    private float value;

    public Vitality (float _vit) {
        this.value = _vit;
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