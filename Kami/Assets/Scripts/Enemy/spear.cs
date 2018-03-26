﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spear : MonoBehaviour {

    Transform parent;
    TenguAI tengu;
    Animator anim;
    BoxCollider col;
    static spear s_spear;

    public AnimatorStateInfo currentBaseState;
    public static int attackState = Animator.StringToHash("Base Layer.oattack");
    spear()
    {
        s_spear = this;
    }

    public static spear Get()
    {
        return s_spear;
    }

    void Start()
    {
        parent = transform.root;
        tengu = parent.GetComponent<TenguAI>();
    }

    // Update is called once per frame
    void Update()
    {
        anim = parent.GetComponent<Animator>();
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        if (this.GetComponent<BoxCollider>().enabled == true)
        {
            this.GetComponent<TrailRenderer>().enabled = true;
        } else
        {
            this.GetComponent<TrailRenderer>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && currentBaseState.fullPathHash == attackState && SideChar.dead == false)
        {
            col.gameObject.GetComponent<Movement>().die();
        }
    }
}