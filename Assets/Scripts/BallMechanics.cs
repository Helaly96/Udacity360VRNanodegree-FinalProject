using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMechanics : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //check if player is the one colliding with the ball
        if ( collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entered2");
            // if the player is holding the ball , disable the collision , else fuck it
            if (collision.gameObject.GetComponent<PickingUpandThrowing>().HoldingBall)
                Physics.IgnoreCollision(this.GetComponent<Collider>(),collision.collider);
        }

        //same for AI
        else if (collision.gameObject.CompareTag("Enemy"))
        {

            if(collision.gameObject.GetComponent<Gladiator_AI>().AI_Holding_Ball)
            {
                Debug.Log("Entered");
                Physics.IgnoreCollision(this.GetComponent<Collider>(), collision.collider);
            }
        }
    }


}
