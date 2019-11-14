using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public float totalTime = 2.0f;
    private bool _gvrStatus;
    private float _gvrTimer;
    private bool _gazeComplete;
    public bool match;
    private GameObject _reticle;
    private Renderer _rd;
    float start_time;
    float end_time;
    private int num_of_mistakes = 0;
    int error_per_word = 0;
    private ArrayList list_of_mistakes = new ArrayList { };
    private ArrayList time_of_one_guess = new ArrayList { };
    public GameObject accept;
    public GameObject reject;


    // Start is called before the first frame update
    void Start()
    {
        start_time = Time.time;
        _gazeComplete = false;
        _gvrStatus = false;
        _gvrTimer = 0;
        _reticle = GameObject.FindGameObjectWithTag("Reticle");
        _rd = _reticle.GetComponent<Renderer>();
        accept.SetActive(false);
        reject.SetActive(false);
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
        _gazeComplete = false;
        accept.SetActive(false);
        reject.SetActive(false);
        //_rd.material.color = Color.black;
    }

    public void gazeCompleted()
    {
        print("gamneobjectgaze is " + gameObject.transform.GetChild(0).name);
        print("gamneobject is " + ObjectHandler.objectToShow + "(Clone)");
        Debug.Log("Gaze!");
        AudioManager.Instance.ObjectSound(this.gameObject.tag);
      
        if (gameObject.transform.GetChild(0).name == ObjectHandler.objectToShow+"(Clone)")
        {

            end_time = Time.time - start_time;
            start_time = Time.time;
            time_of_one_guess.Add(end_time);

            ObjectScript.deleteObject(ObjectHandler.objectToShow.ToString());
            //MaterialControl.Instance.NewMaterial(ObjectHandler.objectToShow);

            //_rd.material.color = Color.green;
            Debug.Log("Match!");
            error_per_word = 0;
            Debug.Log("errors=" + error_per_word.ToString());
            ObjectHandler.SetText();
            accept.SetActive(true);
           
           //Call function to warn that the right word has been chosen
        }
        else
        {
            error_per_word++;
            Debug.Log("errors=" + error_per_word.ToString());
            end_time = Time.time - start_time;
            start_time = Time.time;
            time_of_one_guess.Add(end_time);
            num_of_mistakes++;
            list_of_mistakes.Add(ObjectHandler.objectToShow);
            //_rd.material.color = Color.red;
            Debug.Log("Not a Match!");
            //Make recticle pointer red
            reject.SetActive(true);
        }
    }
}
