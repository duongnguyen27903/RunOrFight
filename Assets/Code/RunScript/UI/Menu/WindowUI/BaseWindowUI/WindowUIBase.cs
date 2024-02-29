using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WindowUIBase : MonoBehaviour
{
    public virtual void Appear()
    {
        transform.gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        transform.gameObject.SetActive(false);
    }
}
