using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possess : MonoBehaviour {

    GameObject target;
    static Movement m_izanagi;

    bool possed;
    // Use this for initialization
    void Start () {
        m_izanagi = Movement.Get();
    }
	
	// Update is called once per frame
	void Update () {
        targets();
        if (Input.GetButtonUp("YButton"))
        {
            if (!possed)
            {
                poss();
            } else
            {
                unposs();
            }
            
        }
    }

    void targets()
    {
        int layerMask = 1 << 9;
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 10, layerMask);
        int i = 0;
        float mindist = 99;
        float dis = 0;
        while (i < hitColliders.Length)
        {
            dis = Vector3.Distance(gameObject.transform.position, hitColliders[i].gameObject.transform.position);
            if (dis < mindist)
            {
                if (hitColliders[i].gameObject.GetComponent<OniAI>().health <= 0)
                {
                    target = hitColliders[i].gameObject;
                }
            }
            return;
        }
    }

    void poss()
    {
        m_izanagi.GetComponent<Movement>().enabled = false;
        m_izanagi.GetComponent<SideChar>().enabled = true;
        target.AddComponent<Movement>();
        //target.GetComponent<OniAI>().enabled = false;
        Debug.Log("poss");
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;

    }

    void unposs()
    {
        m_izanagi.GetComponent<Movement>().enabled = true;
        m_izanagi.GetComponent<SideChar>().enabled = false;
        target.GetComponent<Movement>().enabled = false;
        //target.GetComponent<OniAI>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
