using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region components
    Animator animator;

    #endregion components

    private float curSpeed = 1;
    public float RunMultiplier = 1;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rigidbody in rigidbodies) {
                rigidbody.isKinematic = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
            curSpeed *= RunMultiplier;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            curSpeed /= RunMultiplier;

        Vector2 dir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * curSpeed;
        animator.SetFloat("Speed", dir.magnitude);
    }
}
