using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ObjectFlyweight
{
    private GameObject prefab;
    private string name;
    public GameObject Prefab { get => prefab; }
    public string Name { get => name; }
    public ObjectFlyweight(GameObject prefab)
    {
        this.prefab = prefab;
        this.name = prefab.name;
    }
}

