using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField]
    float movespeed = 4f;
    [SerializeField]
    float gravityScale = 1.0f;
    [SerializeField]
    float jumpheight = 5f;
    private Animator anim;
    Vector3 forward, right, heading;

    static float globalGravity = -9.81f;

    Rigidbody s_RigidBody;
    static Movement s_izanagi;

    bool grounded;
    public bool inCombat;

    Movement()
    {
        s_izanagi = this;
    }

    public static Movement Get()
    {
        return s_izanagi;
    }

    void Start () {
        anim = GetComponent<Animator>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        s_RigidBody = GetComponent<Rigidbody>();
        grounded = true;
	}
	
	void FixedUpdate () {
        gravity();
        if (Input.GetAxis("NagiY") != 0 || Input.GetAxis("NagiX") != 0)
        {
            move();
            anim.SetFloat("Speed", (System.Math.Abs(Input.GetAxis("NagiY"))) + (System.Math.Abs(Input.GetAxis("NagiX"))));
            anim.SetFloat("Direction", Input.GetAxis("NagiX"));
            if (Input.GetButton("AButton"))
            {
                anim.SetTrigger("Jump");
                jump();
            }
            if (Input.GetAxis("NagiX") < 0.1)
            {
                anim.SetBool("NegativeDirection", true);
            } else
            {
                anim.SetBool("NegativeDirection", false);
            }
        } else
        {
            anim.SetFloat("Speed", 0);
        }
        
    }

    void move()
    {
        Vector3 upMovement = forward * movespeed * Time.deltaTime * -(Input.GetAxis("NagiY"));
        Vector3 rightMovement = right * movespeed * Time.deltaTime * Input.GetAxis("NagiX");

        

        heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += upMovement;
        transform.position += rightMovement;
    }

    void jump()
    {
        if (grounded)
        {
            s_RigidBody.velocity = new Vector3(s_RigidBody.velocity.x, jumpheight, 0);
            grounded = false;
            anim.SetTrigger("jump");
        }
        else
        {
            s_RigidBody.velocity = s_RigidBody.velocity;
        }
    }

    void gravity()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        s_RigidBody.AddForce(gravity, ForceMode.Acceleration);
    }

    public void combat()
    {
        inCombat = true;
    }

    public void outCombat()
    {
        inCombat = false;
    }

    void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.layer == 8)
        {
            grounded = true;
        }
    }
}
