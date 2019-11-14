

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public static string tagit;
    private Transform _tr;
    public GameObject[] spawnPoints;
    public  GameObject currentPoint;
  
    public static ArrayList obj2 = new ArrayList { };
    int index;
    public static int len = 4;

    // Start is called before the first frame update
    void Awake()
    {

        //just to turn chair as they are 90 degrees not correct. we(designer) should fix this problem and we can delete it
        _tr = GetComponent<Transform>();
    }
    void Start()
    {
      
            foreach (GameObject go in spawnPoints)
            {
                print(go.name);
                print(obj2.Count + " count vs len " + len);
                if (!obj2.Contains(go.name) && (obj2.Count < len))
                {
                    print("I added an element of " + go.name);
                    obj2.Add(go.name);
                    print(obj2.Count);
                }
            }

            print("your parent is table");
        
    


        bool flag = false;
        while (flag != true)
        {   //here we choosing random object from given list
            index = Random.Range(0, spawnPoints.Length);
            currentPoint = spawnPoints[index];

            //  print(spawnPoints[i].ToString() + " is for " + spawnPoints[i]);

            for (int j = 0; j < obj2.Count; j++)
            //for (int j = 0; j < allobjects.Length; j++)

            {//we are going through the arraylist of all items, looking for one which is equal to one we picked randomly
                if (currentPoint.name == obj2[j].ToString())
                // if (currentPoint.name == allobjects[j].name)
                {
                    var stuff = Instantiate(currentPoint, _tr.position, _tr.rotation );
                    stuff.transform.parent = gameObject.transform;//put clone of obkects into the spawner
                    stuff.SetActive(true);

                    obj2.Remove(obj2[j].ToString());

                    flag = true;

                    return;

                }
                else
                {
                    index = Random.Range(0, spawnPoints.Length);// just for new cycle
                    currentPoint = spawnPoints[index];
                }
            }

        }




    }

    // Update is called once per frame
    void Update()
    {
       

    }

}
