using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nami : MonoBehaviour {

    [SerializeField]
    bool canMove = true;
    GameObject target;
    public GameObject possesse;
    static Movement m_izanagi;
    float dNagi;
    float movespeed = 10f;
    bool met;
    private Rigidbody s_RigidBody;
    Animator anim;
    public AnimatorStateInfo currentBaseState;
    public static Nami s_izanami;

    static int waveState = Animator.StringToHash("Base Layer.nwave");

    Nami()
    {
        s_izanami = this;
    }

    public static Nami Get()
    {
        return s_izanami;
    }
    // Use this for initialization
    void Start () {
        m_izanagi = Movement.Get();
        target = m_izanagi.gameObject;
        s_RigidBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        if (met == false)
        {
            dNagi = Vector3.Distance(this.transform.position, m_izanagi.transform.position);
            dNagi = (float)System.Math.Round(dNagi);
            if (dNagi < 35)
            {
                transform.LookAt(m_izanagi.transform);
                anim.SetTrigger("wave");
                met = true;
                this.GetComponent<SideChar>().enabled = true;
                this.GetComponent<Possess>().enabled = true;
            }
        }
        else if (met == true && currentBaseState.fullPathHash != waveState)
        {
            return;
        }
    }

    public void setPoss(GameObject p)
    {
        possesse = p;
    }

    IEnumerator KnockBack()
    {
        yield return new WaitForSeconds(0.5f);
        canMove = true;
    }

    void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.layer == 17)
        {
            s_RigidBody.constraints = RigidbodyConstraints.FreezeRotation;
            StartCoroutine("KnockBack");
            canMove = false;

            Vector3 dir = collide.contacts[0].point - transform.position;
            dir = new Vector3(dir.x, 0f, dir.z);
            dir = -dir.normalized;
            transform.position += dir * 1f;
            StartCoroutine("KnockBack");
        }
        else
        {
            s_RigidBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
    }


}
