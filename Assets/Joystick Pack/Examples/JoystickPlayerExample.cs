using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public float initialDrag = 2;
    public float grassDrag = 10;
    public VariableJoystick variableJoystick;
    public Rigidbody2D rb;
    public GameObject car;
    public SpriteRenderer carRenderer;
    public GameObject boostParticles;
    public SoundManager soundManager;
    public float initialDrunkTimer;
    private float drunkTimer;
    public bool isDrunk;
    public bool onGrass;

    private void Start()
    {
        isDrunk = false;
        onGrass = false;
    }

    public void FixedUpdate()
    {
        if (variableJoystick.Vertical == 0)
        {
            if (variableJoystick.Horizontal == 0) Center();
            boostParticles.SetActive(false);
            if (onGrass)
            {
                Vector2 dragDown = Vector2.down * grassDrag;
                rb.AddForce(dragDown, ForceMode2D.Impulse);
            }
        }
        else
        {
            if (variableJoystick.Vertical > 0.1 && variableJoystick.Horizontal < 0.1 && variableJoystick.Horizontal > -0.1) Center();
            else if (variableJoystick.Horizontal > 0) RotateRight();
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

            if (onGrass)
            {
                Vector2 dragDown = Vector2.down * grassDrag;
                rb.AddForce(dragDown, ForceMode2D.Impulse);
            }

            rb.drag = initialDrag;

            if (isDrunk && drunkTimer > 0)
            {
                drunkTimer -= Time.fixedDeltaTime;
                if (drunkTimer <= 0)
                {
                    isDrunk = false;
                    carRenderer.flipY = false;
                }
            }
            Vector2 direction = Vector2.up * variableJoystick.Vertical + Vector2.right * variableJoystick.Horizontal;
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }

    internal void dragOnAsphalt()
    {
        onGrass = false;
    }

    internal void increaseDragOnGrass()
    {
        onGrass = true;
    }

    internal void ReverseControls()
    {
        drunkTimer = initialDrunkTimer;
        isDrunk = true;
        carRenderer.flipY = true;
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