using UnityEngine;

public class Player : MonoBehaviour
{
    //khai bao animator cho nhan vat
    [SerializeField] protected Animator animator;
    [SerializeField] protected int ChangeHash;
    [SerializeField] protected int StateHash;

    //cac ham chay animation cua nhan vat
    [ContextMenu("PlayIdle1Animation")]
    public void PlayIdle1Animation()
    {
        animator.SetTrigger(ChangeHash);
        animator.SetInteger(StateHash, 1);
    }
    [ContextMenu("PlayIdle2Animation")]
    public void PlayIdle2Animation()
    {
        animator.SetTrigger(ChangeHash);
        animator.SetInteger(StateHash, 2);
    }
    [ContextMenu("PlayRunAnimation")]
    public void PlayRunAnimation()
    {
        animator.SetTrigger(ChangeHash);
        animator.SetInteger(StateHash, 3);
    }
    [ContextMenu("PlayJumpAnimation")]
    public void PlayJumpAnimation()
    {
        animator.SetTrigger(ChangeHash);
        animator.SetInteger(StateHash, 4);
    }

    //khai bao input cho player
    protected PlayerInput Input;
    //ham khoi tao input cho player
    public void InitJumpInput()
    {
        Input = new PlayerInput();
        Input.Player_Run.Jump.started += OnJump;
        Input.Player_Run.Jump.performed += OnJump;
        Input.Player_Run.Jump.canceled += OnJump;
        Input.Player_Run.Jump.Enable();
    }
    // khai bao mot ham de disable input
    public void DisableInput()
    {
        if (Input == null)
        {
            return;
        }
        Input.Disable();
    }

    //khai bao check player neu dang dung tren mat dat
    [SerializeField] protected Transform positionCheck;
    [SerializeField] protected LayerMask groundCheck;
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(positionCheck.position, 0.2f, groundCheck);
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(positionCheck.position, 0.2f);
    }

    //khai bao thuoc tinh cua nhan vat
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float JumpForce;
    //ham nay dung de khai bao mot ham override nen de trong
    public virtual void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext context) { }

    //khai bao cac thuoc tinh suc manh cua nhan vat
    public enum Power
    {
        normal, fire, ice
    }
    [SerializeField] private GameObject Fire;
    [SerializeField] private GameObject Ice;
    protected Power current_power;
    public void Set_Power( Power power)
    {
        current_power = power;
        Fire.SetActive(current_power == Power.fire);
        Ice.SetActive(current_power == Power.ice);
    }
}
