
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possess : MonoBehaviour {

    GameObject target;
    GameObject m_izanagi;
    static Nami m_izanami;

    public AnimatorStateInfo mainState;
    public AnimatorStateInfo sideState;
    public ParticleSystem ps;
    static SideChar c;

	public bool possed;


    public static int reviveState = Animator.StringToHash("Base Layer.orevive");
    public static int attackState = Animator.StringToHash("Base Layer.oattack");
    public static int deadState = Animator.StringToHash("Base Layer.odie");
    public static int idleState = Animator.StringToHash("Base Layer.idle");
    public static int locomotion = Animator.StringToHash("Base Layer.Locomotion");
    // Use this for initialization
    void Start () {
        c = SideChar.Get();
        m_izanagi = Movement.Get().gameObject;
        m_izanami = Nami.Get();
    }
	
	// Update is called once per frame
    void Update()
    {
        mainState = c.mainChar.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        sideState = c.sideChar.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
    }

	void LateUpdate () {
        if (Input.GetButtonUp("YButton"))
        {
            if (!possed)
            {
                targets();
                if (target != null)
                {
                    poss();
                }
            } else
            {
                if (mainState.fullPathHash == locomotion || mainState.fullPathHash == idleState)
                {
                    unposs();
                } else
                {
                    return;
                }
            }
            
        }
    }

    void targets()
    {
        int layerMask = 1 << 10;
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 5f, layerMask);
        int i = 0;
        float mindist = 99;
        float dis = 0;
        while (i < hitColliders.Length)
        {
            dis = Vector3.Distance(gameObject.transform.position, hitColliders[i].gameObject.transform.position);
            if (dis < mindist)
            {
                if (hitColliders[i].gameObject.GetComponent<Monster>().health <= 0)
                {
                    if (Vector3.Distance(hitColliders[i].gameObject.transform.position, transform.position) < 3)
                    {
                        target = hitColliders[i].gameObject;
                    }
                }
                    
            }
            i++;
        }
    }

    void poss()
    {
        m_izanagi.GetComponent<Movement>().enabled = false;
        m_izanagi.GetComponent<Slash>().enabled = false;
        target.GetComponent<IzaOni>().enabled = true;
        possed = true;
        m_izanami.setPoss(target);
        c.swap();
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        ps.Emit(1);
    }

    void unposs()
    {
        
        m_izanagi.GetComponent<Movement>().enabled = true;
        m_izanagi.GetComponent<Slash>().enabled = true;
        target.GetComponent<IzaOni>().enabled = false;
        target.GetComponent<Monster>().die();
        possed = false;
        m_izanami.setPoss(null);
        m_izanami.transform.position = target.transform.position;
        c.swap();
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        ps.Emit(1);
        target = null;
    }
}
