using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenguAI : MonoBehaviour {

    private bool dead = false;
    public int health;
    float dNagi;
    bool attacking;
    bool CD;
    bool dashing;

    GameObject target;
    Vector3 dir;

    Animator anim;
    public AnimatorStateInfo currentBaseState;

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
    Vector3 tar;

    //Animation states we want to keep track of for scripting
    public static int attackState = Animator.StringToHash("Base Layer.tattack");
    public static int deadState = Animator.StringToHash("Base Layer.tdie");

    
    // Use this for initialization
    void Start()
    {
        health = 30;
        anim = gameObject.GetComponent<Animator>();
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
        gravity();
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        if (dashing)
        {
            dash(tar);
            return;
        }
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
            //If the animator is not in dead state...else let the state play
            if (currentBaseState.fullPathHash != deadState)
            {
                dead = true;
                anim.SetTrigger("die");
                //Set the player to out of combat
                c.outCombat();
                StartCoroutine("playFalling");
            }
            else
            {
                return;
            }
        }
    }

    IEnumerator playFalling()
    {
        yield return new WaitForSeconds(2f);
        //fallSound.Play();
    }

    public void setSpear(spear mySpear)
    {
        m_spear = mySpear;
    }

    void detect()
    {
        //If current animation is not attacking
        if (currentBaseState.fullPathHash != attackState)
        {
            attacking = false;
            if (dNagi < 20 && health > 0)
            {
                startingMusic.mute = true;
                combatMusic.mute = false;
                //Set player to in combat
                c.combat();
                if (dNagi > 10)
                {
                    transform.LookAt(target.transform);
                    //This enables the walk animation
                    anim.SetFloat("Speed", 1);
                    //Set speed and walk towards palyer
                    float step = 4f * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
                }
                else if (CD == false && dNagi <= 10)
                {
                    //Do attack animation, trigger axe collider etc.
                    anim.SetFloat("Speed", 0);
                    transform.position = transform.position;
                    anim.SetTrigger("Attack");
                    StopCoroutine("stab");
                    StartCoroutine("stab");
                    
                    attacking = true;
                } else if(CD == true && dNagi <= 10)
                {
                    transform.LookAt(target.transform);
                    anim.SetFloat("Speed", 0);
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

    void gravity()
    {
        //Not sure if we need this, will see
        //Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        //s_rigidBody.AddForce(gravity, ForceMode.Acceleration);
    }

    IEnumerator stab()
    {
        CD = true;
        yield return new WaitForSeconds(0.8f);
        tar = target.transform.position;
        dashing = true;
        yield return new WaitForSeconds(2f);
        dashing = false;
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

    public void die()
    {
        //Set layer to corpse layer
        this.gameObject.layer = 10;
        //Disable collision with corpse
        this.GetComponent<CapsuleCollider>().isTrigger = true;
        //Start death animation
        anim.SetTrigger("die");
        StartCoroutine("playFalling");
        //Disable weapon collider
        m_spear.GetComponent<BoxCollider>().enabled = false;
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
