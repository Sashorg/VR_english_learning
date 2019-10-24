using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPick : MonoBehaviour
{
    public static string score;
    private int index = 3;//# of spawners in the scene
    public static int rnd_number;
    // Array list is for initiating all objects, the arraylst should be equal to the number of objects attached to spawner
   public static ArrayList obj = new ArrayList{ "chair", "table", "glass" };

    // Start is called before the first frame update
    void Awake() {
       
    }
    void Start()
    {
        rnd_number = Random.Range(0, index);
        print("num is " + rnd_number);
        print("yeah we here bitch");
       

        score = ExampleObj.tryout;
        
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //this function is responsiblle for extracting items from list to have no duplicates in the scene
    public static void deleteObj(string s) {
        
        obj.Remove(s);
        //print(obj);
        print("Your list is " + obj.Count);
        
    }

}
