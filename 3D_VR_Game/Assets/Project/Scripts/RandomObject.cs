

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject : MonoBehaviour
{
    private Transform _tr;
    public GameObject[] spawnPoint;
    int index;
    int goindex;
    public static ArrayList floor = new ArrayList { };
    private GameObject child;
    public List<int> usedValues = new List<int>();
    public List<int> usedValues2 = new List<int>();

    public int count=0;
    public int count_go ;


    void Awake()
    {

        //just to turn chair as they are 90 degrees not correct. we(designer) should fix this problem and we can delete it
        _tr = GetComponent<Transform>();
    }
    void Start()
    {
        spawnPoint = reshuffle_go(spawnPoint);
       //shuffle list , instanciate prefab from code

               
                   child = transform.Find("child").gameObject;
                   print(child.name);



                   print(child.ToString());
                  
                   // child.tag = go.name;
                   child = spawnPoint[0];

                   GameObject lol = Instantiate(child, this.gameObject.transform.GetChild(index).transform.position, this.gameObject.transform.GetChild(index).transform.rotation);
        lol.transform.parent = gameObject.transform;



                   lol.transform.parent = this.gameObject.transform.GetChild(index);
              
            
               
           




     



    }
        // Update is called once per frame
        void Update()
        {


        }
      
   
   
    GameObject[] reshuffle_go(GameObject[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++)
        {
            GameObject tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
        return texts;
    }

}

