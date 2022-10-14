using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacter : MonoBehaviour
{
    public Transform cameraTransform;
    public float walkSpeed;
    public float runSpeed;

    public float turnSmoothTime = 0.2f;
    public float turnSmoothVelocity;
    public float speedSmoothTime = 0.1f;
    public float speedSmoothVelocity;
    public float curSpeed;
    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }
    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;
        if(inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);

            bool running = Input.GetKey(KeyCode.LeftShift);
            float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;

            curSpeed = Mathf.SmoothDamp(curSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
            transform.Translate(transform.forward * curSpeed * Time.deltaTime, Space.World);

        }
    }
    private void CharacterMovement()
    {

    }
}
