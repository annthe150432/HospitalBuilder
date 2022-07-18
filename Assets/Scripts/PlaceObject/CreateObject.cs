using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateObject : MonoBehaviour
{
    public void GenerateObject(string Name)
    {
        ObjectFactory.Instance.CreateObject(Name);
    }
}
