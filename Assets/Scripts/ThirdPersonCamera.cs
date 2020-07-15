using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{

    private float curX = 0.0f;
    private float curY = 0.0f;


    public float Y_ANGLE_MIN = 10.0f;
    public float Y_ANGLE_MAX = 80.0f;
    public Transform target;
    public float distance = 5.0f;
    public float sensX = 4.0f;
    public float sensY = 4.0f;

    public int distanceMin = 4;
    public int distanceMax = 10;

    void Update()
    {
        curX += Input.GetAxis("Mouse X") * sensX;
        curY += Input.GetAxis("Mouse Y") * sensY;
        curY = Mathf.Clamp(curY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }
    void LateUpdate()
    {

        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(curY, curX, 0);

        transform.position = target.position + rotation * dir;
        transform.LookAt(target.transform);

        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            distance -= Mathf.Sign(Input.GetAxis("Mouse ScrollWheel"));
        distance = Mathf.Clamp(distance, distanceMin, distanceMax);
    }
}
