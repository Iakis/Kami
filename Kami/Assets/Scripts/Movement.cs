using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    [SerializeField]
    private float movespeed = 4f;
    [SerializeField]
    float gravityScale = 1.0f;
    [SerializeField]
    float jumpheight = 5f;
    private Animator anim;
    Vector3 forward, right, heading;
    private GameObject[] respawns;
    private AudioSource jumpSound;
    private AudioSource walkSound;

	public Image fade;
	public Animator fadeAnim;

    static float globalGravity = -9.81f;

    private Rigidbody s_RigidBody;
    static Movement s_izanagi;

    bool grounded;

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
        jumpSound = GameObject.Find("JumpSound").GetComponent<AudioSource>();
        walkSound = GameObject.Find("WalkSound").GetComponent<AudioSource>();
        revive();
    }

    void Update()
    {
        walkSound.mute = !(anim.GetFloat("Speed") != 0 && (!anim.GetBool("Jump")));
    }

    void FixedUpdate () {
        gravity();
        if (Input.GetAxis("NagiY") != 0 || Input.GetAxis("NagiX") != 0)
        {
            move(movespeed);
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

    protected void move(float movespeed)
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
            jumpSound.Play();
        }
        else
        {
            s_RigidBody.velocity = s_RigidBody.velocity;
        }
    }

    protected void gravity()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        s_RigidBody.AddForce(gravity, ForceMode.Acceleration);
    }

    void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.layer == 8)
        {
            grounded = true;
        } else if (collide.gameObject.tag == "death")
        {
            die();
        }
    }

    public void die()
    {
        StartCoroutine("Die");
    }

    public void revive()
    {
        anim.SetTrigger("revive");
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine("Respawn");
		StartCoroutine (FadeOut());
        //animation for death
    }

    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("revive");
        respawns = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (GameObject respawn in respawns)
        {
            if (respawn.GetComponent<Respawn>().isActivated)
            {
                transform.position = respawn.transform.position;
            }
        }
		StartCoroutine (FadeIn ());
        //animation for respawn
    }

	IEnumerator FadeIn(){
		fadeAnim.SetBool ("Fade", false);
		yield return new WaitUntil (() => fade.color.a == 0);
	}

	IEnumerator FadeOut(){
		fadeAnim.SetBool ("Fade", true);
		yield return new WaitUntil (() => fade.color.a == 1);
	}

}
