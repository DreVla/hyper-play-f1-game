using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public float initialDrag = 2;
    public VariableJoystick variableJoystick;
    public Rigidbody2D rb;
    public GameObject car;
    public GameObject boostParticles;



    public void FixedUpdate()
    {
        if (variableJoystick.Vertical == 0)
        {
            if (variableJoystick.Horizontal == 0) Center();
            boostParticles.SetActive(false);
        }
        else
        {
            if (variableJoystick.Horizontal > 0) RotateRight();
            else if (variableJoystick.Horizontal < 0) RotateLeft();
            // Check if need to show boost particle effect
            if (variableJoystick.Vertical > 0.5)
            {
                boostParticles.SetActive(true);
            }
            else
            {
                boostParticles.SetActive(false);
            }
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
        if (!(euler.z < 32 && euler.z > 28))
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
        float carAngle = car.transform.eulerAngles.z;
        if (carAngle > 180 && carAngle < 358)
            car.transform.Rotate(Vector3.forward * rotationSpeed);
        else if (carAngle < 180 && carAngle > 2)
            car.transform.Rotate(Vector3.forward * -rotationSpeed);
    }
}