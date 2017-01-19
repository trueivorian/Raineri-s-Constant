using UnityEngine;
using System.Collections;

//interface for all objects that can move
public interface IMoveable {
    void move (float direction);
    void stop ();
    void move (float speed, float direction);
    float getCurrentDirection ();
    float getPauseDuration ();
    Animator getAnimator ();
}
