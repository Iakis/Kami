using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideChar : MonoBehaviour {

    static SideChar c;
    float movespeed = 10f;
    float pmovespeed = 4f;
    float dis;
    GameObject mainChar;
    GameObject sideChar;
    GameObject safeSpot;
    static Movement m_izanagi;
    static Nami m_izanami;
    bool poss;
    public bool inCombat;

    Animator anim;

    SideChar()
    {
        c = this;
    }

    public static SideChar Get()
    {
        return c;
    }

    // Use this for initialization
    void Start () {
        //Gets and setsinitial character objects
        m_izanagi = Movement.Get();
        m_izanami = Nami.Get();
        poss = false;
        mainChar = m_izanagi.gameObject;
        sideChar = m_izanami.gameObject;
        //Find safe spot
        safeSpots();
        inCombat = false;
    }

    //Swap main character and side character (when izanami possesses)
    public void swap()
    {
        if (mainChar == m_izanagi.gameObject)
        {
            mainChar = m_izanami.possesse;
            sideChar = m_izanagi.gameObject;
            anim = sideChar.GetComponent<Animator>();
            poss = true;
        } else
        {
            mainChar = m_izanagi.gameObject;
            sideChar = m_izanami.gameObject;
            poss = false;
            anim = null;
        }
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(inCombat);
        //Distance between main and side character
        dis = Vector3.Distance(mainChar.transform.position, sideChar.transform.position);
        dis = (float)System.Math.Round(dis);
        //When not in combat - meet, else run
        if (!inCombat)
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
            if (dis > 5)
            {
                if (anim)
                {
                    anim.SetFloat("Speed", 0.2f);
                }
                sideChar.transform.position = Vector3.MoveTowards(sideChar.transform.position, mainChar.transform.position, movespeed * Time.deltaTime);
            }
            else if (dis < 5)
            {
                anim.SetFloat("Speed", 0f);
                sideChar.transform.position = sideChar.transform.position;
            } else if (dis == 5)
            {
                if ((System.Math.Abs(Input.GetAxis("NagiY"))) + (System.Math.Abs(Input.GetAxis("NagiX"))) > 0)
                {
                    anim.SetFloat("Speed", 0.2f);
                    sideChar.transform.position = Vector3.MoveTowards(sideChar.transform.position, mainChar.transform.position, pmovespeed/2 * Time.deltaTime);
                } else
                {
                    anim.SetFloat("Speed", 0f);
                    sideChar.transform.position = sideChar.transform.position;
                }
            }
        }
    }

    public void combat()
    {
        Debug.Log("combat");
        inCombat = true;
    }

    public void outCombat()
    {
        Debug.Log("out");
        inCombat = false;
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
                sideChar.transform.LookAt(mainChar.transform);
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
