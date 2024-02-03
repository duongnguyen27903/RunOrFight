using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowUIBase : MonoBehaviour
{
    //[SerializeField] protected bool show = false;
    [SerializeField] protected Vector3 startPos;
    //[SerializeField] protected Vector3 endPos;
    //[SerializeField] protected float moveSpeed;

    //protected virtual void Update()
    //{
    //    Showing();
    //}
    
    protected virtual void SetStartPos()
    {
        transform.localPosition = startPos;
    }

    public virtual void Appear()
    {
        //SetStartPos();
        //show = true;
        transform.localPosition = startPos;
        transform.gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        //show = false;
        transform.gameObject.SetActive(false);
    }

    //private void Showing()
    //{
    //    if ( show )
    //    transform.localPosition = Vector3.Lerp(transform.localPosition, endPos, moveSpeed * Time.deltaTime);
    //}
}
