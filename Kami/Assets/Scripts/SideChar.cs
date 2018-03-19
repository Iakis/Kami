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
        //Gets and setsinitial character objects
        m_izanagi = Movement.Get();
        m_izanami = Nami.Get();
        
        mainChar = m_izanagi.gameObject;
        sideChar = m_izanami.gameObject;
        //Find safe spot
        safeSpots();
    }

    //Swap main character and side character (when izanami possesses)
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
        //Distance between main and side character
        dis = Vector3.Distance(mainChar.transform.position, sideChar.transform.position);
        //When not in combat - meet, else run
        if (!mainChar.GetComponent<Movement>().inCombat)
        {
            meet();
        }
        else
        {
            run();
        }
        
    }

    //Side character follow main charater and set animation to walk
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

    //Run to the nearest designated safe spot when main character enters combat
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

    //Get the nearest safe spot
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
