using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukiAI : MonoBehaviour
{

    private bool dead = false;
    public int health;
    float dNagi;
    bool attacking;
    bool CD;
    bool dashing;

    GameObject target;
    Vector3 dir;

    //AudioSource axeSound;
    //AudioSource fallSound;
    AudioSource startingMusic;
    AudioSource combatMusic;

    static SideChar c;

    //For gravity
    static float globalGravity = -9.81f;
    float gravityScale = 1.0f;

    //Get the weapon
    spear m_spear;
    Transform tar;

    //Animation states we want to keep track of for scripting



    // Use this for initialization
    void Start()
    {
        health = 30;
        attacking = false;
        //axeSound = GameObject.Find("AxeSound").GetComponent<AudioSource>();
        //fallSound = GameObject.Find("OniFallSound").GetComponent<AudioSource>();
        startingMusic = GameObject.Find("StartingMusic").GetComponent<AudioSource>();
        combatMusic = GameObject.Find("CombatMusic").GetComponent<AudioSource>();
        c = SideChar.Get();
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0 && target != null)
        {
            //Look at player
            transform.LookAt(target.transform);
            //Distance between me and the player
            dNagi = Vector3.Distance(target.transform.position, transform.position);
            detect();
        }
        else if (health == 0 && !dead)
        {
            dead = true;
            //Set the player to out of combat
            SideChar.outCombat();
        }
    }

    void detect()
    {
        if (1 == 1)
        {
            attacking = false;
            if (dNagi < 20 && health > 0)
            {
                startingMusic.mute = true;
                combatMusic.mute = false;
                //Set player to in combat
                SideChar.combat();
                if (dNagi > 12)
                {
                    transform.LookAt(target.transform);
                    float step = 4f * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
                }
                else if (CD == false && dNagi <= 12)
                {
                    transform.position = transform.position;
                    StopCoroutine("cooldown");
                    StartCoroutine("cooldown");
                    tar = target.transform;
                    ice(tar);
                    attacking = true;
                }
                else if (CD == true && dNagi <= 12)
                {
                    transform.LookAt(target.transform);
                    transform.position = transform.position;
                }
            }
        }
    }

    //Called when player attacks
    public void damage(int x, string attacker)
    {
        if (attacker == "Oni")
        {
            health -= 4 * x;
        }
        else if (attacker == "Yukiona")
        {
            health -= 1 * x;
        }
        else if (attacker == "Izanagi")
        {
            health -= 2 * x;
        }
    }

    void ice(Transform pos)
    {
        Quaternion rot = Quaternion.LookRotation(Vector3.up);
        GameObject go = (GameObject)Instantiate(Resources.Load("ice", typeof(GameObject)), pos.position, rot);
        Destroy(go, 2f);
    }

    IEnumerator cooldown()
    {
        CD = true;
        yield return new WaitForSeconds(2.5f);
        CD = false;
    }

    void dash(Vector3 tar)
    {
        float step = 40f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, tar, step);

        if (transform.position == tar)
        {
            transform.position = transform.position;
        }
    }


    //Monster have a large sphere trigger collider, use this to set target as player
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            target = col.gameObject;
        }
    }


}
