using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public float initialDrag = 2;
    public VariableJoystick variableJoystick;
    public Rigidbody2D rb;



    public void FixedUpdate()
    {
            rb.drag = initialDrag;
            Vector2 direction = Vector2.up * variableJoystick.Vertical + Vector2.right * variableJoystick.Horizontal;
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode2D.Impulse); 
    }
}