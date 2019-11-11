using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Renderer rd;
    public float totalTime = 2.0f;
    private bool _gvrStatus;
    private float _gvrTimer;
    private bool _gazeComplete;
    public string targetTag;
    public bool match;
    float start_time;
    float end_time;
    private int num_of_mistakes=0;
    int error_per_word = 0;
    private ArrayList list_of_mistakes= new ArrayList { };
    private ArrayList time_of_one_guess = new ArrayList { };

    // Start is called before the first frame update
    void Start()
    {
        start_time = Time.time;
        _gazeComplete = false;
        _gvrStatus = false;
        _gvrTimer = 0;
        rd = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gvrStatus)
        {
            _gvrTimer += Time.deltaTime;
        }
        if (_gvrTimer > totalTime && _gazeComplete != true)
        {
            gazeCompleted();
            _gazeComplete = true;
        }
    }

    public void gvrOn()
    {
        _gvrStatus = true;
    }

    public void gvrOff()
    {
        _gvrStatus = false;
        _gvrTimer = 0;
        rd.material.color = Color.white;
        _gazeComplete = false;
    }

    public void gazeCompleted()
    {
        AudioManager.Instance.ObjectSound(targetTag);
        print("Your object is"+ObjectHandler.objectToShow);
        rd.material.color = Color.grey;
        match = this.gameObject.CompareTag(ObjectHandler.objectToShow);
        
        if (match)
        {
            end_time = Time.time - start_time;
            start_time = Time.time;
            time_of_one_guess.Add(end_time);
            ObjectScript.deleteObject(ObjectHandler.objectToShow);
            ObjectHandler.SetText();
            error_per_word = 0;
            print("errors=" + error_per_word);
            Debug.Log("Match!");
            //Do something if match object
        }
        else
        {
            error_per_word++;
            Debug.Log("errors="+error_per_word.ToString());
            end_time = Time.time - start_time;
            start_time = Time.time;
            time_of_one_guess.Add(end_time);
            num_of_mistakes++;
            list_of_mistakes.Add(ObjectHandler.objectToShow);
            Debug.Log("Not a match!");
            //Do something else if doesn't match object
        }
    }

}
