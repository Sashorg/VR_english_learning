using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nomagic : MonoBehaviour
{
    private Transform _tr;
    public GameObject[] spawnPoint;
    int index;
    int goindex;
    
    private GameObject child;
    public List<int> usedValues = new List<int>();
    public List<int> usedValues2 = new List<int>();

    public int count = 0;
    public int count_go;


    void Awake()
    {

        //just to turn chair as they are 90 degrees not correct. we(designer) should fix this problem and we can delete it
        _tr = GetComponent<Transform>();
    }
    void Start()
    {

        for (count_go = 0; count_go < transform.childCount; count_go++)
        {
            print("NOOOO" + count_go);
            goindex = UniqueRandomInt(0, spawnPoint.Length);
            if (count == transform.childCount)
            {
                print(count);
                return;
            }
            if (count_go == spawnPoint.Length)
            {
                print(goindex);
                return;
            }
            print("num of childer is " + transform.childCount);

            index = UniqueRandomInt2(0, transform.childCount);
            print("index is " + index);
            child = transform.GetChild(index).gameObject;
            print(child.name);



            print(child.ToString());
            if (child.tag == "right_wall")
            {
                child.transform.Rotate(0f, 90f, 0f);
            }
            if (child.tag == "left_wall")
            {
                child.transform.Rotate(0f, -90f, 0f);
            }
            if (child.tag == "down_wall")
            {
                child.transform.Rotate(0f, 180f, 0f);
            }
            // child.tag = go.name;
            child = spawnPoint[goindex];

            GameObject lol = Instantiate(child, this.gameObject.transform.GetChild(index).transform.position, this.gameObject.transform.GetChild(index).transform.rotation);




            lol.transform.parent = this.gameObject.transform.GetChild(index);

            count++;

            print(child.ToString());
            print(count);
            print(count_go);
            print(spawnPoint.Length);




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
        GameObject.Find(s + "(Clone)").transform.parent.gameObject.SetActive(false);



    }
    public int UniqueRandomInt(int min, int max)
    {
        int val = Random.Range(min, max);
        while (usedValues.Contains(val))
        {
            val = Random.Range(min, max);
        }

        usedValues.Add(val);
        print("List is " + usedValues.Count);
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
}
