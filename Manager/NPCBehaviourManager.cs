using UnityEngine;
using System.Collections;


/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// Obtained from http://wiki.unity3d.com/index.php?title=Wander
/// </summary>

public class NPCBehaviourManager{
    //This will be used to implement bot behaviour similar to human behaviour.

    public enum _Direction {LEFT, RIGHT, UP, DOWN};
    private bool isLazing;
    private float currentTime;
    /**
     * Variables needed:
     * radius movement
     */

    public NPCBehaviourManager() {
        this.isLazing = false;
        this.currentTime = 0.0f;
    }

    //Add in a laziness attribute
    public void wander (IMoveable targetNPC, JobQueue targetQueue) {
        float randomVal = Random.Range(-10.0f, 10.0f);

        if (this.isLazing) {
            if (currentTime == 0) {
                currentTime = Time.time;
            } else if ((Time.time - currentTime) >= targetNPC.getPauseDuration()) {
                currentTime = 0.0f;
                this.isLazing = false;
            } else {
            }
        } else {
            //TODO: Implement a better form of movement function
            if (randomVal <= -5.0f) {
                //Move up
                this.move(_Direction.UP, targetNPC, targetQueue);
            } else if (randomVal <= 0.0f) {
                //Move left
                this.move(_Direction.LEFT, targetNPC, targetQueue);
            } else if (randomVal <= 5.0f) {
                //Move down
                this.move(_Direction.DOWN, targetNPC, targetQueue);
            } else {
                //Move right
                this.move(_Direction.RIGHT, targetNPC, targetQueue);
            }
            this.isLazing = true;
        }
        
    }

    public void move (_Direction direction, IMoveable targetNPC, JobQueue targetQueue) {
        switch (direction) {
            case _Direction.LEFT:
                targetQueue.addJob(() => {
                    targetNPC.getAnimator().SetBool("leftPressed", true);
                });
                targetQueue.addJob(() => {
                    targetNPC.getAnimator().SetBool("leftPressed", false);
                });
                break;
            case _Direction.DOWN:
                targetQueue.addJob(() => {
                    targetNPC.getAnimator().SetBool("downPressed", true);
                });
                targetQueue.addJob(() => {
                    targetNPC.getAnimator().SetBool("downPressed", false);
                });
                break;
            case _Direction.RIGHT:
                targetQueue.addJob(() => {
                    targetNPC.getAnimator().SetBool("rightPressed", true);
                });
                targetQueue.addJob(() => {
                    targetNPC.getAnimator().SetBool("rightPressed", false);
                });
                break;
            case _Direction.UP:
                targetQueue.addJob(() => {
                    targetNPC.getAnimator().SetBool("upPressed", true);
                });
                targetQueue.addJob(() => {
                    targetNPC.getAnimator().SetBool("upPressed", false);
                });
                break;
        }
    }
    
}