﻿using UnityEngine;
using System.Collections;

public class PigWalking : StateMachineBehaviour {

    private Pig pigInstance;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        pigInstance = GameObject.FindGameObjectWithTag("Pig").GetComponent<Pig>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (stateInfo.IsName("pig_N_walking")) {
            pigInstance.move(Direction.N);
        } else if (stateInfo.IsName("pig_S_walking")) {
            pigInstance.move(Direction.S);
        } else if (stateInfo.IsName("pig_E_walking")) {
            pigInstance.move(Direction.E);
        } else if (stateInfo.IsName("pig_W_walking")) {
            pigInstance.move(Direction.W);
        } else if (stateInfo.IsName("pig_NW_walking")) {
            pigInstance.move(Direction.NW);
        } else if (stateInfo.IsName("pig_NE_walking")) {
            pigInstance.move(Direction.NE);
        } else if (stateInfo.IsName("pig_SW_walking")) {
            pigInstance.move(Direction.SW);
        } else if (stateInfo.IsName("pig_SE_walking")) {
            pigInstance.move(Direction.SE);
        } else if (stateInfo.IsName("pig_N_idle")
            || stateInfo.IsName("pig_S_idle")
            || stateInfo.IsName("pig_E_idle")
            || stateInfo.IsName("pig_W_idle")) {
            pigInstance.move(0.0f, pigInstance.getCurrentDirection());
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
