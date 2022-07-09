using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    private bool inUse;
    private float x;
    private float y;
    public Tile(float x, float y)
    {
        this.x = x;
        this.y = y;
        inUse = false;
    }
    public float X { get => x; }
    public float Y { get => y; }
    public bool InUse { get => inUse; }
    public void UseTile()
    {
        inUse = true;
    }
    public void UnuseTile()
    {
        inUse = false;
    }
}
