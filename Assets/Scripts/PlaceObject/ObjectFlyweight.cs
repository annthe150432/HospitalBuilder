using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ObjectFlyweight : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    public ObjectFlyweight(GameObject prefab)
    {
        this.prefab = prefab;
    }
    public bool RemoveObject()
    {
        Destroy(gameObject);
        return true;
    }
}

