using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ObjectFlyweight
{
    public GameObject Prefab { get; set; }
    public string Name { get; set; }
    public ObjectFlyweight(GameObject prefab)
    {
        this.Prefab = prefab;
    }
}

