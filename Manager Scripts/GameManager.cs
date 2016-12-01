using UnityEngine;
using System.Collections;


// Manager that stores all the other controller/manager
// The center static class that holds all other running processes
public static class GameManager {
    private static DamageManager globalDamageManager;

    public static void setDamageManager (DamageManager _damageManager) {
        GameManager.globalDamageManager = _damageManager;
    }

    public static DamageManager getDamageManager () {
        return GameManager.globalDamageManager;
    }

}
