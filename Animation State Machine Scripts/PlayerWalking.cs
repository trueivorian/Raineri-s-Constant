using UnityEngine;
using System.Collections;

public class PlayerWalking : StateMachineBehaviour {

	private Player playerInstance;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		playerInstance = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (stateInfo.IsName ("player_N_walking")) {
			playerInstance.move (Direction.N);
		} else if (stateInfo.IsName ("player_S_walking")) {
			playerInstance.move(Direction.S);
		} else if (stateInfo.IsName ("player_E_walking")) {
			playerInstance.move(Direction.E);
		} else if (stateInfo.IsName ("player_W_walking")) {
			playerInstance.move(Direction.W);
		} else if (stateInfo.IsName ("player_NW_walking")) {
			playerInstance.move(Direction.NW);
		} else if (stateInfo.IsName ("player_NE_walking")) {
			playerInstance.move(Direction.NE);
		} else if (stateInfo.IsName ("player_SW_walking")) {
			playerInstance.move(Direction.SW);
		} else if (stateInfo.IsName ("player_SE_walking")) {
			playerInstance.move(Direction.SE);
		} else if (stateInfo.IsName ("player_N_idle")
			|| stateInfo.IsName ("player_S_idle")
			|| stateInfo.IsName ("player_E_idle")
			|| stateInfo.IsName ("player_W_idle")
			|| stateInfo.IsName ("player_NE_idle")
			|| stateInfo.IsName ("player_SE_idle")
			|| stateInfo.IsName ("player_NW_idle")
			|| stateInfo.IsName ("player_SW_idle")){
			playerInstance.stop();
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
