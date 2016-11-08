using UnityEngine;
using System.Collections;

public static class InteractionController {

    public static void startInteraction (Player player, IInteractive target) {
        //TODO: Add environmental switch case factors for starting of different sets of dialogues.
        int tempEnvSwitch = 1;
        switch (tempEnvSwitch) {
            case 1:
                /*target.getDialogues().ForEach(delegate (string dialogue){
                    //TODO: Add implementation of dialogues with Unity.
                    Debug.Log("To be implemented.");
                });*/
                break;
        }
    }

    public static void startDescription (Player player, IInteractive target) {
        //TODO: Add implementation of description with Unity.
    }
}
