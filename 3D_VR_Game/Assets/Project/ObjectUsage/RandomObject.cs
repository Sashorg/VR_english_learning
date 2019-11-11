

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject : MonoBehaviour
{
    private Transform _tr;
    public GameObject[] spawnPoint;
    int index;
    public static ArrayList floor = new ArrayList { };
    private GameObject child;
    public List<int> usedValues = new List<int>();
    public int count=0;


    void Awake()
    {

        //just to turn chair as they are 90 degrees not correct. we(designer) should fix this problem and we can delete it
        _tr = GetComponent<Transform>();
    }
    void Start()
    {
     
      
            foreach (GameObject go in spawnPoint) {
                if (count == transform.childCount  ) {
                    print(count);
                    return; 
                }

               index= UniqueRandomInt(0, transform.childCount);
                print("index is " + index);
                    child = transform.GetChild(index).gameObject;
                    print(child.name);
                    
                        
                        
                print(child.ToString());
            if (child.name == "right") {
                child.transform.Rotate(0f,90f,0f);
            }
            if (child.name == "down")
            {
                child.transform.Rotate(0f, 180f, 0f);
            }
            child.tag = go.name;
                child = go;
                
               GameObject lol=  Instantiate(child, this.gameObject.transform.GetChild(index).transform.position, this.gameObject.transform.GetChild(index).transform.rotation);
            if (lol.name == "door(Clone)") {
                lol.transform.Rotate(-90f,90f,0f);
            }
            if (lol.name == "bed(Clone)")
            {
                lol.transform.Rotate(-90f, 180f, 0f);
            }
            if (lol.name == "closet(Clone)")
            {
                lol.transform.Rotate(0f, -90f, 0f);
            }

            lol.transform.parent = this.gameObject.transform.GetChild(index);
                count++;
                print(child.ToString());
                print(count);


            }




        
    }
        // Update is called once per frame
        void Update()
        {


        }
        public static void deleteObjects(string s)
        {
            print(s);
            //    SpriteControl.Instance.NewSprite(s,"banana");
            GameObject.FindWithTag(s).SetActive(false);



        }
    public int UniqueRandomInt(int min, int max)
    {
        int val = Random.Range(min, max);
        while (usedValues.Contains(val))
        {
            val = Random.Range(min, max);
        }
        usedValues.Add(val);
        print(val);
        return val;
        
    }

}

