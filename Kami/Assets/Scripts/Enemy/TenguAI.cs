using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenguAI : Monster {

    AudioSource axeSound;
    public GameObject Spear;
    public bool CD;
    bool dashing;
    Transform tar;
    Vector3 pos;

    // Use this for initialization
    void Start()
    {
        health = 25;
        anim = gameObject.GetComponent<Animator>();
        attacking = false;
        axeSound = GameObject.Find("AxeSound").GetComponent<AudioSource>();
        movespeed = 6;
        combatRange = 20;
        attackRange = (float)15;
        weapon = Spear;
        attk = hit;
        spawn = this.transform.position;
        fallSound = GameObject.Find("OniFallSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dashing)
        {
            dash(pos);
        } else
        {
            alive();
        }
        
    }

    void hit()
    {
        tar = target.transform;
        if (Vector3.Distance(tar.position, transform.position) <= attackRange && CD == false)
        {
            anim.SetFloat("Speed", 0);
            transform.position = transform.position;
            attacking = true;
            StopCoroutine("stab");
            anim.SetTrigger("Attack");
            StartCoroutine("stab");
        }
        else
        {
            anim.SetFloat("Speed", 0);
            return;
        }       
    }

    IEnumerator stab()
    {
        CD = true;
        yield return new WaitForSeconds(0.7f);
        pos = target.transform.position;
        weapon.GetComponent<BoxCollider>().enabled = true;
        dashing = true;
        yield return new WaitForSeconds(0.5f);
        weapon.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        dashing = false;
        attacking = false;
        yield return new WaitForSeconds(1.5f);
        CD = false;
    }

    void dash(Vector3 p)
    {
        float step = 40f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, p, step);
        transform.LookAt(p);
        

        if (transform.position == p)
        {
            //transform.position = transform.position;
            //Monster.look(transform, transform.position, p);
        }
    }
}
