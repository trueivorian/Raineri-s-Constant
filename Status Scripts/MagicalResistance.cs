using UnityEngine;
using System.Collections;

public class MagicalResistance {
    private float magicalResistance;
    private bool isReduced;

    public MagicalResistance (float _magicalResistance) {
        this.magicalResistance = _magicalResistance;
        this.isReduced = false;
    }

    public void setMagicalResisntace (float _magicalResistance) {
        this.magicalResistance = _magicalResistance;
    }

    public void modifyStatus (float difference) {
        this.magicalResistance += difference;
    }

    public bool getIsReduced () {
        return this.isReduced;
    }

    public void setIsReduced (bool condition) {
        this.isReduced = condition;
    }

    public float getValue () {
        return this.magicalResistance;
    }
}