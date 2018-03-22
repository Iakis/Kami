using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenguAI : MonoBehaviour {

    private bool dead = false;
    public int health;
    float dNagi;
    bool attacking;

    GameObject target;
    Vector3 dir;

    Animator anim;
    public AnimatorStateInfo currentBaseState;

    //AudioSource axeSound;
    //AudioSource fallSound;

    static SideChar c;

    //For gravity
    static float globalGravity = -9.81f;
    float gravityScale = 1.0f;

    //Get the weapon
    spear m_spear;

    //Animation states we want to keep track of for scripting
    public static int attackState = Animator.StringToHash("Base Layer.tattack");
    public static int deadState = Animator.StringToHash("Base Layer.tdie");
    

    // Use this for initialization
    void Start()
    {
        health = 10;
        anim = gameObject.GetComponent<Animator>();
        attacking = false;
        //axeSound = GameObject.Find("AxeSound").GetComponent<AudioSource>();
        //fallSound = GameObject.Find("OniFallSound").GetComponent<AudioSource>();
        c = SideChar.Get();
    }

    // Update is called once per frame
    void Update()
    {
        //Apply Gravity
        gravity();
        //Get the current animation state
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        //If alive and has detected the player (target)
        if (health > 0 && target != null)
        {
            //Look at player
            //transform.LookAt(target.transform);
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
                //Set player to in combat
                c.combat();
                if (dNagi > 7.5)
                {
                    transform.LookAt(target.transform);
                    //This enables the walk animation
                    anim.SetFloat("Speed", 1);
                    //Set speed and walk towards palyer
                    float step = 4f * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
                }
                else
                {
                    //Do attack animation, trigger axe collider etc.
                    anim.SetFloat("Speed", 0);
                    transform.position = transform.position;
                    anim.SetTrigger("Attack");
                    StartCoroutine("stab");
                    attacking = true;
                }
            }
        }
    }

    //Called when player attacks
    public void damage(int x, string attacker)
    {
        health -= x;
        if (attacker == "Oni")
        {
            health -= 2 * x;
        }
        else if (attacker == "Yukiona")
        {
            health -= 0.5 * x;
        }
        else if (attacker == "Izanagi")
        {
            health -= 1 * x;
        }
    }

    void gravity()
    {
        //Not sure if we need this, will see
        //Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        //s_rigidBody.AddForce(gravity, ForceMode.Acceleration);
    }

    //IEnumerator smash()
    //{
    //    //Enable/disable weapon collider depending on animation
    //    yield return new WaitForSeconds(0.3f);
    //    m_axe.GetComponent<BoxCollider>().enabled = true;
    //    axeSound.Play();
    //    yield return new WaitForSeconds(0.7f);
    //    m_axe.GetComponent<BoxCollider>().enabled = false;

    //}

    IEnumerator stab()
    {
        yield return new WaitForSeconds(1f);
        // dash toward
        transform.position = Vector3.MoveTowards(transform.position, transform.position+transform.rotation * Vector3.forward, 1f);
        m_spear.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(0.4f);
        m_spear.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine("stop");
        // animation for stab
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
