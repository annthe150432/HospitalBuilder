using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    private Tile tile;
    private ObjectFlyweight flyweight;
    public BaseObject(Tile tile, ObjectFlyweight objectFlyweight)
    {
        this.tile = tile;
        this.flyweight = objectFlyweight;
    }
    public Tile Tile { get => tile; }
    public ObjectFlyweight Flyweight { get => flyweight; }
    public bool PlaceObject(float x, float y)
    {
        GridSystem.Instance.GetTile(x, y, out tile);
        if (tile == null) return false;
        return true;
    }
}
