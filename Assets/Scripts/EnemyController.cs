using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float initialDrag = 2;
    public VariableJoystick variableJoystick;
    public Rigidbody2D rb;
    public GameObject car;
    private List<float> horizontalInput;
    private List<float> verticalInput;
    public float timerDelay;
    private int directionIndex;

    private void Start()
    {
        horizontalInput = new List<float>();
        verticalInput = new List<float>();
    }

    public void FixedUpdate()
    {
        if (timerDelay > 0)
        {
            timerDelay -= Time.fixedDeltaTime;
            horizontalInput.Add(variableJoystick.Horizontal);
            verticalInput.Add(variableJoystick.Vertical);
        } 
        else
        {
            horizontalInput.Add(variableJoystick.Horizontal);
            verticalInput.Add(variableJoystick.Vertical);
            directionIndex++;
            if (verticalInput[directionIndex] == 0)
            {
                if (horizontalInput[directionIndex] == 0) Center();
            }
            else
            {
                if (horizontalInput[directionIndex] > 0) RotateRight(directionIndex);
                else if (horizontalInput[directionIndex] < 0) RotateLeft(directionIndex);
                Vector2 direction = Vector2.right * horizontalInput[directionIndex];
                rb.drag = initialDrag;
                rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            }
        }
    }

    public Vector3 euler;
    public float rotationSpeed;
    private void RotateLeft(int directionIndex)
    {
        euler = car.transform.eulerAngles;
        if(!(euler.z < 32 && euler.z > 28))
            car.transform.Rotate(Vector3.forward * -horizontalInput[directionIndex] * rotationSpeed);
    }

    private void RotateRight(int directionIndex)
    {
        euler = car.transform.eulerAngles;
        if (!(euler.z < 332 && euler.z > 328))
            car.transform.Rotate(Vector3.forward * -horizontalInput[directionIndex] * rotationSpeed);
    }
    private void Center()
    {
        float carAngle = car.transform.eulerAngles.z;
        if (carAngle > 180 && carAngle < 358) 
            car.transform.Rotate(Vector3.forward * rotationSpeed);
        else if(carAngle < 180 && carAngle > 2) 
            car.transform.Rotate(Vector3.forward * -rotationSpeed);
    }
}