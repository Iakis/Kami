using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spear : MonoBehaviour {

    Transform parent;
    TenguAI tengu;
    BoxCollider col;
    static spear s_spear;

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
        tengu.setSpear(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.tag == "Player" && spear.currentBaseState.fullPathHash == TenguAI.attackState)
    //    {
    //        col.gameObject.GetComponent<Movement>().die();
    //    }
    //}
}
