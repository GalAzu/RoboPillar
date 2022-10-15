using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distanceFromTarget;
    private float yaw;
    private float pitch;
    public Vector2 pitchMinMax;
    //public Vector2 yawMinMax;
    [SerializeField] private float mouseSensitivity;
    public float rotationSmoothTime;
    public Vector3 rotationSmoothVelocity;
    public Vector3 curRotation;
    public bool lockCursor;

    private void Start()
    {
        if(lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    private void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch += Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
        //yaw = Mathf.Clamp(yaw, yawMinMax.x, yawMinMax.y);

        curRotation = Vector3.SmoothDamp(curRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);

        transform.eulerAngles = curRotation;

        transform.position = target.position - transform.forward * distanceFromTarget;

    }
}