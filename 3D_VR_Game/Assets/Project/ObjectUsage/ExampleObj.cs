using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleObj : MonoBehaviour
{
  public  static string tryout = "chair";
    string tagitem;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Example());
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Example()
    {
        //we need to wait for few seconds to initialize tags of objects and then we just call fucntion which we will replace with VR one. when item was guessed succesfully we deactivate this object
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
   
        tagitem = ObjectScript.tagit;
        print("love" + tagitem);
        ObjectScript.deleteObject(tryout);
    }
}
