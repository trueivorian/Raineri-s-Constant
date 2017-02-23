using UnityEngine;
using System.Collections;


public class DamageManager {
    private IAttacking mainAggressor;

    public DamageManager () {

    }

    public void callAttack (IAttacking aggressor, IAttackable target) {
        float finalDamage = calcDamage(aggressor, target);
        target.getStatus().health.modifyStatus(finalDamage);
    }

    private float calcDamage (IAttacking aggressor, IAttackable target) {
        A_TYPE aggAType = aggressor.getAttackType();
        float finalDamage = 0.0f;
        switch (aggAType) {
            case A_TYPE.MAGIC:
                break;
            case A_TYPE.PHYSICAL:
                float phyR = target.getStatus().phyiscalResistance.getValue();
                //finalDamage = attackingPower - physicalResistance*scale;
                float randomValue = Random.Range(10.0f, 30.0f);
                Debug.Log(randomValue);
                int evasionValue = (int) Random.Range(0.0f, 1.0f);
                Debug.Log("EV: " + evasionValue);
                finalDamage = evasionValue * (randomValue - phyR / 1596);
                Debug.Log("FD: "  + finalDamage);
                break;
        }
        return -finalDamage;
        
    }
}
