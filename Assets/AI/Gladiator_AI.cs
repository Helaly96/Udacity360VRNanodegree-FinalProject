using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Gladiator_AI : MonoBehaviour
{

    Animator anim;
    public GameObject player;
    public GameObject Ball;
    UnityEngine.AI.NavMeshAgent agent;
    public bool AI_Holding_Ball;
    public Transform RightHand;
    public Transform Goal_Location;
    public Transform center_torus;
    Vector3 Zero = new Vector3(0, 0, 0);
    bool first_attachment_happened = false;

    //shooting bullets var
    public bool AboutToShoot;
    public GameObject Bullet;
    public bool Shooting;

    public GameObject GetPlayer()
    {
        return player;
    }

    public GameObject GetBall()
    {
        return Ball;
    }

    public UnityEngine.AI.NavMeshAgent GetAgent()
    {
        return agent;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        AI_Holding_Ball = false;
    }

    private void Update()
    {
        anim.SetBool("Player_Holding_Ball", player.GetComponent<PickingUpandThrowing>().HoldingBall);
        anim.SetBool("AI_Holding_Ball", AI_Holding_Ball);
        if(AI_Holding_Ball && first_attachment_happened)
        {
            Ball.transform.localPosition = Zero;

        }

    }


    public void Looking_for_ball()
    {
        Vector3 lookAtGoal = new Vector3(Ball.transform.position.x, this.transform.position.y, Ball.transform.position.z);
        Vector3 Dir = lookAtGoal - this.transform.position;
        Vector3 Fixation = new Vector3(-Ball.transform.position.x, Ball.transform.position.y, -Ball.transform.position.z);
        //this.transform.LookAt(Fixation);
        if (Vector3.Distance(this.transform.position, lookAtGoal) > 3f)
        {
            //this.transform.Translate(Dir.normalized * 0.2f, Space.World);
           lookAtGoal = new Vector3(Ball.transform.position.x, this.transform.position.y, Ball.transform.position.z);
            agent.SetDestination(lookAtGoal);
        }
        else
        {
            // the AI picks the ball and transitions into other siutaion

            AI_Holding_Ball = true;

        }
    }
    
    public void begin_invoking()
    {
        Debug.Log("Started following player");
        InvokeRepeating("Shoot_at_player", 0.0f, 2f);
    }

    public void cancel_invoking()
    {
        Debug.Log("Stopped following player");
        CancelInvoke();
    }

    public void Pick_Up_Ball()
    {
        Ball.gameObject.GetComponent<Rigidbody>().useGravity = false;
        //AI_Holding_Ball = true;
        Ball.transform.parent = this.RightHand.transform;
        first_attachment_happened = true;
        Ball.transform.localPosition = Zero;


    }

    public void Shoot_at_player()
    {
        Debug.Log("Laucnhed");
        GameObject Spawned = Instantiate(Bullet, RightHand, false) as GameObject;
        Spawned.transform.localPosition = new Vector3(0, 0, 0);
        Spawned.transform.parent = null;
        Vector3 ray = player.transform.position - this.transform.position;
        Spawned.GetComponent<Rigidbody>().AddForce(ray * 5f, ForceMode.Impulse);
    }

    public void Go_to_goal_then_shoot()
    {
        Vector3 lookAtGoal = new Vector3(Goal_Location.transform.position.x, this.transform.position.y, Goal_Location.transform.position.z);
        Vector3 Dir = lookAtGoal - this.transform.position;
        if (Vector3.Distance(this.transform.position, lookAtGoal) > 40f)
        {
            //this.transform.Translate(Dir.normalized * 0.2f, Space.World);
            agent.SetDestination(Goal_Location.transform.position);
        }
        else
        {
            // the AI picks the ball and transitions into other siutaion
            Vector3 ray = this.center_torus.position - this.Ball.transform.position;
            Ball.GetComponent<Rigidbody>().AddForce(ray * 0.05f  , ForceMode.Impulse);
            Ball.transform.parent = null;
            //animator.SetBool("AboutToThrow", false);
            Ball.GetComponent<Rigidbody>().useGravity = true;
            AI_Holding_Ball = false;

        }

    }
}
