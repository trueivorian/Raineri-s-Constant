/**
 * Intelligence
 *
**/

public class Intelligence {
    private float value;

    public Intelligence (float _int) {
        this.value = _int;
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