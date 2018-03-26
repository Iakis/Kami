using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    protected bool dead = false;
    public int health;
    protected bool attacking;
    protected float dNagi;
    protected float movespeed;
    protected float combatRange;
    protected float attackRange;
    protected Vector3 spawn;

    protected GameObject target;
    protected GameObject weapon;
    protected Animator anim;
    protected AudioSource fallSound;

    static SideChar c;

    static float globalGravity = -9.81f;
    float gravityScale = 1.0f;

    protected static int attackState = Animator.StringToHash("Base Layer.oattack");
    protected static int deadState = Animator.StringToHash("Base Layer.odie");
    public AnimatorStateInfo currentBaseState;

    protected delegate void attack();
    protected attack attk;

    // Use this for initialization

    void Start () {
        health = 1;
        attacking = false;
        anim = gameObject.GetComponent<Animator>();
        fallSound = GameObject.Find("OniFallSound").GetComponent<AudioSource>();
        c = SideChar.Get();
        
    }

    protected void alive()
    {
        if (health <= 0 && dead)
        {
            return;
        }
        //Apply Gravity
        //gravity();
        //Get the current animation state
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        if (health > 0 && target != null && !attacking)
        {
            //Look at player
            look(transform, transform.position, target.transform.position);
            //Distance between me and the player
            dNagi = Vector3.Distance(target.transform.position, transform.position);
            detect(movespeed, combatRange, attackRange, attk);
        }
        else if (health <= 0 && !dead)
        {
            //If the animator is not in dead state...else let the state play
            if (currentBaseState.fullPathHash != deadState)
            {
                dead = true;
                die();
                //Set the player to out of combat
                
            }
            else
            {

                return;
            }
        } else if (target == null)
        {
            anim.SetFloat("Speed", 0);
            this.GetComponent<SphereCollider>().enabled = true;
        }
    }

    protected void detect(float move, float cRange, float aRange, attack atk)
    {
        //If current animation is not attacking
        if (currentBaseState.fullPathHash != attackState)
        {
            attacking = false;
            if (dNagi < cRange && health > 0)
            {
                //Set player to in combat
                SideChar.combat();
                if (dNagi > aRange)
                {
                    //This enables the walk animation
                    anim.SetFloat("Speed", 1);
                    //Set speed and walk towards palyer
                    float step = movespeed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
                }
                else
                {
                    //Do attack animation, trigger axe collider etc.
                    atk();
                    
                }
            }
        }
    }

    public void damage(int x)
    {
        health -= 1;
    }

    public void die()
    {
        //Set layer to corpse layer
        SideChar.outCombat();
        this.gameObject.layer = 10;
        //Disable collision with corpse
        this.GetComponent<CapsuleCollider>().isTrigger = true;
        //Start death animation
        anim.SetTrigger("die");
        StartCoroutine("playFalling");
        //Disable weapon collider
        if (weapon != null)
        {
            weapon.GetComponent<BoxCollider>().enabled = false;
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            target = col.gameObject;
        }
    }

    IEnumerator playFalling()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("sound");
        Debug.Log(fallSound);
        fallSound.Play();
    }

    public static void look(Transform i, Vector3 me, Vector3 obj)
    {
        Quaternion rot;
        Vector3 a = new Vector3(me.x, 0, me.z);
        Vector3 b = new Vector3(obj.x, 0, obj.z);
        Vector3 relativePos = b - a;
        rot = Quaternion.LookRotation(relativePos);
        i.rotation = rot;
    }
}
