using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endmovement : MonoBehaviour
{

    [SerializeField]
    private float movespeed = 10f;
    [SerializeField]
    float gravityScale = 1.0f;
    [SerializeField]
    bool canMove = true;
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
    static endmovement s_izanagi;

    public bool grounded;
    public bool rolling;

    protected static int rollState = Animator.StringToHash("Base Layer.roll");
    public AnimatorStateInfo currentBaseState;

    endmovement()
    {
        s_izanagi = this;
    }

    public static endmovement Get()
    {
        return s_izanagi;
    }

    void Start()
    {
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
        dead = false;
    }

    void Update()
    {
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        walkSound.mute = !(anim.GetFloat("Speed") != 0 && (!anim.GetBool("Jump")) && (!rolling) && (!dead));
        if (!dead && !PauseMenu.isPaused)
        {
            return;
        }
    }

    void FixedUpdate()
    {
        gravity();
        if (!dead && !PauseMenu.isPaused)
        {
            if (Input.GetAxis("NagiY") != 0 || Input.GetAxis("NagiX") != 0)
            {
                move(movespeed);
                anim.SetFloat("Speed", 0.2f);
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
        if (canMove)
        {
            upMovement = forward * movespeed * Time.deltaTime * (-(Input.GetAxis("NagiY")) / 2);
            rightMovement = right * movespeed * Time.deltaTime * (Input.GetAxis("NagiX") / 2);
            heading = Vector3.Normalize(rightMovement + upMovement);



            transform.forward = heading;
            transform.position += upMovement;
            transform.position += rightMovement;
        }
    }

    protected void gravity()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        s_RigidBody.AddForce(gravity, ForceMode.Acceleration);
    }

    IEnumerator KnockBack()
    {
        yield return new WaitForSeconds(0.1f);
        canMove = true;
        s_RigidBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
    }

    void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.layer == 17)
        {
            s_RigidBody.constraints = RigidbodyConstraints.FreezeRotation;
            StartCoroutine("KnockBack");
            canMove = false;

            Vector3 dir = collide.contacts[0].point - transform.position;
            dir = new Vector3(dir.x, 0f, dir.z);
            dir = -dir.normalized;
            transform.position += dir * 1f;
            StartCoroutine("KnockBack");
        }
        else
        {
            s_RigidBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
    }

    IEnumerator FadeIn()
    {
        fadeAnim.SetBool("Fade", false);
        yield return new WaitUntil(() => fade.color.a == 0);
    }

    IEnumerator FadeOut()
    {
        fadeAnim.SetBool("Fade", true);
        yield return new WaitUntil(() => fade.color.a == 1);
    }

}
