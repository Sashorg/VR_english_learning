
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Remove
{


    public static void RemoveComponent<Component>(this GameObject go)
    {
        Component component = go.GetComponent<Component>();

        if (component != null)
        {
            Object.DestroyImmediate(component as Object, true);

        }
    }

}
