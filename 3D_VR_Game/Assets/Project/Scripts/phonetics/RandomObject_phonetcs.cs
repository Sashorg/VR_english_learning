

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject_phonetcs : MonoBehaviour
{
    private Transform _tr;
    public GameObject[] spawnPoint;
    int index;
    int goindex;
    public static ArrayList floor = new ArrayList { };
    private GameObject child;
    public List<int> usedValues = new List<int>();
    public List<int> usedValues2 = new List<int>();
    public ArrayList objects = new ArrayList { };
    public int count=0;
    public int count_go ;
    public int spw_counter;
    string test;
    string delete_name;
    void Awake()
    {

        //just to turn chair as they are 90 degrees not correct. we(designer) should fix this problem and we can delete it
        _tr = GetComponent<Transform>();
    }
    void Start()
    {
        for (spw_counter = 0; spw_counter < spawnPoint.Length; spw_counter++) {
            objects.Add(spawnPoint[spw_counter].name);
           
        }
        for (count_go=0; count_go < transform.childCount;count_go++)
        {
            
            goindex = UniqueRandomInt(0, objects.Count);
            if (count == transform.childCount)
                {
                usedValues.Clear();
                usedValues2.Clear();
                return;
                }
            if (count_go == objects.Count)
            {
                usedValues.Clear();
                usedValues2.Clear();
                return;
            }
         

               index = UniqueRandomInt2(0, transform.childCount);
                
                   child = transform.GetChild(index).gameObject;
                  




            // child.tag = go.name;
                   test = objects[goindex].ToString();
            foreach (GameObject g in spawnPoint)
            {
                if (g.name == test)
                {
                    print(g.name);
                    print(test);
                    child = g;
                }
                else {
                    print(g.name);
                    print(test);
                }
            }
           
                   
                   GameObject lol = Instantiate(child, this.gameObject.transform.GetChild(index).transform.position, this.gameObject.transform.GetChild(index).transform.rotation);




                   lol.transform.parent = this.gameObject.transform.GetChild(index);
              
            count++;
               
                print(child.ToString());
                print(count);
            print(count_go);
            print(spawnPoint.Length);




        }
        usedValues.Clear();
        usedValues2.Clear();
        count = 0;


        
    }
        // Update is called once per frame
        void Update()
        {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            bad();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            good();
        }
    }
        public static void deleteObjects(string s)
        {
            print(s);
            //    SpriteControl.Instance.NewSprite(s,"banana");
            GameObject.Find(s+"(Clone)").transform.parent.gameObject.SetActive(false);



        }
    public int UniqueRandomInt(int min, int max)
    {
        int val = Random.Range(min, max);
        while (usedValues.Contains(val))
        {
            val = Random.Range(min, max);
        }
       
        usedValues.Add(val);
        print("List is "+usedValues.Count);
            print(val);
        return val;
        
    }
    public int UniqueRandomInt2(int min, int max)
    {
        int val = Random.Range(min, max);
        while (usedValues2.Contains(val))
        {
            val = Random.Range(min, max);
        }

        usedValues2.Add(val);
        print("List2 is " + usedValues2.Count);
        print(val);
        return val;

    }

    public void good() {
        delete_name = GameObject.FindGameObjectWithTag("point").name;
        delete_name = delete_name.Replace("(Clone)","");
        objects.Remove(delete_name);
        print(objects.Count);
        Destroy(GameObject.FindGameObjectWithTag("point"));
        if (objects.Count != 0)
        {
            for (count_go = 0; count_go < transform.childCount; count_go++)
            {
                print("child " + transform.childCount);
                goindex = UniqueRandomInt(0, objects.Count);
                if (count == transform.childCount)
                {
                    print("wow");
                    usedValues.Clear();
                    usedValues2.Clear();
                    return;
                }
                if (count_go == objects.Count)
                {
                    print("wow2");
                    usedValues.Clear();
                    usedValues2.Clear();
                    return;
                }


                index = UniqueRandomInt2(0, transform.childCount);

                child = transform.GetChild(index).gameObject;





                // child.tag = go.name;
                test = objects[goindex].ToString();
                foreach (GameObject g in spawnPoint)
                {
                    if (g.name == test)
                    {
                        print(g.name);
                        print(test);
                        child = g;
                    }
                    else
                    {
                        print(g.name);
                        print(test);
                    }
                }


                GameObject lol = Instantiate(child, this.gameObject.transform.GetChild(index).transform.position, this.gameObject.transform.GetChild(index).transform.rotation);




                lol.transform.parent = this.gameObject.transform.GetChild(index);

                count++;

                print(child.ToString());
                print(count);
                print(count_go);
                print(spawnPoint.Length);




            }
        }
        else { print("Congrats, you finished"); }
        usedValues.Clear();
        usedValues2.Clear();
        count = 0;




    }
    public void bad() {
        delete_name = GameObject.FindGameObjectWithTag("point").name;
        print("OOOOOOOOO"+delete_name);
        delete_name=  delete_name.Replace("(Clone)", "");
        print("OOOOOOOOO" + delete_name);
        print(objects[1].ToString());
        print(objects[0].ToString());
        objects.Remove(delete_name);
        Destroy(GameObject.FindGameObjectWithTag("point"));
        for (count_go = 0; count_go < transform.childCount; count_go++)
        {
            print("child "+transform.childCount);
            goindex = UniqueRandomInt(0, objects.Count);
            if (count == transform.childCount)
            {
                print("wow");
                usedValues.Clear();
                usedValues2.Clear();
                return;
            }
            if (count_go == objects.Count)
            {
                print("wow2");
                usedValues.Clear();
                usedValues2.Clear();
                return;
            }


            index = UniqueRandomInt2(0, transform.childCount);

            child = transform.GetChild(index).gameObject;





            // child.tag = go.name;
            test = objects[goindex].ToString();
            foreach (GameObject g in spawnPoint)
            {
                if (g.name == test)
                {
                    print(g.name);
                    print(test);
                    child = g;
                }
                else
                {
                    print(g.name);
                    print(test);
                }
            }


            GameObject lol = Instantiate(child, this.gameObject.transform.GetChild(index).transform.position, this.gameObject.transform.GetChild(index).transform.rotation);




            lol.transform.parent = this.gameObject.transform.GetChild(index);

            count++;

            print(child.ToString());
            print(count);
            print(count_go);
            print(spawnPoint.Length);




        }
        objects.Add(delete_name);
        usedValues.Clear();
        usedValues2.Clear();
        count = 0;



    }

}

