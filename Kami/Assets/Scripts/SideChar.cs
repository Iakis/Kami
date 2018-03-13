using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideChar : MonoBehaviour {

    bool met;
    float movespeed = 10f;
    GameObject target;
    GameObject safeSpot;
    static Movement m_izanagi;
    static Nami m_izanami;

    // Use this for initialization
    void Start () {
        safeSpots();

    }
	
	// Update is called once per frame
	void Update () {
        run();
        m_izanagi = Movement.Get();
        m_izanami = Nami.Get();
        met = false;
    }

    void run()
    {
        if (safeSpot != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, safeSpot.transform.position, movespeed * Time.deltaTime);
        }
        if (transform.position == safeSpot.transform.position)
        {
            transform.LookAt(m_izanagi.transform);
        }
    }

    void safeSpots()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 50);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.tag == "safeSpot")
            {
                safeSpot = hitColliders[i].gameObject;
            }
            return;
        }
    }
}
