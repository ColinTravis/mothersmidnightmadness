﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseStateBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MomCode momCode = animator.gameObject.GetComponent<MomCode>();
        momCode.StartChasing();
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MomCode momCode = animator.gameObject.GetComponent<MomCode>();
        momCode.StopChasing();
    }
}