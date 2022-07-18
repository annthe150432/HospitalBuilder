using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    private Tile tile = null;
    private ObjectFlyweight flyweight = null;
    public Tile Tile { get => tile; }
    private void Start()
    {
    }
    public ObjectFlyweight Flyweight { 
        get => flyweight;
        set
        {
            if (flyweight == null)
                flyweight = value;
        }
    }
    private void OnMouseDrag()
    {
        Camera.main.GetComponent<CameraManagement>().Dragable = false;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = worldPosition.x;
        float y = worldPosition.y;
        bool result = PlaceObject(x, y);
    }
    private void OnMouseUp()
    {
        Camera.main.GetComponent<CameraManagement>().Dragable = true;
    }
    private bool PlaceObject(float x, float y)
    {
        if (tile != null)
            GridSystem.Instance.ReturnTile(tile);
        bool placed = GridSystem.Instance.GetTile(x, y, out tile);
        if (!placed) return false;
        GridSystem.Instance.UseTile(tile);
        gameObject.transform.position = new Vector3(tile.X, tile.Y, 1);
        return true;
    }
}
