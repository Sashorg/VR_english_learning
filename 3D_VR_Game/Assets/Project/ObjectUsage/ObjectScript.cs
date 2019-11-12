

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public static string tagit;
    private Transform _tr;
    public GameObject[] spawnPoints;
    public  GameObject currentPoint;
    public static ArrayList floor = new ArrayList { };
    public static ArrayList obj2 = new ArrayList { };
    int index;
    public static int len = 4;
    public static int len2 = 2;
    // Start is called before the first frame update
    void Awake()
    {

        //just to turn chair as they are 90 degrees not correct. we(designer) should fix this problem and we can delete it
        _tr = GetComponent<Transform>();
    }
    void Start()
    {
        if (transform.parent.name == "table")
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
        }
        else if (transform.parent.name == "floor")
        {
            foreach (GameObject go in spawnPoints)
            {
                print(go.name);
                print(floor.Count + " count vs len " + len2);
                if (!floor.Contains(go.name) && (floor.Count < len2))
                {
                    print("I added an element of " + go.name);
                    floor.Add(go.name);
                    print(floor.Count);
                }
            }

            print("your parent is table");
        }



        if (obj2.Count == len)
        {
            len--;
            randomchose(obj2);
            //bool is needed as we do not need to stop , unless we did not inizialize object. this is needed due to randomness

            // print("Player word is "+ ExampleObj.tryout);
        }
        if (floor.Count == len2)
        {
            len2--;
            randomchose(floor);
            //bool is needed as we do not need to stop , unless we did not inizialize object. this is needed due to randomness

            // print("Player word is "+ ExampleObj.tryout);
        }

    }

    // Update is called once per frame
    void Update()
    {
       

    }
    public static void deleteObject(string s)
    {
        print(s);
    //    SpriteControl.Instance.NewSprite(s,"banana");
     //  GameObject.FindWithTag(s).SetActive(false);
        GameObject.Find(s + "(Clone)").SetActive(false);


    }
    public void randomchose(ArrayList arrayList) {
        bool flag = false;
        while (flag != true)
        {   //here we choosing random object from given list
            index = Random.Range(0, spawnPoints.Length);
            currentPoint = spawnPoints[index];

            //  print(spawnPoints[i].ToString() + " is for " + spawnPoints[i]);

            for (int j = 0; j < arrayList.Count; j++)
            //for (int j = 0; j < allobjects.Length; j++)

            {//we are going through the arraylist of all items, looking for one which is equal to one we picked randomly
                if (currentPoint.name == arrayList[j].ToString())
                // if (currentPoint.name == allobjects[j].name)
                {
                    var stuff = Instantiate(currentPoint, _tr.position, _tr.rotation * Quaternion.Euler(-90f, 0f, 0f));
                    stuff.transform.parent = gameObject.transform;//put clone of obkects into the spawner
                    stuff.SetActive(true);
                    this.gameObject.tag = currentPoint.name;//change tag 
                    tagit = gameObject.tag;

                    print("Your tag is " + gameObject.tag);
                    print("I removed " + arrayList[j].ToString());
                    arrayList.Remove(arrayList[j].ToString());
                    print("your legnth is " + arrayList.Count);
                    // randomPick.deleteObj(randomPick.obj[j].ToString());// delete this value from list of scene objects(no duplicate)

                    flag = true;
                    //  print(tag);

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
}
