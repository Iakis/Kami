﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideChar : MonoBehaviour
{

    static SideChar c;
    [SerializeField]
    float movespeed = 7.5f;
    [SerializeField]
    float pmovespeed = 10f;
    [SerializeField]
    float mult = 1.5f;
    float dis, dist;
    public GameObject mainChar;
    public GameObject sideChar;
    GameObject safeSpot;
    static Movement m_izanagi;
    static Nami m_izanami;
    static CameraFollow cam;
    public static bool dead;
    bool poss;
    public static bool inCombat;
    Rigidbody s_RigidBody;

    [SerializeField]
    float jumpheight = 5f;

    float gravityScale = 5f;
    static float globalGravity = -9.81f;
    public bool grounded;
    Animator anim;

    static AudioSource startingMusic;
    static AudioSource combatMusic;
    public bool follow;

    SideChar()
    {
        c = this;
    }

    public static SideChar Get()
    {
        return c;
    }

    // Use this for initialization
    void Start()
    {
        //Gets and setsinitial character objects
        m_izanagi = Movement.Get();
        m_izanami = Nami.Get();
        cam = CameraFollow.Get();
        poss = false;
        mainChar = m_izanagi.gameObject;
        sideChar = m_izanami.gameObject;
        anim = sideChar.GetComponent<Animator>();
        //Find safe spot
        safeSpots();
        inCombat = false;
        s_RigidBody = sideChar.GetComponent<Rigidbody>();
        grounded = true;
        startingMusic = GameObject.Find("StartingMusic").GetComponent<AudioSource>();
        combatMusic = GameObject.Find("CombatMusic").GetComponent<AudioSource>();
        dead = false;
        follow = false;
    }

    //Swap main character and side character (when izanami possesses)
    public void swap()
    {
        if (mainChar == m_izanagi.gameObject)
        {
            mainChar = m_izanami.possesse;
            sideChar = m_izanagi.gameObject;
            mainChar.tag = "Player";
            sideChar.tag = "Untagged";
            sideChar.GetComponent<Rigidbody>().isKinematic = true;
            anim = sideChar.GetComponent<Animator>();
            poss = true;
            cam.setTarget(mainChar);
        }
        else
        {
            mainChar.tag = "Untagged";
            mainChar = m_izanagi.gameObject;
            sideChar = m_izanami.gameObject;
            mainChar.tag = "Player";
            mainChar.GetComponent<Rigidbody>().isKinematic = false;
            sideChar.tag = "Untagged";
            poss = false;
            anim = sideChar.GetComponent<Animator>();
            cam.setTarget(mainChar);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //gravity();
        dead = m_izanagi.GetComponent<Movement>().dead;
        //Distance between main and side character
        dist = Vector3.Distance(mainChar.transform.position, sideChar.transform.position);
        dis = (float)System.Math.Round(dist);
        //When not in combat - meet, else run
        if (!inCombat)
        {
            meet();
            //if (Input.GetButtonUp("AButton"))
            //{
            //    if (grounded)
            //    {
            //        grounded = false;
            //        StartCoroutine("Jump");
            //    }
            //}
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
            follow = true;
            look(mainChar.transform);
            if (dis > 5)
            {
                if (poss)
                {
                    anim.SetFloat("Speed", 0.2f);
                } else
                {
                    anim.SetFloat("Speed", dist - 4.9f);
                }
                sideChar.transform.position = Vector3.MoveTowards(sideChar.transform.position, mainChar.transform.position, movespeed * (mult * dis) * Time.deltaTime);
            }
            else if (dis < 5)
            {
                anim.SetFloat("Speed", 0f);
                sideChar.transform.position = sideChar.transform.position;
            }
            else if (dis == 5)
            {
                if ((System.Math.Abs(Input.GetAxis("NagiY"))) + (System.Math.Abs(Input.GetAxis("NagiX"))) > 0)
                {
                    
                    if (poss)
                    {
                        anim.SetFloat("Speed", 0.2f);
                        sideChar.transform.position = Vector3.MoveTowards(sideChar.transform.position, mainChar.transform.position, pmovespeed / 2 * Time.deltaTime);
                    } else
                    {
                        anim.SetFloat("Speed", dist - 4.9f);
                        sideChar.transform.position = Vector3.MoveTowards(sideChar.transform.position, mainChar.transform.position, movespeed / 2 * Time.deltaTime);
                    }
                    
                }
                else
                {
                    anim.SetFloat("Speed", 0f);
                    sideChar.transform.position = sideChar.transform.position;
                }
            }
        } else
        {
            follow = false;
        }
    }

    public static IEnumerator combat()
    {
        inCombat = true;
        while (startingMusic.volume > 0)
        {
            startingMusic.volume -= 0.3f;
            combatMusic.volume += 0.3f;
            yield return new WaitForSeconds(1f);
        }
        startingMusic.Pause();
        if (!combatMusic.isPlaying)
        {
            combatMusic.Play();
        }
    }

    public static IEnumerator outCombat()
    {
        inCombat = false;
        while (combatMusic.volume > 0)
        {
            combatMusic.volume -= 0.3f;
            yield return new WaitForSeconds(1f);
        }
        combatMusic.Stop();
        startingMusic.UnPause();
        while (startingMusic.volume < 1)
        {
            startingMusic.volume += 0.1f;
            yield return new WaitForSeconds(1f);
        }
    }

    //Run to the nearest designated safe spot when main character enters combat
    void run()
    {
        safeSpots();
        if (safeSpot != null)
        {
            if ((Vector3.Distance(sideChar.transform.position, safeSpot.transform.position) <= 3f))
            {
                look(mainChar.transform);
                anim.SetFloat("Speed", 0f);
            } else
            {
                sideChar.transform.position = Vector3.MoveTowards(sideChar.transform.position, safeSpot.transform.position, movespeed * Time.deltaTime);
                look(safeSpot.transform);
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

    void jump()
    {
        s_RigidBody.velocity = new Vector3(s_RigidBody.velocity.x, jumpheight, 0);
        anim.SetTrigger("Jump");
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.2f);
        jump();
    }

    protected void gravity()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        s_RigidBody.AddForce(gravity, ForceMode.Acceleration);
    }

    void look(Transform obj)
    {
        Quaternion rot;
        Vector3 a = new Vector3(sideChar.transform.position.x, 0, sideChar.transform.position.z);
        Vector3 b = new Vector3(obj.position.x, 0, obj.position.z);
        Vector3 relativePos = b - a;
        rot = Quaternion.LookRotation(relativePos);
        sideChar.transform.rotation = rot;
    }

    void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.layer == 8)
        {
            grounded = true;
        }
    }
}
