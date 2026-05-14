using System.Collections;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    public float acceleration = 10;
    public float stoppingForce = 10;
    public float maxSpeedX = 10;
    public float stoppingPoint = 0.1f;
    public float jumpForce = 7;
    public float dashForce = 10;
    private Rigidbody2D rb;
    private bool _canJump = true;
    private bool _canDash = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        //accelerate if pressing button
        if (direction.x != 0)
        {
            rb.AddForce(new Vector2(direction.x * acceleration, 0));
        }
        //if not accelerating start slowing down
        else if (rb.linearVelocityX != 0)
        {
            //if almost stopped, force stop
            if (rb.linearVelocityX < stoppingPoint && rb.linearVelocityX > -stoppingPoint)
            {
                rb.linearVelocity = new Vector2(0.0f, rb.linearVelocityY);
            }
            //add stopping force
            else
            {
                rb.AddForce(new Vector2(-rb.linearVelocityX * stoppingForce, 0));
            }
        }

        if (!_canDash) 
        {
            return;
        } 
        //Limit max speed
        if (rb.linearVelocityX >= maxSpeedX)
        {
            rb.linearVelocityX = maxSpeedX;
        }
        else if (rb.linearVelocityX <= -maxSpeedX)
        {
            rb.linearVelocityX = -maxSpeedX;
        }
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (_canJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _canJump = false;
        }
    }

    private void OnDash() 
    {
        //Debug.Log("Dashing");
        if (_canDash) 
        {
            if (direction.x != 0)
            {
                rb.AddForce(new Vector2(direction.x * dashForce, 0), ForceMode2D.Impulse);
            }
            else 
            {
                rb.AddForce(new Vector2(dashForce, 0), ForceMode2D.Impulse);
            }
                _canDash = false;
            StartCoroutine(ResetDash(1));
        }

        
    }
    IEnumerator ResetDash(float cooldown) 
    {
        yield return new WaitForSeconds(cooldown);
        _canDash = true;
    
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        _canJump = true;
    }

    
}
