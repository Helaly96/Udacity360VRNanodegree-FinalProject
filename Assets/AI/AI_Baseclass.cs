using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Baseclass : StateMachineBehaviour
{

    public GameObject NPC;
    public GameObject opponent;
    public GameObject Ball;
    public UnityEngine.AI.NavMeshAgent agent_AI;
    public float speed = 2.0f;
    public float rotSpeed = 1.0f;
    public float accuracy = 3.0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        opponent = NPC.GetComponent<Gladiator_AI>().GetPlayer();
        Ball = NPC.GetComponent<Gladiator_AI>().GetBall();
        agent_AI = NPC.GetComponent<Gladiator_AI>().GetAgent();


    }
}
