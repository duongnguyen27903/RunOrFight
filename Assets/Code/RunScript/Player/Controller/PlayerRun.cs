using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : Player
{
    private void OnEnable()
    {
        if( Input == null)
        InitJumpInput();
    }
    private void OnDisable()
    {
        DisableInput();
    }
    [SerializeField] private int JumpCount;
    public override void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.performed && (IsGrounded() || JumpCount < 10))
        {
            rb.AddForce(new Vector2(rb.velocity.x, JumpForce), ForceMode2D.Impulse);
            JumpCount++;
        }
    }

    //cac ham kiem soat suc manh nhan vat
    public Action<Power> onChangePower;
    public void ActiveFire()
    {
        Set_Power(Power.fire);
        onChangePower(Power.fire);
    }
    public void ActiveIce()
    {
        Set_Power(Power.ice);
        onChangePower(Power.ice);
    }
    public Power Get_Player_Power()
    {
        return current_power;
    }

    //cac ham xu ly va cham
    private void OnParticleCollision(GameObject other)
    {
        if( current_power != Power.fire)
        {
            GameManager.Instance.SetGameState(GameManager.GameState.GameOver);
            return;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftSideCollider"))
        {
            GameManager.Instance.SetGameState(GameManager.GameState.GameOver);
            return;
        }
        if (  collision.gameObject.CompareTag("IceObstacle") ) 
        {
            if( current_power == Power.fire )
            {
                collision.gameObject.SetActive(false);
                GameObject power_burst = PowerBurstPool.Instance.Get_New_FireBurst();
                power_burst.transform.position = transform.position;
                power_burst.SetActive(true);
            }
        }
    }

    void Start()
    {
        Set_Power(Power.normal);
        onChangePower(Power.normal);
        ChangeHash = Animator.StringToHash("Change");
        StateHash = Animator.StringToHash("State");
    }
    void Update()
    {
        if (transform.position.y < -10)
        {
            GameManager.Instance.SetGameState(GameManager.GameState.GameOver);
            return;
        }
        if (IsGrounded()) JumpCount = 0;
        if (transform.position.x < -2)
        {
            rb.velocity = new Vector2(2f, rb.velocity.y);
        }
        PlayRunAnimation();
    }
}
