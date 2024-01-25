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
        //onChangePower(Power.fire);
    }
    public void ActiveIce()
    {
        Set_Power(Power.ice);
        //onChangePower(Power.ice);
    }
    public Power Get_Player_Power()
    {
        return current_power;
    }
    void Start()
    {
        Set_Power(Power.normal);
        ChangeHash = Animator.StringToHash("Change");
        StateHash = Animator.StringToHash("State");
    }
    void Update()
    {
        if (transform.position.y < -10)
        {
            GameManager.instance.SetGameState(GameManager.GameState.GameOver);
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
