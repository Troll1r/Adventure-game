using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    /*private float curY = 0.0f;


    public float mouseSens=4f;
    public Transform playerBody;    
    public float xRotation = 0;*/


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    /*void Update()
    {
        float mouseX = Input.GetAxis("MouseX") * mouseSens;
        float mouseY = Input.GetAxis("MouseY") * mouseSens;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f );

        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        playerBody.Rotate(Vector3.up * mouseX);*/

    private float cur = 0.0f;
    private float curY = 0.0f;


    public float Y_ANGLE_MIN = 10.0f;
    public float Y_ANGLE_MAX = 80.0f;
    public Transform target;
    public float distance = 5.0f;
    public float sensX = 4.0f;
    public float sensY = 4.0f;

    private int distanceMin = 4;
    private int distanceMax = 4;

    void Update()
    {
        cur += Input.GetAxis("MouseX") * sensX;
        curY += Input.GetAxis("MouseY") * sensY;
        curY = Mathf.Clamp(curY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }
    void LateUpdate()
    {

        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(curY, cur, 0);

        transform.position = target.position + rotation * dir;
        transform.LookAt(target.transform);

        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            distance -= Mathf.Sign(Input.GetAxis("Mouse ScrollWheel"));
        distance = Mathf.Clamp(distance, distanceMin, distanceMax);






    }
}
