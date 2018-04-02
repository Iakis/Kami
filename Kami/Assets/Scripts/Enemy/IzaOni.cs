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
    [SerializeField]
    bool canMove = true;
    Animator anim;
    Vector3 forward, right, heading;
    static float globalGravity = -9.81f;

    AudioSource fallSound;

    public AnimatorStateInfo currentBaseState;

    Rigidbody rb;

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
        rb = GetComponent<Rigidbody>();
        fallSound = GameObject.Find("OniFallSound").GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        anim = GetComponent<Animator>();
        revive();
        this.GetComponent<CapsuleCollider>().isTrigger = false;
        
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
            if (currentBaseState.fullPathHash != attackState)
            {
                attack();
                return;
            }
            
        }
        if (Input.GetAxis("NagiY") != 0 || Input.GetAxis("NagiX") != 0)
        {
            move(movespeed);
            anim.SetFloat("Speed", (System.Math.Abs(Input.GetAxis("NagiY"))) + (System.Math.Abs(Input.GetAxis("NagiX"))));
        } else
        {
            anim.SetFloat("Speed", 0);
        }
        //this.GetComponent<Rigidbody>().isKinematic = false;
    }

    IEnumerator KnockBack()
    {
        yield return new WaitForSeconds(0.5f);
        canMove = true;
    }

    void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.layer == 17)
        {
            StartCoroutine("KnockBack");
            canMove = false;

            Vector3 dir = collide.contacts[0].point - transform.position;
            dir = new Vector3(dir.x, 0f, dir.z);
            dir = -dir.normalized;
            transform.position += dir * 1f;
            StartCoroutine("KnockBack");
        }
    }

    protected void move(float movespeed)
    {
        if (canMove)
        {
            Vector3 upMovement = forward * movespeed * Time.deltaTime * -(Input.GetAxis("NagiY"));
            Vector3 rightMovement = right * movespeed * Time.deltaTime * Input.GetAxis("NagiX");

            heading = Vector3.Normalize(rightMovement + upMovement);

            transform.forward = heading;
            transform.position += upMovement;
            transform.position += rightMovement;
        }
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
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        anim.SetFloat("Speed", 0);
        transform.position = transform.position;
        anim.SetTrigger("Attack");
        if (gameObject.name == "Oni")
        {
            StopCoroutine("smash");
            StartCoroutine("smash");
        } else if (gameObject.name == "Tengu")
        {
            StopCoroutine("stab");
            StartCoroutine("stab");
        } else if (gameObject.name == "Yuki"){
            StopCoroutine("ice");
            StartCoroutine("ice");
        }
    }

    IEnumerator smash()
    {
        //Enable/disable weapon collider depending on animation
        yield return new WaitForSeconds(0.5f);
        // For tutorial
        m_axe.GetComponent<BoxCollider>().enabled = true;
        m_axe.GetComponent<BoxCollider>().isTrigger = false;
        StartCoroutine("playAxe");
        yield return new WaitForSeconds(0.6f);
        // For tutorial
        m_axe.GetComponent<BoxCollider>().isTrigger = true;
        m_axe.GetComponent<BoxCollider>().enabled = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
    }

    IEnumerator stab()
    {
        yield return new WaitForSeconds(0.7f);
        m_axe.GetComponent<BoxCollider>().enabled = true;
        m_axe.GetComponent<BoxCollider>().isTrigger = false;
        yield return new WaitForSeconds(0.5f);
        m_axe.GetComponent<BoxCollider>().isTrigger = true;
        m_axe.GetComponent<BoxCollider>().enabled = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
    }

    IEnumerator ice()
    {
        if (Vector3.Distance(this.gameObject.transform.position, m_axe.transform.position) < 20)
        {
            yield return new WaitForSeconds(1.55f);
            Quaternion rot = Quaternion.LookRotation(Vector3.up);
            Vector3 pos = new Vector3(m_axe.transform.position.x, transform.position.y, m_axe.transform.position.z);
            GameObject go = (GameObject)Instantiate(Resources.Load("bigice", typeof(GameObject)), pos, rot);
            Destroy(go, 2f);
        }
        yield break;
    }

    public void die()
    {
        //Set layer to corpse layer
        SideChar.outCombat();
        this.gameObject.layer = 10;
        //Disable collision with corpse
        this.GetComponent<CapsuleCollider>().isTrigger = true;
        this.GetComponent<SphereCollider>().enabled = false;
        this.GetComponent<Rigidbody>().isKinematic = true;
        //Start death animation
        anim.SetTrigger("die");
        StartCoroutine("playFalling");
        //Disable weapon collider
        if (m_axe != null)
        {
            m_axe.GetComponent<BoxCollider>().enabled = false;
        }
        this.enabled = false;
    }

    IEnumerator playFalling()
    {
        yield return new WaitForSeconds(2f);
        fallSound.Play();
    }

}
