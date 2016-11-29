using UnityEngine;
using System.Collections;


/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// Obtained from http://wiki.unity3d.com/index.php?title=Wander
/// </summary>

public class NPCBehaviourManager {
    //This will be used to implement bot behaviour similar to human behaviour.
    private bool isLazing;
    private float currentTime;
    /**
     * Variables needed:
     * radius movement
     */

    public NPCBehaviourManager () {
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
            Debug.Log("Move");
            //TODO: Implement a better form of movement function
            if (randomVal <= -7.5f) {
                //Move up
                this.addJobMove(Direction.N, targetNPC, targetQueue);
            } else if (randomVal <= -5.0f) {
                //Move left
                this.addJobMove(Direction.NE, targetNPC, targetQueue);
            } else if (randomVal <= -2.5f) {
                //Move left
                this.addJobMove(Direction.E, targetNPC, targetQueue);
            } else if (randomVal <= 0.0f) {
                //Move left
                this.addJobMove(Direction.SE, targetNPC, targetQueue);
            } else if (randomVal <= 2.5f) {
                //Move left
                this.addJobMove(Direction.S, targetNPC, targetQueue);
            } else if (randomVal <= 5.0f) {
                //Move down
                this.addJobMove(Direction.SW, targetNPC, targetQueue);
            } else if (randomVal <= 7.5f) {
                //Move down
                this.addJobMove(Direction.W, targetNPC, targetQueue);
            } else {
                //Move right
                this.addJobMove(Direction.NW, targetNPC, targetQueue);
            }
            this.isLazing = true;
        }

    }

    public void addJobMove (float direction, IMoveable targetNPC, JobQueue targetQueue) {
        targetQueue.addJob(() => {
            targetNPC.move(direction);
        });
    }
}