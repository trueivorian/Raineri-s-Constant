using UnityEngine;
using System.Collections;


public class DamageManager {
    public void callAttack(IAttacking aggressor, IAttackable target) {
        target.getHealth().modifyStatus(-30.0f);
    }
}
