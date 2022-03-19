using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public float initialDrag;
    public VariableJoystick variableJoystick;
    public Rigidbody2D rb;
    public GameObject car;

    private void Start()
    {
        initialDrag = rb.drag;
    }

    public void FixedUpdate()
    {
        if (variableJoystick.Vertical == 0)
        {
            rb.drag += Time.fixedDeltaTime;
        }
        else
        {
            if (variableJoystick.Horizontal > 0) RotateRight();
            else if (variableJoystick.Horizontal < 0) RotateLeft();
            else if(variableJoystick.Horizontal == 0) Center();
            rb.drag = initialDrag;
            Vector2 direction = Vector2.up * variableJoystick.Vertical + Vector2.right * variableJoystick.Horizontal;
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }

    public Vector3 euler;
    public float rotationSpeed;
    private void RotateLeft()
    {
        euler = car.transform.eulerAngles;
        if(!(euler.z < 32 && euler.z > 28))
            car.transform.Rotate(Vector3.forward * -variableJoystick.Horizontal * rotationSpeed);
    }

    private void RotateRight()
    {
        euler = car.transform.eulerAngles;
        if (!(euler.z < 332 && euler.z > 328))
            car.transform.Rotate(Vector3.forward * -variableJoystick.Horizontal * rotationSpeed);
    }
    private void Center()
    {
        if(euler.z > 180) car.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        else if(euler.z < 180) car.transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
    }
}