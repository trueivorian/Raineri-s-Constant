using UnityEngine;
using System.Collections;

public class MagicalResistance : Status {
    private float magicalResistance;
    private bool isReduced;

    public MagicalResistance (float _magicalResistance) {
        this.magicalResistance= _magicalResistance;
        this.isReduced = false;
    }

    public void setMagicalResisntace(float _magicalResistance) {
        this.magicalResistance = _magicalResistance;
    }

    public override void modifyStatus (float difference) {
        this.magicalResistance += difference;
    }

    public override bool getIsReduced () {
        return this.isReduced;
    }

    public override void setIsReduced (bool condition) {
        this.isReduced = condition;
    }
}