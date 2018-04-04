using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endnami : MonoBehaviour {

    float dis, dist;
    float movespeed = 4;
    static endmovement m_izanagi;
    public GameObject model;
    SkinnedMeshRenderer sk;
    Animator anim;
    // Use this for initialization
    void Start () {
        m_izanagi = endmovement.Get();
        sk = model.GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(m_izanagi.transform.position, this.transform.position);
        dis = (float)System.Math.Round(dist);
        meet();
        anim = GetComponent<Animator>();
        fade();
        
    }

    void meet()
    {
        look(m_izanagi.transform);
        if (dis >= 5)
        {
            if (anim)
            {
                anim.SetFloat("Speed", 0.2f);
            }
            
            this.transform.position = Vector3.MoveTowards(this.transform.position, m_izanagi.transform.position, movespeed * Time.deltaTime);
        }
        else if (dis < 5)
        {
            if (anim)
            {
                anim.SetFloat("Speed", 0f);
            }
            
            this.transform.position = this.transform.position;
        }
    }

    void look(Transform obj)
    {
        Quaternion rot;
        Vector3 a = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        Vector3 b = new Vector3(obj.position.x, 0, obj.position.z);
        Vector3 relativePos = b - a;
        rot = Quaternion.LookRotation(relativePos);
        this.transform.rotation = rot;
    }

    void fade()
    {
        foreach (Material m in sk.materials)
        {
            Color c = m.GetColor("_Color");
            c.a = (28 - transform.position.x) / 35;
            if (c.a >= 1)
            {
                c.a = 1;
            }
            else if (c.a <= 0)
            {
                c.a = 0;
            }
            Debug.Log(c.a);
            m.SetColor("_Color", c);
        }
    }
}
