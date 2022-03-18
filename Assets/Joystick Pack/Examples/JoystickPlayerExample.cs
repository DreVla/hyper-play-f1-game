using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public float initialDrag;
    public VariableJoystick variableJoystick;
    public Rigidbody2D rb;

    private void Start()
    {
        initialDrag = rb.drag;
    }

    public void FixedUpdate()
    {
        if (variableJoystick.Vertical == 0 && variableJoystick.Horizontal == 0)
        {
            rb.drag += Time.fixedDeltaTime;
        }
        else
        {
            rb.drag = initialDrag;
            Vector2 direction = Vector2.up * variableJoystick.Vertical + Vector2.right * variableJoystick.Horizontal;
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }
}