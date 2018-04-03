using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OniAI : Monster
{
    AudioSource axeSound;
    public GameObject Axe;
    public bool isAttacking;
    Rigidbody rb;

    void Start()
    {
        health = 1;
        anim = gameObject.GetComponent<Animator>();
        attacking = false;
        axeSound = GameObject.Find("AxeSound").GetComponent<AudioSource>();
        movespeed = 8;
        combatRange = 20;
        attackRange = (float)5.5;
        weapon = Axe;
        attk = hit;
        spawn = this.transform.position;
        fallSound = GameObject.Find("OniFallSound").GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        alive();
    }

    void hit()
    {
        anim.SetFloat("Speed", 0);
        transform.position = transform.position;
        anim.SetTrigger("Attack");
        StopCoroutine("smash");
        StartCoroutine("smash");
        attacking = true;
    }

    IEnumerator smash()
    {
        //rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        //Enable/disable weapon collider depending on animation
        yield return new WaitForSeconds(0.7f);
        // For tutorial
        isAttacking = true;
        weapon.GetComponent<BoxCollider>().enabled = true;
        StartCoroutine("playAxe");
        yield return new WaitForSeconds(0.8f);
        isAttacking = false;
        attacking = false;
        // For tutorial
        weapon.GetComponent<BoxCollider>().enabled = false;
        //rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
    }

    IEnumerator playAxe()
    {
        yield return new WaitForSeconds(0.2f);
        axeSound.Play();
    }

}
