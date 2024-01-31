using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    public virtual void LoadComponents()
    {
        //for override
    }
}
