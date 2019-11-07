

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public static string tagit;
    private Transform _tr;
    public GameObject[] allobjects,spawnPoints;
    public  GameObject currentPoint;
    public static ArrayList obj2= new ArrayList { };
    int index;
    public static int len=4;
    // Start is called before the first frame update
    void Awake()
    {

        //just to turn chair as they are 90 degrees not correct. we(designer) should fix this problem and we can delete it
        _tr = GetComponent<Transform>();
    }
    void Start()
    {
        foreach (GameObject go in allobjects)
        {
            if (!obj2.Contains(go.name)&&(obj2.Count<len))
            {
                print("I added an element of " + go.name);
                obj2.Add(go.name);
                print(obj2.Count);
            }
        }



        if (obj2.Count == len)
        {
            len--;
            //bool is needed as we do not need to stop , unless we did not inizialize object. this is needed due to randomness
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
                        var stuff = Instantiate(currentPoint, _tr.position, _tr.rotation * Quaternion.Euler(-90f, 0f, 0f));
                        stuff.transform.parent = gameObject.transform;//put clone of obkects into the spawner
                        stuff.SetActive(true);
                        this.gameObject.tag = currentPoint.name;//change tag 
                        tagit = gameObject.tag;

                        print("Your tag is " + gameObject.tag);
                        print("I removed " + obj2[j].ToString());
                        obj2.Remove(obj2[j].ToString());
                        print("your legnth is " + obj2.Count);
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
       GameObject.FindWithTag(s).SetActive(false);
       


    }
}
