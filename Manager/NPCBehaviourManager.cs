using UnityEngine;
using System.Collections;


/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// Obtained from http://wiki.unity3d.com/index.php?title=Wander
/// </summary>

public class NPCBehaviourManager {
    //This will be used to implement bot behaviour similar to human behaviour.

    /**
     * Variables needed:
     * radius movement
     */

    public void wander (IMoveable targetNPC, JobQueue targetQueue) {
        float randomVal = Random.Range(-10.0f, 10.0f);

        //TODO: Implement a better form of movement function
        if (randomVal <= -5.0f) {
            //Move up
            targetQueue.addJob(() => {
                targetNPC.getAnimator().SetBool("upPressed", true);
            });
            targetQueue.addJob(() => {
                targetNPC.getAnimator().SetBool("upPressed", false);
            });
        } else if (randomVal <= 0.0f) {
            //Move left
            targetQueue.addJob(() => {
                targetNPC.getAnimator().SetBool("leftPressed", true);
            });
            targetQueue.addJob(() => {
                targetNPC.getAnimator().SetBool("leftPressed", false);
            });
        } else if (randomVal <= 5.0f) {
            //Move down
            targetQueue.addJob(() => {
                targetNPC.getAnimator().SetBool("downPressed", true);
            });
            targetQueue.addJob(() => {
                targetNPC.getAnimator().SetBool("downPressed", false);
            });
        } else {
            //Move right
            targetQueue.addJob(() => {
                targetNPC.getAnimator().SetBool("rightPressed", true);
            });
            targetQueue.addJob(() => {
                targetNPC.getAnimator().SetBool("rightPressed", false);
            });
        }
    }
}