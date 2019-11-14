using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialControl : Singleton<MaterialControl>
{
    public Material test;
    public void NewMaterial(string where)
    {
        GameObject go = GameObject.Find(where + "(Clone)");
        if (go.TryGetComponent(out Renderer renderer))
        {
            for (int i = 0; i < renderer.materials.Length; i++)
            {
                print("----");
                Material m = renderer.materials[i];
                print(m.name);
                //Destroy(renderer.materials[i]);
                //renderer.materials[i] = 
            }
        }
        else {
            MeshRenderer[] ren = go.GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer r in ren)
            {
                for (int i = 0; i < r.materials.Length; i++)
                {
                    print("++++");
                    print(renderer.materials[i].name);
                    r.materials[i] = test;
                }
            }

        }
    }
}
