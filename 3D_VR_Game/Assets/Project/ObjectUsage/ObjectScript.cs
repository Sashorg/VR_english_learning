

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public static string tagit;
    private Transform _tr;

    private int count = 0;
    public static ArrayList obj2 = new ArrayList { };
    int index;
    public static int len = 4;

    // Start is called before the first frame update
    void Awake()
    {

        //just to turn chair as they are 90 degrees not correct. we(designer) should fix this problem and we can delete it
        _tr = GetComponent<Transform>();
    }
    private void OnEnable()
    {
        RandomObject_phonetcs.changeRoadEvent += call;
    }

    private void OnDisable()
    {
        RandomObject_phonetcs.changeRoadEvent -= call ;

    }
    void Start()
    {
        int i;
        i = Random.Range(0,2);
        print(i);
        print(gameObject.transform.GetChild(1).name);
        print(gameObject.transform.GetChild(0).name);
        if (i == 0) {
            Vector3 v2 = gameObject.transform.GetChild(1).transform.position;
            gameObject.transform.GetChild(1).transform.position = gameObject.transform.GetChild(0).transform.position;
            Vector3 v1 = gameObject.transform.GetChild(0).transform.position;
            gameObject.transform.GetChild(0).transform.position = v2;


        }
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
  public  void call() {

        int i;
        i = Random.Range(0, 2);
        print(i);
        print(gameObject.transform.GetChild(1).name);
        print(gameObject.transform.GetChild(0).name);
        if (i == 0)
        {
            Vector3 v2 = gameObject.transform.GetChild(1).transform.position;
            gameObject.transform.GetChild(1).transform.position = gameObject.transform.GetChild(0).transform.position;
            Vector3 v1 = gameObject.transform.GetChild(0).transform.position;
            gameObject.transform.GetChild(0).transform.position = v2;


        }

    }

}
