using UnityEngine;
using System.Collections;

public static class Direction {
    public enum Dir { N, NE, E, SE, S, SW, W, NW }

    // Fixed directions of player travel (based on the angle ratios we're using for the map)

	public const float N = Mathf.PI/2,
	NE = Mathf.PI/4,
	E = 0.0f,
	SE = 7*(Mathf.PI/4),
	S = 6*(Mathf.PI/4),
	SW = 5*(Mathf.PI/4),
	W = Mathf.PI,
	NW = 3*(Mathf.PI/4);

    /*
     * Wrapper for movement in a certain direction.
     * Do note that currently, it is implemented as press and let go of 'button'
     */
    public static void moveThere (Direction.Dir direction, IMoveable target) {
        Animator _anim = target.getAnimator();
        switch (direction) {
		case Direction.Dir.N:
			_anim.SetBool ("upPressed", true);
            break;
        case Direction.Dir.NE:
            _anim.SetBool("upPressed", true);
            _anim.SetBool("rightPressed", true);
            break;
        case Direction.Dir.E:
            _anim.SetBool("rightPressed", true);
            break;
        case Direction.Dir.SE:
            _anim.SetBool("downPressed", true);
            _anim.SetBool("rightPressed", true);
            break;
        case Direction.Dir.S:
            _anim.SetBool("downPressed", true);
            break;
        case Direction.Dir.SW:
            _anim.SetBool("downPressed", true);
            _anim.SetBool("leftPressed", true);
            break;
        case Direction.Dir.W:
            _anim.SetBool("leftPressed", true);
            break;
        case Direction.Dir.NW:
            _anim.SetBool("upPressed", true);
            _anim.SetBool("leftPressed", true);
            break;
        }
    }

    public static void andStopThere(Direction.Dir direction, IMoveable target) {
        Animator _anim = target.getAnimator();
        switch (direction) {
            case Direction.Dir.N:
                _anim.SetBool("upPressed", false);
                break;
            case Direction.Dir.NE:
                _anim.SetBool("upPressed", false);
                _anim.SetBool("rightPressed", false);
                break;
            case Direction.Dir.E:
                _anim.SetBool("rightPressed", false);
                break;
            case Direction.Dir.SE:
                _anim.SetBool("downPressed", false);
                _anim.SetBool("rightPressed", false);
                break;
            case Direction.Dir.S:
                _anim.SetBool("downPressed", false);
                break;
            case Direction.Dir.SW:
                _anim.SetBool("downPressed", false);
                _anim.SetBool("leftPressed", false);
                break;
            case Direction.Dir.W:
                _anim.SetBool("leftPressed", false);
                break;
            case Direction.Dir.NW:
                _anim.SetBool("upPressed", false);
                _anim.SetBool("leftPressed", false);
                break;
        }
    }
}


