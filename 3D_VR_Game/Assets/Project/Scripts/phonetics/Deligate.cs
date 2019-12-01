using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deligate : MonoBehaviour
{
    public delegate void GoodChoice();
    public static event GoodChoice goodChoice;
    public delegate void BadChoice();
    public static event BadChoice badChoice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (goodChoice != null)
                goodChoice();

        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (badChoice != null)
                badChoice();
        }

    }
}
