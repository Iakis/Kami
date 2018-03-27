using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OniAI : Monster
{
    AudioSource axeSound;
    public GameObject Axe;
    public bool isAttacking;

    void Start()
    {
        health = 30;
        anim = gameObject.GetComponent<Animator>();
        attacking = false;
        axeSound = GameObject.Find("AxeSound").GetComponent<AudioSource>();
        movespeed = 4;
        combatRange = 20;
        attackRange = (float)5.5;
        weapon = Axe;
        attk = hit;
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
        //Enable/disable weapon collider depending on animation
        yield return new WaitForSeconds(0.5f);
        // For tutorial
        isAttacking = true;
        weapon.GetComponent<BoxCollider>().enabled = true;
        StartCoroutine("playAxe");
        yield return new WaitForSeconds(0.6f);
        isAttacking = false;
        // For tutorial
        weapon.GetComponent<BoxCollider>().enabled = false;
    }

    IEnumerator playAxe()
    {
        yield return new WaitForSeconds(0.2f);
        axeSound.Play();
    }

}
