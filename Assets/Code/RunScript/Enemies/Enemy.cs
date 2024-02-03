using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Base
{
    [SerializeField] protected Animator animator;
    protected int ChangeHash;
    protected int StateHash;
    protected virtual void AssignAnimation()
    {
        ChangeHash = Animator.StringToHash("Change");
        StateHash = Animator.StringToHash("State");
    }
    [ContextMenu("PlayIdle1Animation")]
    public void PlayIdle1Animation()
    {
        animator.SetTrigger(ChangeHash);
        animator.SetInteger(StateHash, 1);
    }
    [ContextMenu("PlayRunAnimation")]
    public void PlayRunAnimation()
    {
        animator.SetTrigger(ChangeHash);
        animator.SetInteger(StateHash, 2);
    }
    protected override void LoadComponents()
    {
        
    }
}
