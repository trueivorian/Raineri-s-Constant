using UnityEngine;
using System.Collections;

public interface IAttacking {
    A_TYPE getAttackType ();
    void attack (IAttackable victim);
}