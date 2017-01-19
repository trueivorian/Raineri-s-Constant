using UnityEngine;
using System.Collections;

public class NPCBehaviourManager {
    //This will be used to implement bot behaviour similar to human behaviour.
    private bool isLazing;
    private float currentTime;
    private bool isChargingForAttack;
    /**
     * Variables needed:
     * radius movement
     */

    public NPCBehaviourManager () {
        this.isLazing = false;
        this.isChargingForAttack = false;
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
            } else { }
        } else {
            Debug.Log("Move");
            //TODO: Implement a better form of movement function
            if (randomVal <= -7.5f) {
                this.addJobMove(Direction.Dir.N, targetNPC, targetQueue);
            } else if (randomVal <= -5.0f) {
                this.addJobMove(Direction.Dir.NE, targetNPC, targetQueue);
            } else if (randomVal <= -2.5f) {
                this.addJobMove(Direction.Dir.E, targetNPC, targetQueue);
            } else if (randomVal <= 0.0f) {
                this.addJobMove(Direction.Dir.SE, targetNPC, targetQueue);
            } else if (randomVal <= 2.5f) {
                this.addJobMove(Direction.Dir.S, targetNPC, targetQueue);
            } else if (randomVal <= 5.0f) {
                this.addJobMove(Direction.Dir.SW, targetNPC, targetQueue);
            } else if (randomVal <= 7.5f) {
                this.addJobMove(Direction.Dir.W, targetNPC, targetQueue);
            } else {
                this.addJobMove(Direction.Dir.NW, targetNPC, targetQueue);
            }
            this.isLazing = true;
        }

    }

    public void moveTowards (IMoveable targetNPC, JobQueue targetQueue, Vector2 direction) {
        if (this.isLazing) {
            if (currentTime == 0) {
                currentTime = Time.time;
            } else if ((Time.time - currentTime) >= targetNPC.getPauseDuration()) {
                currentTime = 0.0f;
                this.isLazing = false;
            } else { }
        } else {
            Debug.Log("Move");
            //TODO: Implement a better form of movement function
            var x = direction.x;
            var y = direction.y;
            var c = 1.61977519f; // tan 45 deg

            if (x >= 0.0f && y <= c * x && y >= -c * x) {
                this.addJobMove(Direction.Dir.E, targetNPC, targetQueue);
            } else if (x < 0.0f && y <= c * -x && y >= -c * -x) {
                this.addJobMove(Direction.Dir.W, targetNPC, targetQueue);
            } else if (y >= 0.0f && x <= c * y && x >= -c * y) {
                this.addJobMove(Direction.Dir.N, targetNPC, targetQueue);
            } else if (y < 0.0f && x <= c * -y && x >= -c * -y) {
                this.addJobMove(Direction.Dir.S, targetNPC, targetQueue);
            }
            this.isLazing = true;
        }
    }

    public void addJobMove (Direction.Dir direction, IMoveable targetNPC, JobQueue targetQueue) {
        targetQueue.addJob(() => {
            Direction.moveThere(direction, targetNPC);
        });
        targetQueue.addJob(() => {
            Direction.andStopThere(direction, targetNPC);
        });
    }

    public void retaliate (IMoveable targetNPC, JobQueue targetQueue, GameObject attackingNPC) {

        // If the pig is currently within the attack delay, wait.
        if (this.isChargingForAttack) {

            // If no clock has started, let currentTime be current time.
            if (currentTime == 0) {
                currentTime = Time.time;

                // If the period of delay is more than the pauseDuration, change condition to false and attack on the next frame.
            } else if ((Time.time - currentTime) >= targetNPC.getPauseDuration()) {
                currentTime = 0.0f;
                this.isChargingForAttack = false;
            } else { }

            // If the pig has the wait period over, it will attack
        } else {
            Debug.Log("Retaliate!");
            GameManager.getDamageManager().callAttack((IAttacking)targetNPC, attackingNPC.GetComponent<IAttackable>());
            Debug.Log(((IAttackable)targetNPC).getHealth().getHealthPoints());
            Debug.Log(attackingNPC.GetComponent<IAttackable>().getHealth().getHealthPoints());
            this.isChargingForAttack = true;
        }
    }
}