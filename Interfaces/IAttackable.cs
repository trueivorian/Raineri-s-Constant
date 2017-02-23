using UnityEngine;
using System.Collections;

public interface IAttackable {
    Status getStatus ();
    float calculateDamage ();
    bool isAttackable ();
}
