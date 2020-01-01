using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{

    public bool AboutToShoot;
    public GameObject Bullet;
    public bool Shooting;
    private Animator animator;
    public GameObject Righthand;


    private void Start()
    {
        animator = GetComponent<Animator>();
        AboutToShoot = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            // animator.SetBool("AboutToShoot", true);
            //AboutToShoot = true;
            //Shooting = true;
            //Debug.Log("Shooting Laser");
            Shooting = false;
            GameObject Spawned = Instantiate(Bullet, Righthand.transform, false) as GameObject;
            Spawned.transform.localPosition = new Vector3(0, 0, 0);
            Spawned.transform.parent = null;
            Ray ray = new Ray(Camera.main.transform.position, (Camera.main.transform.forward) * 500);
            Spawned.GetComponent<Rigidbody>().AddForce(ray.direction * 100, ForceMode.Impulse);

        }

        if ( (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) && (this.AboutToShoot)  )
        {
            Debug.Log("Response");
            animator.SetBool("AboutToShoot", false);
            AboutToShoot = false;
        }

        if ((animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f) && (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.5f) && (this.AboutToShoot) && (this.Shooting))
        {
            Shooting = false;
            GameObject Spawned = Instantiate(Bullet, Righthand.transform, false) as GameObject;
            Spawned.transform.localPosition = new Vector3(0, 0, 0);
            Spawned.transform.parent = null;
            Ray ray = new Ray(Camera.main.transform.position, (Camera.main.transform.forward) * 500);
            Spawned.GetComponent<Rigidbody>().AddForce(ray.direction * 100,ForceMode.Impulse);

        }

    }
}
