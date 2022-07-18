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
                }
            }
            return _instance;
        }
    }
    public void CreateObject(string name)
    {
        ObjectFlyweight flyweight = GetObjectFlyweight(name);
        GameObject gameObject = GameObject.Instantiate(flyweight.Prefab);
        BaseObject bo = gameObject.AddComponent<BaseObject>();
        bo.Flyweight = flyweight;
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
