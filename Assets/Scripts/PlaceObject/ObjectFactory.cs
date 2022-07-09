using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory
{
    List<ObjectFlyweight> flyweights;

    private static object locker = new object();
    private static ObjectFactory _instance = null;
    private ObjectFactory()
    {
        flyweights = new List<ObjectFlyweight>();
    }
    public ObjectFactory Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (locker)
                {
                    _instance = new ObjectFactory();
                }
            }
            return _instance;
        }
    }
    public BaseObject CreateObject(float x, float y)
    {
        ObjectFlyweight flyweight = GetObjectFlyweight();
        GridSystem.Instance.GetTile(x, y, out Tile tile);
        BaseObject baseObject = new BaseObject(tile, flyweight);
        return baseObject;
    }
    private ObjectFlyweight GetObjectFlyweight()
    {

        return null;
    }
}
