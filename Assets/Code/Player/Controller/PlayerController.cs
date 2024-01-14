using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //khai bao input cho player
    private PlayerInput Input;
    private float horizontal;
    private void OnEnable()
    {
        if( Input == null)
        {
            Input = new PlayerInput();

            Input.Player_Run.Jump.started += OnJump;
            Input.Player_Run.Jump.performed += OnJump;
            Input.Player_Run.Jump.canceled += OnJump;

            Input.Player_Run.Movement.started += OnMovement;
            Input.Player_Run.Movement.performed += OnMovement;
            Input.Player_Run.Movement.canceled += OnMovement;
            Input.Player_Run.Enable();
        }
    }
    private void OnDisable()
    {
        if (Input == null)
        {
            return;
        }
        Input.Disable();
    }
    private void OnMovement(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.performed || context.started)
        {
            horizontal = context.ReadValue<Vector2>().x;
            animatorController.PlayRunAnimation();
        }
        else if( context.canceled)
        {
            horizontal = 0f;
            int x = UnityEngine.Random.Range(1, 2);
            if( x == 1)
            {
                animatorController.PlayIdle1Animation();
            }
            else
            {
                animatorController.PlayIdle2Animation();
            }
        }
    }
    [SerializeField] private int JumpCount;
    private void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if( context.performed && (IsGrounded() || JumpCount<10))
        {
            rb.AddForce(new Vector2(rb.velocity.x, JumpForce), ForceMode2D.Impulse);
            JumpCount++;
        }
    }

    //khai bao check player neu dang dung tren mat dat
    [SerializeField] private Transform positionCheck;
    [SerializeField] private LayerMask groundCheck;

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(positionCheck.position, 0.2f, groundCheck);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(positionCheck.position, 0.2f);
    }

    //khai bao thuoc tinh cua nhan vat
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float JumpForce;
    //goi class dieu khien animation
    private AnimatorController animatorController;
    void Start()
    {
        animatorController = FindObjectOfType<AnimatorController>();
    }
    void Update()
    {
        if (transform.position.y < -15)
        {
            GameManager.instance.SetGameState(GameManager.GameState.GameOver);
            return;
        }
        if (IsGrounded()) JumpCount = 0;
        if( transform.position.x < -2)
        {
            rb.velocity = new Vector2( 0.5f, rb.velocity.y);
        }
        animatorController.PlayRunAnimation();
    }
}
