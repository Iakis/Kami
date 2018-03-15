using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nami : MonoBehaviour {

    GameObject target;
    public GameObject possesse;
    static Movement m_izanagi;
    float dNagi;
    float movespeed = 10f;
    bool met;

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
        target = m_izanagi.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        //dNagi = Vector3.Distance(target.transform.position, transform.position);
        //meet();
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

    public void setPoss(GameObject p)
    {
        possesse = p;
    }

    

    
}
