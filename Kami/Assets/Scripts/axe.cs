using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axe : MonoBehaviour {

    Transform parent;
    OniAI oni;
    Animator anim;
    BoxCollider col;
    static axe s_axe;

    public AnimatorStateInfo currentBaseState;
    public static int attackState = Animator.StringToHash("Base Layer.oattack");
    axe()
    {
        s_axe = this;
    }

    public static axe Get()
    {
        return s_axe;
    }

    void Start () {
        parent = transform.root;
        oni = parent.GetComponent<OniAI>();
        oni.setAxe(this);
	}
	
	// Update is called once per frame
	void Update () {
        anim = parent.GetComponent<Animator>();
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
    }

    void OnTriggerEnter(Collider col)
    {
        if (parent.tag == "Player")
        {
            Debug.Log("Player");
            if (col.gameObject.tag == "Enemy" && currentBaseState.fullPathHash == attackState)
            {
                Debug.Log("hit");
                col.gameObject.GetComponent<OniAI>().damage(10);
                col.GetComponent<Animator>().SetTrigger("hit");
            }
        }
        else
        {
            if (col.gameObject.tag == "Player" && currentBaseState.fullPathHash == attackState)
            {
                col.gameObject.GetComponent<Movement>().die();
            }
        }
        
    }
}
