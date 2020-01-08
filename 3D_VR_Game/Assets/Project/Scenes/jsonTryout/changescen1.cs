using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescen1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            /*   GameObject go  =GameObject.Find("DontDestroyOnLoad");

                 for (int i = 0; i < go.transform.childCount; i++)
                 {
                     go.transform.GetChild(i).gameObject.SetActive(false);
                 }*/
           GameObject[] go= GetDontDestroyOnLoadObjects();
            foreach (GameObject g in go){ print(g.name);
                for (int i = 0; i < g.transform.childCount; i++)
                {
                   g.transform.GetChild(i).gameObject.SetActive(false);
                }
                //g.SetActive(false);
            }
     //       SceneManager.LoadScene("MainSceneAlex 1");
            
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
           
            SceneManager.LoadScene("zoo");

        }

    }
    public static GameObject[] GetDontDestroyOnLoadObjects()
    {
        GameObject temp = null;
        try
        {
            temp = new GameObject();
            Object.DontDestroyOnLoad(temp);
            UnityEngine.SceneManagement.Scene dontDestroyOnLoad = temp.scene;
            Object.DestroyImmediate(temp);
            temp = null;

            return dontDestroyOnLoad.GetRootGameObjects();
        }
        finally
        {
            if (temp != null)
                Object.DestroyImmediate(temp);
        }
    }
}

