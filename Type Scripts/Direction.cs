using UnityEngine;
using System.Collections;

public static class Direction {
    public enum Dir { N, NE, E, SE, S, SW, W, NW }

    // Fixed directions of player travel (based on the angle ratios we're using for the map)
    public const float N = 0.663225f,
    NE = 0.331613f,
    E = 0.0f,
    SE = 0.663225f + Mathf.PI + 0.331613f,
    S = 0.663225f + Mathf.PI,
    SW = 0.663225f + Mathf.PI - 0.331613f,
    W = Mathf.PI,
    NW = 0.663225f + 0.331613f;


    /*
     * Wrapper for movement in a certain direction.
     * Do note that currently, it is implemented as press and let go of 'button'
     */
    public static void moveThere (Direction.Dir direction, IMoveable target) {
        Animator _anim = target.getAnimator();
        Debug.Log("Set direction " + direction);
        switch (direction) {
            case Direction.Dir.N:
                _anim.SetBool("upPressed", true);
                _anim.SetBool("upPressed", false);
                break;
            case Direction.Dir.NE:

                break;
            case Direction.Dir.E:
                _anim.SetBool("rightPressed", true);
                _anim.SetBool("rightPressed", false);
                break;
            case Direction.Dir.SE:

                break;
            case Direction.Dir.S:
                _anim.SetBool("downPressed", true);
                _anim.SetBool("downPressed", false);
                break;
            case Direction.Dir.SW:

                break;
            case Direction.Dir.W:
                _anim.SetBool("leftPressed", true);
                _anim.SetBool("leftPressed", false);
                break;
            case Direction.Dir.NW:

                break;
        }
    }
}
