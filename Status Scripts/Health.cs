using UnityEngine;
using System.Collections;

public class Health {
    private float healthPoints;

    // Currently temporary
    private bool isReduced;

    public Health (float _healthPoints) {
        this.healthPoints = _healthPoints;
        this.isReduced = false;
    }

    public float getHealthPoints () {
        return healthPoints;
    }

    public void setHealthPoints (float _healthPoints) {
        this.healthPoints = _healthPoints;
    }

    public void modifyStatus (float change) {
        healthPoints += change;
        this.isReduced = true;
    }

    public bool getIsReduced () {
        return this.isReduced;
    }

    public void setIsReduced (bool condition) {
        this.isReduced = condition;
    }
}
