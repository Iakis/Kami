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
    Vector3 forward, right, heading, upMovement, rightMovement;
    private GameObject[] respawns;
    private AudioSource jumpSound;
    private AudioSource walkSound;
    private AudioSource rollSound;

	public Image fade;
	public Animator fadeAnim;
    public GameObject model;
    public bool dead;
    static SideChar c;

    static float globalGravity = -9.81f;

    private Rigidbody s_RigidBody;
    static Movement s_izanagi;

    public bool grounded;
    public bool rolling;

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
        c = SideChar.Get();
        grounded = true;
        jumpSound = GameObject.Find("JumpSound").GetComponent<AudioSource>();
        walkSound = GameObject.Find("WalkSound").GetComponent<AudioSource>();
        //rollSound = GameObject.Find("RollSound").GetComponent<AudioSource>();
        revive();
        dead = false;
    }

    void Update()
    {
        
		walkSound.mute = !(anim.GetFloat("Speed") != 0 && (!anim.GetBool("Jump")) && (!rolling) && (!dead));
    }

    void FixedUpdate () {
        gravity();
        if (!dead && !PauseMenu.isPaused)
        {
            if (Input.GetButtonUp("BButton"))
            {
                anim.SetTrigger("Roll");
                StopCoroutine("roll");
                StartCoroutine("roll");
            }
            if (rolling)
            {
                Roll(heading, upMovement, rightMovement);
                ///rollSound.Play();
                return;
            }
            if (Input.GetButton("AButton"))
            {
                jump();
            }
            if (Input.GetAxis("NagiY") != 0 || Input.GetAxis("NagiX") != 0)
            {
                move(movespeed);
                anim.SetFloat("Speed", (System.Math.Abs(Input.GetAxis("NagiY"))) + (System.Math.Abs(Input.GetAxis("NagiX"))));
                anim.SetFloat("Direction", Input.GetAxis("NagiX"));
                if (Input.GetAxis("NagiX") < 0.1)
                {
                    anim.SetBool("NegativeDirection", true);
                }
                else
                {
                    anim.SetBool("NegativeDirection", false);
                }
            }
            else
            {
                anim.SetFloat("Speed", 0);
            }
        }
        
        
    }

    protected void move(float movespeed)
    {
        upMovement = forward * movespeed * Time.deltaTime * -(Input.GetAxis("NagiY"));
        rightMovement = right * movespeed * Time.deltaTime * Input.GetAxis("NagiX");
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
            anim.SetTrigger("Jump");
            jumpSound.Play();
        }
        else
        {
            s_RigidBody.velocity = s_RigidBody.velocity;
        }
    }

    void Roll(Vector3 h, Vector3 u, Vector3 r)
    {
        transform.forward = h;
        transform.position += u*1.5f;
        transform.position += r*1.5f;
    }

    IEnumerator roll()
    {
        rolling = true;
        yield return new WaitForSeconds(0.5f);
        rolling = false;
    }

    protected void gravity()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        s_RigidBody.AddForce(gravity, ForceMode.Acceleration);
    }

    void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.layer == 17)
        {
            s_RigidBody.constraints = RigidbodyConstraints.FreezeRotation;
        } else
        {
            s_RigidBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
        if (collide.gameObject.tag == "ground")
        {
            grounded = true;
        } else if (collide.gameObject.tag == "death")
        {
            die();
        }

        if (collide.gameObject.layer == 15 || collide.gameObject.layer == 16)
        {
            this.gameObject.layer = collide.gameObject.layer;
            model.layer = collide.gameObject.layer;
        }
    }

    public void die()
    {
        if (!rolling)
        {
            StartCoroutine("Die");
        }
    }

    public void revive()
    {
        anim.SetTrigger("revive");
    }

    IEnumerator Die()
    {
        dead = true;
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(1f);
        StartCoroutine("Respawn");
		StartCoroutine (FadeOut());
        
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
        yield return new WaitForSeconds(2f);
        dead = false;
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
