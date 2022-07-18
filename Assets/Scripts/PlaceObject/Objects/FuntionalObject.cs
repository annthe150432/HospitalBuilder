using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuntionalObject : BaseObject
{
    private bool availableState = true;
    public bool AvailableState { get => availableState; }
    public void SetInUse()
    {
        availableState = false;
    }
    public void SetUnUse()
    {
        availableState = true;
    }
}
