using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WalkBehaviour : StateMachineBehaviour
{
    float counter;
    float chasingDistance = 45f;

    List<Transform> WayPoints = new List<Transform>();
    NavMeshAgent agent;
    Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        counter = 0f;

        Transform wp = GameObject.FindGameObjectWithTag("WayPoints").transform;
        foreach(Transform w in wp)
            WayPoints.Add(w);

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(WayPoints[Random.Range(0, WayPoints.Count)].position);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        counter += Time.deltaTime;

        if (agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(WayPoints[Random.Range(0, WayPoints.Count)].position);

        if (counter >= 10)
            animator.SetBool("isWalking", false);

        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < chasingDistance)
            animator.SetBool("isChasing", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

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
