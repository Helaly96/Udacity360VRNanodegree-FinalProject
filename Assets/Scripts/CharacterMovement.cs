using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterMovement : MonoBehaviour
{
    public float range;
    private float init_height;
    private float xPos;
    private float zPos;
    private Rigidbody rb;

    private float fallmultiplier = 2.5f;
    private float lowjumpmultiplier = 2f;
    private Animator animator;

    public static int chosen_hero;
    private SkinnedMeshRenderer renderer;
    float speed;

    public Material Flying;
    public Material Flash;
    public Material Engineer;

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    public void ChoseTheHero(int hero)
    {
        chosen_hero = hero;
    }


    void Start()
    {

        //check the type of the player
        renderer = GetComponent<SkinnedMeshRenderer>();
        init_height = transform.position.y;
        rb = this.GetComponent<Rigidbody>();
        speed = 0;
        animator = GetComponent<Animator>();

        if (chosen_hero == 1)
        {
            renderer.material = Flying;
        }
        else if (chosen_hero == 2)
        {
            renderer.material = Engineer;
        }
        else if (chosen_hero == 3)
        {
            renderer.material = Flash;
            range = range * 2;
        }
        else
        {
            renderer.material = Flying;
        }

    }


    // to have better performance with physics
    void FixedUpdate()
    {
        
        //check if we are jumping
        if (Input.GetButtonDown("Jump") )
        {
            if (chosen_hero == 1)
            {
                rb.velocity = Vector3.up * 20;
             
            }
            else
            {
                rb.velocity = Vector3.up * 8;
            }
           

        }

        //means we are falling

        //if (rb.velocity.y < 0) { rb.velocity += Vector3.up * (Physics2D.gravity.y) * (fallmultiplier - 1); }
        //else if (rb.velocity.y > 0 && !Input.GetButtonDown("Jump")) { rb.velocity += Vector3.up * (Physics2D.gravity.y) * (lowjumpmultiplier - 1); }


         xPos = Input.GetAxis("Horizontal") * range;
         zPos = Input.GetAxis("Vertical") * range;

        if (xPos!=0 || zPos != 0)
        {
            speed = 2;
        }
        else
        {
            speed = 0;
        }

        if (animator)
        {
            animator.SetFloat("Speed", speed);
        }
         
        //transform.position += new Vector3(xPos, 0, zPos);
        transform.Translate(xPos, 0, zPos, Space.Self);

        

    }
}
