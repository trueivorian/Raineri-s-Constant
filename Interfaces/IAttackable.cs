using UnityEngine;
using System.Collections;

public interface IAttackable {

    Health getHealth ();
    float calculateDamage ();
    bool isAttackable ();
}
