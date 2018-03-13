using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nami : MonoBehaviour {

    bool met;
    GameObject target;
    GameObject safeSpot;
    static Movement m_izanagi;
    float dNagi;
    float movespeed = 10f;

    public static Nami s_izanami;

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
        met = false;
        target = m_izanagi.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        dNagi = Vector3.Distance(m_izanagi.transform.position, transform.position);
        if (!m_izanagi.inCombat)
        {
            meet();
            this.gameObject.GetComponent<SideChar>().enabled = false;
        } else
        {
            this.gameObject.GetComponent<SideChar>().enabled = true;
        }
    }

    void meet()
    {
        {
            if (dNagi < 15)
            {
                transform.LookAt(m_izanagi.transform);
                if (dNagi > 4)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, movespeed * Time.deltaTime);
                }
                else
                {
                    transform.position = transform.position;
                }
            }
        }
    }

    

    
}
