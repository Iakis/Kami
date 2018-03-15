using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OniAI : MonoBehaviour
{
    private bool dead = false;

    public int health;
    Animator anim;
    Rigidbody m_rigidbody;
    bool canhit;

    public AnimatorStateInfo currentBaseState;

    public float range = 20f;

    bool detected;
    bool CD;
    bool attacking;

    GameObject target;
    float dNagi;
    Vector3 dir;
    AudioSource axeSound;
    AudioSource fallSound;
    Rigidbody s_rigidBody;

    static float globalGravity = -9.81f;
    float gravityScale = 1.0f;

    axe m_axe;

    public static int attackState = Animator.StringToHash("Base Layer.oattack");
    public static int deadState = Animator.StringToHash("Base Layer.odie");

    // Use this for initialization
    void Start()
    {
        health = 1;
        anim = gameObject.GetComponent<Animator>();
        m_rigidbody = gameObject.GetComponent<Rigidbody>();
        detected = false;
        attacking = false;
        axeSound = GameObject.Find("AxeSound").GetComponent<AudioSource>();
        fallSound = GameObject.Find("OniFallSound").GetComponent<AudioSource>();
        //s_rigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        gravity();
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        if (health > 0 && target != null)
        {
            transform.LookAt(target.transform);
            dNagi = Vector3.Distance(target.transform.position, transform.position);
            detect();
        } else if (health == 0 && !dead)
        {
            if (currentBaseState.fullPathHash != deadState)
            {
                dead = true;
                anim.SetTrigger("die");
                target.GetComponent<Movement>().outCombat();
                StartCoroutine("playFalling");
            } else
            {
                return;
            }
        }
        
        
    }

    IEnumerator playFalling()
    {
        yield return new WaitForSeconds(2f);
        fallSound.Play();
    }

    public void setAxe(axe myAxe)
    {
        m_axe = myAxe;
    }

    void detect()
    {
        if (currentBaseState.fullPathHash != attackState)
        {
            attacking = false;
            if (dNagi < 20 && health > 0)
            {
                target.GetComponent<Movement>().combat();
                if (dNagi > 5.5)
                {
                    anim.SetFloat("Speed", 1);
                    float step = 4f * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
                }
                else
                {
                    anim.SetFloat("Speed", 0);
                    transform.position = transform.position;
                    anim.SetTrigger("Attack");
                    StartCoroutine("smash");
                    attacking = true;
                }
            }
        }
    }

    public void damage()
    {
        health -= 1;
    }

    void gravity()
    {
        //Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        //s_rigidBody.AddForce(gravity, ForceMode.Acceleration);
    }

    IEnumerator smash()
    {
        yield return new WaitForSeconds(0.3f);
        m_axe.GetComponent<BoxCollider>().enabled = true;
        axeSound.Play();
        yield return new WaitForSeconds(0.7f);
        m_axe.GetComponent<BoxCollider>().enabled = false;

    }

    public void die()
    {
        this.gameObject.layer = 10;
        this.GetComponent<CapsuleCollider>().isTrigger = true;
        anim.SetTrigger("die");
        StartCoroutine("playFalling");
        m_axe.GetComponent<BoxCollider>().enabled = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            target = col.gameObject;
        }
    }

}
