using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possess : MonoBehaviour {

    GameObject target;
    GameObject m_izanagi;
    static Nami m_izanami;

    bool possed;
    // Use this for initialization
    void Start () {
        m_izanagi = Movement.Get().gameObject;
        m_izanami = Nami.Get();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonUp("YButton"))
        {
            if (!possed)
            {
                targets();
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
            i++;
        }
    }

    void poss()
    {
        m_izanagi.GetComponent<Movement>().enabled = false;
        m_izanagi.GetComponent<Slash>().enabled = false;
        //target.AddComponent<Rigidbody>();
        target.AddComponent<Movement>();
        possed = true;
        m_izanami.setPoss(target);
        m_izanami.gameObject.GetComponent<SideChar>().swap();
        Debug.Log("poss");
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    void unposs()
    {
        m_izanagi.GetComponent<Movement>().enabled = true;
        m_izanagi.GetComponent<SideChar>().enabled = false;
        m_izanagi.GetComponent<Slash>().enabled = true;
        //Destroy(target.GetComponent<Rigidbody>());
        target.GetComponent<Movement>().enabled = false;
        target.GetComponent<OniAI>().die();
        possed = false;
        m_izanami.setPoss(null);
        m_izanami.transform.position = target.transform.position;
        m_izanami.gameObject.GetComponent<SideChar>().swap();
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
}
