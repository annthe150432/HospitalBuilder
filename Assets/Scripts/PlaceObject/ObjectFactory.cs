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
    public static ObjectFactory Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (locker)
                {
                    _instance = new ObjectFactory();
                    _instance.Objects = new List<BaseObject>();
                }
            }
            return _instance;
        }
    }
    public List<BaseObject> Objects { get; set; }
    public void CreateObject(string name)
    {
        ObjectFlyweight flyweight = GetObjectFlyweight(name);
        Tile tile = null;
        bool placeable = GridSystem.Instance.GetTile(flyweight.Prefab.transform.position.x, flyweight.Prefab.transform.position.y, out tile);
        if (!placeable) return;
        if (tile.InUse) return;
        GameObject gameObject = GameObject.Instantiate(flyweight.Prefab);
        if (flyweight.Prefab.tag == "FunctionalObject")
        {
            FuntionalObject funcObj = gameObject.AddComponent<FuntionalObject>();
            funcObj.Flyweight = flyweight;
            funcObj.PlaceObject(flyweight.Prefab.transform.position.x, flyweight.Prefab.transform.position.y);
            Objects.Add(funcObj);
        }
        else if (flyweight.Prefab.tag == "DecorationObject")
        {
            DecorationObject decorObj = gameObject.AddComponent<DecorationObject>();
            decorObj.Flyweight = flyweight;
            decorObj.PlaceObject(flyweight.Prefab.transform.position.x, flyweight.Prefab.transform.position.y);
            Objects.Add(decorObj);
        }
    }
    public FuntionalObject GetAvailableObject(string name)
    {
        FuntionalObject funcObj = (FuntionalObject)Objects.Find(o => o is FuntionalObject && o.Flyweight.Name == name && ((FuntionalObject)o).AvailableState == true);
        return funcObj;
    }
    private ObjectFlyweight GetObjectFlyweight(string name)
    {
        ObjectFlyweight flyweight = flyweights.Find(f => f.Name == name);
        if (flyweight == null)
        {
            flyweight = new ObjectFlyweight(Resources.Load<GameObject>("Prefabs/" + name));
            flyweights.Add(flyweight);
        }
        return flyweight;
    }
}
