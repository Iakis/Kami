using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spear : MonoBehaviour {

    Transform parent;
    TenguAI tengu;
    Animator anim;
    BoxCollider col;
    static spear s_spear;
	public Text story;

    public AnimatorStateInfo currentBaseState;
    public static int attackState = Animator.StringToHash("Base Layer.oattack");

    static Possess p;

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
        p = Possess.Get();
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

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "shield")
        {
            //GameObject go = (GameObject)Instantiate(Resources.Load("light", typeof(GameObject)), parent.transform.position, transform.rotation);
            //Destroy(go, 2f);
            StartCoroutine("shock");
            if (col.gameObject.GetComponent<Barrier>().breakk == false)
            {
                col.gameObject.GetComponent<Barrier>().breakB();
            }

        }
    }

    IEnumerator shock()
    {
        yield return new WaitForSeconds(1f);
        tengu.GetComponent<IzaOni>().enabled = false;
        Quaternion rot = Quaternion.LookRotation(Vector3.up);
        Vector3 pos = new Vector3(tengu.transform.position.x, tengu.transform.position.y + 1, tengu.transform.position.z);
        GameObject go = (GameObject)Instantiate(Resources.Load("light", typeof(GameObject)), pos, rot);
        //GameObject go2 = (GameObject)Instantiate(Resources.Load("bolt", typeof(GameObject)), pos, rot);
        Destroy(go, 1f);
        //Destroy(go2, 1.5f);
        yield return new WaitForSeconds(1f);
        p.unposs();
        Destroy(parent.gameObject);
        Destroy(this.gameObject);
    }
}
