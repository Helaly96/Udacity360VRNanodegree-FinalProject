using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOme : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {

        if (!(collision.gameObject.CompareTag("Ball")))
        {
                Physics.IgnoreCollision(this.GetComponent<Collider>(), collision.collider);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if ( !(collision.gameObject.CompareTag("Ball")))
        {
                Physics.IgnoreCollision(this.GetComponent<Collider>(), collision.collider);
        }

    }


}
