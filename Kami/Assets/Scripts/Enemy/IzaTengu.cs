using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IzaTengu : MonoBehaviour {

    [SerializeField]
    private float movespeed = 8f;
    [SerializeField]
    float gravityScale = 1.0f;
    [SerializeField]
    float jumpheight = 5f;
    Animator anim;
    Vector3 forward, right, heading;
    static float globalGravity = -9.81f;
    // Use this for initialization
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        anim = GetComponent<Animator>();
        revive();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gravity();
        if (Input.GetAxis("NagiY") != 0 || Input.GetAxis("NagiX") != 0)
        {
            move(movespeed);
            anim.SetFloat("Speed", (System.Math.Abs(Input.GetAxis("NagiY"))) + (System.Math.Abs(Input.GetAxis("NagiX"))));
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
    }

    protected void move(float movespeed)
    {
        Vector3 upMovement = forward * movespeed * Time.deltaTime * -(Input.GetAxis("NagiY"));
        Vector3 rightMovement = right * movespeed * Time.deltaTime * Input.GetAxis("NagiX");

        heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += upMovement;
        transform.position += rightMovement;
    }

    protected void gravity()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        //s_RigidBody.AddForce(gravity, ForceMode.Acceleration);
    }

    public void revive()
    {
        anim.SetTrigger("revive");
    }
}
