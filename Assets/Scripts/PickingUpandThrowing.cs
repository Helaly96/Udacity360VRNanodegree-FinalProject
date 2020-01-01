using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUpandThrowing : MonoBehaviour
{
    public GameObject Righthand;
    private Animator animator;
    public TrajectorySimulation Traj;
    public bool HoldingBall;
    private GameObject BeingHold;
    public GameObject Enemy;



    private void Start()
    {
        animator = GetComponent<Animator>();
        HoldingBall = false;
        

    }

    void Update()
    {

        //cast a raycast to try and catch the ball
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = new Ray(Camera.main.transform.position, (Camera.main.transform.forward)*100);
            //var ray  = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                
                // if the raycast hit is a ball
                if (selection.CompareTag("Ball"))
                {
                    selection.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    HoldingBall = true;
                    Enemy.GetComponent<Gladiator_AI>().AI_Holding_Ball = false;
                    selection.transform.parent = Righthand.transform;
                    Vector3 Zero = new Vector3(0, 0, 0);
                    selection.transform.localPosition = Zero;
                    BeingHold = selection.gameObject; 
                    
                }
            }

        }
        

        //Aim
        if (Input.GetButtonDown("Fire2"))
        {
            if (HoldingBall)
            {
                Vector3 Zero = new Vector3(0, 0, 0);
                BeingHold.transform.localPosition = Zero;
                animator.SetBool("AboutToThrow", true);
                Traj.Enabled = true;
            }
            
        }

        if(HoldingBall)
        {
            Ray ray = new Ray(Camera.main.transform.position, (Camera.main.transform.forward));
            Vector3 Zero = new Vector3(0, 0, 0);
            BeingHold.transform.localPosition = Zero;
            Traj.SimulatePath(BeingHold, ray.direction * 40, 0.5f, 0f);

        }

        if (Input.GetButtonUp("Fire2"))
        {
            var ray = new Ray(Camera.main.transform.position, (Camera.main.transform.forward));


            if (HoldingBall)
            {
                Traj.Enabled = false;
                BeingHold.GetComponent<Rigidbody>().AddForce(ray.direction * 40, ForceMode.Impulse);
                BeingHold.transform.parent = null;
                animator.SetBool("AboutToThrow", false);
                BeingHold.GetComponent<Rigidbody>().useGravity = true;
                HoldingBall = false;

            }
            
        }



        

        


        
    }
}
