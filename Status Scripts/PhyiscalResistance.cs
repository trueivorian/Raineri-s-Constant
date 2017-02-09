using UnityEngine;
using System.Collections;

public class PhyiscalResistance : Status {
    private float physicalResistance;
    private bool isReduced;

    public PhyiscalResistance (float _physicalResistance) {
        this.physicalResistance = _physicalResistance;
        this.isReduced = false;
    }

    public void setPhysicalResistance(float _physicalResistance) {
        this.physicalResistance = _physicalResistance;
    }

    public override void modifyStatus (float difference) {
        this.physicalResistance += difference;
    }

    public override bool getIsReduced () {
        return this.isReduced;
    }

    public override void setIsReduced (bool condition) {
        this.isReduced = condition;
    }
}