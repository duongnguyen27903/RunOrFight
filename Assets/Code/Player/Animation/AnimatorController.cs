using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    //khai bao animator cho nhan vat
    [SerializeField] private Animator animator;
    private int ChangeHash;
    private int StateHash;

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
    void Start()
    {
        ChangeHash = Animator.StringToHash("Change");
        StateHash = Animator.StringToHash("State");
    }
}
