using UnityEngine;
using System.Collections;


public class DamageManager {
    private IAttacking mainAggressor;

    public DamageManager() {

    }

    public void callAttack(IAttacking aggressor, IAttackable target) {
        target.getHealth().modifyStatus(-30.0f);
    }
}
