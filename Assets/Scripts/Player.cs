using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region components


    #endregion components

    public float speed;
    public float jumpPower;
    public static float x = 250;
    public float run;

    private float gravity;
    private Vector3 move;
    private CharacterController ch_controller;
    private Animator anim;
    void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            speed = speed * run;
        Move();
        Gravity();
    }
    private void Move()
    {

        if (ch_controller.isGrounded)
        {
            move = Vector3.zero;
            move.x = Input.GetAxis("Horizontal") * speed;
            move.z = Input.GetAxis("Vertical") * speed;

            if (move.x != 0 || move.z != 0)
                anim.SetBool("Walk", true);
            else
                anim.SetBool("Walk", false);

            if (Vector3.Angle(Vector3.forward, move) > 1f || Vector3.Angle(Vector3.forward, move) == 0)
            {
                Vector3 direct = Vector3.RotateTowards(transform.forward, move, speed, 0.0f);
                transform.rotation = Quaternion.LookRotation(direct);
            }
        }
        move.y = gravity;
        ch_controller.Move(move * Time.deltaTime);
    }
    private void Gravity()
    {
        if (!ch_controller.isGrounded)
            gravity -= 20f * Time.deltaTime;
        else
            gravity = -1f;
        if (Input.GetKeyDown(KeyCode.Space) && ch_controller.isGrounded)
            gravity = jumpPower;


    }
}





