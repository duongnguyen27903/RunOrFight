using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowUIBase : MonoBehaviour
{
    [Header("WindowUI")]
    [SerializeField] protected bool show = false;
    [SerializeField] protected Vector3 startPos;
    [SerializeField] protected Vector3 endPos;
    [SerializeField] protected float moveSpeed;

    private void FixedUpdate()
    {
        this.Showing();
    }

    protected virtual void SetStartPos()
    {
        transform.localPosition = this.startPos;
    }

    public virtual void Appear()
    {
        this.SetStartPos();
        this.show = true;
        transform.gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        this.show = false;
        transform.gameObject.SetActive(false);
    }

    private void Showing()
    {
        if (!this.show) return;
        transform.localPosition = Vector3.Lerp(transform.localPosition, this.endPos, this.moveSpeed * Time.fixedDeltaTime);
    }
}
