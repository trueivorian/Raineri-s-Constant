using UnityEngine;
using System.Collections;

public class PhyiscalResistance {
    private float physicalResistance;
    private bool isReduced;

    public PhyiscalResistance (float _physicalResistance) {
        this.physicalResistance = _physicalResistance;
        this.isReduced = false;
    }

    public void setPhysicalResistance (float _physicalResistance) {
        this.physicalResistance = _physicalResistance;
    }

    public void modifyStatus (float difference) {
        this.physicalResistance += difference;
    }

    public bool getIsReduced () {
        return this.isReduced;
    }

    public void setIsReduced (bool condition) {
        this.isReduced = condition;
    }

    public float getValue () {
        return this.physicalResistance;
    }
}