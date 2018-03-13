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

    static Movement m_izanagi;
    public float range = 20f;

    bool detected;
    bool CD;
    bool attacking;

    GameObject target;
    float dNagi;
    Vector3 dir;
    axe m_axe;
    AudioSource axeSound;
    AudioSource fallSound;
    Rigidbody s_rigidBody;

    static float globalGravity = -9.81f;
    float gravityScale = 1.0f;

    public static int attackState = Animator.StringToHash("Base Layer.oattack");
    public static int deadState = Animator.StringToHash("Base Layer.odie");

    // Use this for initialization
    void Start()
    {
        health = 25;
        m_izanagi = Movement.Get();
        target = m_izanagi.gameObject;
        anim = gameObject.GetComponent<Animator>();
        m_rigidbody = gameObject.GetComponent<Rigidbody>();
        detected = false;
        attacking = false;
        m_axe = axe.Get();
        axeSound = GameObject.Find("AxeSound").GetComponent<AudioSource>();
        fallSound = GameObject.Find("OniFallSound").GetComponent<AudioSource>();
        //s_rigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        gravity();
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        if (health > 0)
        {
            transform.LookAt(m_izanagi.transform);
            dNagi = Vector3.Distance(m_izanagi.transform.position, transform.position);
            detect();
        } else
        {
            if (currentBaseState.fullPathHash != deadState)
            {
                anim.SetTrigger("die");
                m_izanagi.GetComponent<Movement>().outCombat();
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

    void detect()
    {
        if (currentBaseState.fullPathHash != attackState)
        {
            attacking = false;
            if (dNagi < 20 && health > 0)
            {
                m_izanagi.GetComponent<Movement>().combat();
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

    IEnumerator Cooldown()
    {
        CD = true;
        yield return new WaitForSeconds(6f);
        CD = false;
    }

    IEnumerator smash()
    {
        yield return new WaitForSeconds(0.3f);
        m_axe.GetComponent<BoxCollider>().enabled = true;
        axeSound.Play();
        yield return new WaitForSeconds(0.7f);
        m_axe.GetComponent<BoxCollider>().enabled = false;

    }

    IEnumerator DetectPlayer()
    {
        float dNagi = m_izanagi.transform.position.x - transform.position.x;
        if (dNagi < range)
        {
            Vector3 offset;
            if (dNagi > 0)
            {
                offset = Vector3.left * 5;
            }
            else
            {
                offset = Vector3.right * 5;
            }
            float step = 5f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, m_izanagi.transform.position+offset, step);
            anim.SetBool("walking", true);
            float time = (Math.Abs(dNagi) - offset.x) / 5;
            yield return new WaitForSeconds(time);
            anim.SetBool("walking", false);
            detected = true;
        }
    }

    IEnumerator die()
    {
        this.gameObject.layer = 10;
        this.GetComponent<CapsuleCollider>().isTrigger = true;
        anim.SetTrigger("die");
        yield return new WaitForSeconds(1f);
        dead = true;
        m_axe.GetComponent<BoxCollider>().enabled = false;
    }

    IEnumerator hit()
    {
        canhit = false;
        anim.SetTrigger("hit");
        yield return new WaitForSeconds(0.3f);
        canhit = true;
    }

}
