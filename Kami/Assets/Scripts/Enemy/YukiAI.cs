using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukiAI : Monster
{
    bool CD;
    Transform tar;

    void Start()
    {
        health = 1;
        anim = gameObject.GetComponent<Animator>();
        attacking = false;
        movespeed = 6;
        combatRange = 20;
        attackRange = 10;
        attk = hit;
        CD = false;
        fallSound = GameObject.Find("OniFallSound").GetComponent<AudioSource>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (attacking == false)
        {
            alive();
        }
        
    }

    void hit()
    {
        if (CD == false)
        {
            anim.SetFloat("Speed", 0);
            transform.position = transform.position;
            StopCoroutine("cooldown");
            StartCoroutine("cooldown");
            tar = target.transform;
            StopCoroutine("ice");
            StartCoroutine("ice");
            attacking = true;
        } else
        {
            anim.SetFloat("Speed", 0);
            transform.LookAt(tar);
            transform.position = transform.position;
        }
        
    }

    IEnumerator ice()
    {
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(1.55f);
        Quaternion rot = Quaternion.LookRotation(Vector3.up);
        Vector3 pos = new Vector3(tar.position.x, transform.position.y, tar.position.z);
        GameObject go = (GameObject)Instantiate(Resources.Load("ice", typeof(GameObject)), pos, rot);
        Destroy(go, 2f);
        attacking = false;
        yield break;
        
        
    }

    IEnumerator cooldown()
    {
        CD = true;
        yield return new WaitForSeconds(4f);
        CD = false;
    }

}
