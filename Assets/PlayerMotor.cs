using System.Collections;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

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
    private Animator _animator;
    private bool _canJump = true;
    private bool _canDash = true;
    private float _initScale;

    public int maxJump = 2;
    private int currentJumps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _initScale = transform.localScale.x;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        _animator.SetFloat("SpeedY", rb.linearVelocity.y);
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(_initScale, transform.localScale.y, transform.localScale.z);

        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-_initScale, transform.localScale.y, transform.localScale.z);
        }


        //accelerate if pressing button
        if (direction.x != 0)
        {
            rb.AddForce(new Vector2(direction.x * acceleration, 0));
            _animator.SetBool("IsMoving", true);
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

        if (direction.x == 0) 
        {
            _animator.SetBool("IsMoving", false);
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
            currentJumps++;

            if (currentJumps >= maxJump) 
            {

                _canJump = false;
            }
            
            //if (meow) then (meow);
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
        currentJumps = 0;
        
    }

    
}
