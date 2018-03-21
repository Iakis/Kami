using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IzaOni : MonoBehaviour {

    [SerializeField]
    private float movespeed = 8f;
    [SerializeField]
    float gravityScale = 1.0f;
    [SerializeField]
    float jumpheight = 5f;
    Animator anim;
    Vector3 forward, right, heading;
    static float globalGravity = -9.81f;

    public AnimatorStateInfo currentBaseState;

    public static int reviveState = Animator.StringToHash("Base Layer.orevive");
    public static int attackState = Animator.StringToHash("Base Layer.oattack");
    public static int deadState = Animator.StringToHash("Base Layer.odie");

    public GameObject m_axe;

    // Use this for initialization
    void Start() {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        anim = GetComponent<Animator>();
        revive();
    }

    void OnEnable()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        anim = GetComponent<Animator>();
        revive();
    }

    void Update()
    {
        gravity();
        
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
    }

    void FixedUpdate()
    {
        if (currentBaseState.fullPathHash == reviveState || currentBaseState.fullPathHash == attackState || currentBaseState.fullPathHash == deadState)
        {
            return;
        }
        if (Input.GetButtonUp("XButton"))
        {
            attack();
            return;
        }
        if (Input.GetAxis("NagiY") != 0 || Input.GetAxis("NagiX") != 0)
        {
            move(movespeed);
            anim.SetFloat("Speed", (System.Math.Abs(Input.GetAxis("NagiY"))) + (System.Math.Abs(Input.GetAxis("NagiX"))));
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

    protected void gravity()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        //s_RigidBody.AddForce(gravity, ForceMode.Acceleration);
    }

    public void revive()
    {
        anim.SetTrigger("revive");
    }

    void attack()
    {
        anim.SetFloat("Speed", 0);
        transform.position = transform.position;
        anim.SetTrigger("Attack");
        StartCoroutine("smash");
    }

    IEnumerator smash()
    {
        //Enable/disable weapon collider depending on animation
        yield return new WaitForSeconds(0.5f);
        m_axe.GetComponent<BoxCollider>().enabled = true;
        //axeSound.Play();
        yield return new WaitForSeconds(0.7f);
        m_axe.GetComponent<BoxCollider>().enabled = false;
    }

}
