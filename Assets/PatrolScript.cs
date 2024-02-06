using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class EnemyIdleState : StateMachineBehaviour
{

    AI_Behaviour enemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<AI_Behaviour>();
        enemy.MoveToRandomWaypoint();
    }

    //onstateupdate is called on each update frame between onstateenter and onstateexit callbacks
    override public async void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        if (!enemy.agent.pathPending)
        {
            //returns the distance of agent, if it is the same of stoping distance
            // if (agent.remainingDistance <= agent.stoppingDistance)
            {
                //if agent has no path or agent is standing still
                if (!enemy.agent.hasPath || enemy.agent.velocity.sqrMagnitude == 0f)
                {
                    // Done
                    Debug.Log("DestinationReached");
                    enemy.MoveToRandomWaypoint();
                }


            }
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
