using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //khai bao animator cho nhan vat
    [SerializeField] private Animator animator;
    private int ChangeHash;
    private int StateHash;

    //cac ham chay animation cua nhan vat
    [ContextMenu("PlayIdleAnimation")]
    private void PlayIdleAnimation()
    {
        animator.SetTrigger(ChangeHash);
        animator.SetInteger(StateHash,0);
    }
    [ContextMenu("PlayWalkAnimation")]
    private void PlayWalkAnimation()
    {
        animator.SetTrigger(ChangeHash);
        animator.SetInteger(StateHash,1);
    }

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
            Input.Enable();
        }
    }
    private void OnDisable()
    {
        if( Input != null)
        {
            Input.Disable();
        }
    }
    private void OnMovement(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.performed || context.started)
        {
            horizontal = context.ReadValue<Vector2>().x;
            PlayWalkAnimation();
        }
        else if( context.canceled)
        {
            horizontal = 0f;
            PlayIdleAnimation();

        }
    }
    private void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if( context.performed && IsGrounded())
        {
            rb.AddForce(new Vector2(rb.velocity.x, JumpForce), ForceMode2D.Impulse);
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
    void Start()
    {
        ChangeHash = Animator.StringToHash("Change");
        StateHash = Animator.StringToHash("State");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2( MoveSpeed * horizontal, rb.velocity.y);
    }

    public Vector3 GetPlayerPosition()
    {
        return gameObject.transform.position;
    }
}
