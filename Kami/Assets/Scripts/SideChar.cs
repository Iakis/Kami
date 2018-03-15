using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideChar : MonoBehaviour {

    float movespeed = 10f;
    float dis;
    GameObject mainChar;
    GameObject sideChar;
    GameObject safeSpot;
    static Movement m_izanagi;
    static Nami m_izanami;

    Animator anim;

    // Use this for initialization
    void Start () {
        m_izanagi = Movement.Get();
        m_izanami = Nami.Get();
        
        mainChar = m_izanagi.gameObject;
        sideChar = m_izanami.gameObject;
        safeSpots();
    }

    public void swap()
    {
        if (mainChar == m_izanagi.gameObject)
        {
            mainChar = m_izanami.possesse;
            sideChar = m_izanagi.gameObject;
            anim = sideChar.GetComponent<Animator>();
        } else
        {
            mainChar = m_izanagi.gameObject;
            sideChar = m_izanami.gameObject;
            anim = null;
        }
    }
	
	// Update is called once per frame
	void Update () {
        dis = Vector3.Distance(mainChar.transform.position, sideChar.transform.position);
        if (!mainChar.GetComponent<Movement>().inCombat)
        {
            meet();
        }
        else
        {
            run();
        }
        
    }

    void meet()
    {
        if (dis < 15)
        {
            sideChar.transform.LookAt(mainChar.transform);
            if (dis > 4)
            {
                if (anim)
                {
                    anim.SetFloat("Speed", 1);
                }
                
                sideChar.transform.position = Vector3.MoveTowards(sideChar.transform.position, mainChar.transform.position, movespeed * Time.deltaTime);
            }
            else
            {
                anim.SetFloat("Speed", (System.Math.Abs(Input.GetAxis("NagiY"))) + (System.Math.Abs(Input.GetAxis("NagiX"))));
                sideChar.transform.position = sideChar.transform.position;
            }
        }
    }

    void run()
    {
        safeSpots();
        if (safeSpot != null)
        {
            sideChar.transform.position = Vector3.MoveTowards(sideChar.transform.position, safeSpot.transform.position, movespeed * Time.deltaTime);
            if (sideChar.transform.position == safeSpot.transform.position)
            {
                sideChar.transform.LookAt(m_izanagi.transform);
            }
        }
        
    }

    void safeSpots()
    {
        Collider[] hitColliders = Physics.OverlapSphere(sideChar.transform.position, 50);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.tag == "safeSpot")
            {
                safeSpot = hitColliders[i].gameObject;
                return;
            }
            i++;
        }
    }
}
