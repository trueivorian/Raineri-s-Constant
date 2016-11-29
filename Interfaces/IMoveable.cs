using UnityEngine;
using System.Collections;

//interface for all objects that can move
public interface IMoveable {
    Animator getAnimator ();
    float getPauseDuration ();
}
