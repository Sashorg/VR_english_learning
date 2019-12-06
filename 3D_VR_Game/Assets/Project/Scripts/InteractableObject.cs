using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    // Gaze Timer logic
    private bool _gvrStatus = false;
    private float _gvrTimer = 0;
    private float _totalTime = 2.0f;
    [SerializeField]
    private Image imgGaze; //We get this image by the Tag "Gaze Image"

    // Accept/Reject feedback logic
    private bool _gazeComplete = false;
    [SerializeField]
    private Image _accept; //We get this GameObject by the Tag "Accept"
    [SerializeField]
    private Image _reject; //We get this GameObject by the Tag "Reject"
    private string _gazedObjectName, _targetObjectName;

    // User Statistics
    private float start_time;
    private float end_time;
    private int num_of_mistakes = 0;
    private int error_per_word = 0;
    private ArrayList list_of_mistakes = new ArrayList { };
    private ArrayList time_of_one_guess = new ArrayList { };

    

    void Start()
    {
        // Gaze Timer logic
        imgGaze = GameObject.FindGameObjectWithTag("Gaze Image").GetComponent<Image>();
        imgGaze.fillAmount = 0;

        // Accept/Reject feedback logic
        _accept = GameObject.FindGameObjectWithTag("Accept").GetComponent<Image>();
        _reject = GameObject.FindGameObjectWithTag("Reject").GetComponent<Image>();
        _reject.enabled = false;
        _accept.enabled = false;

        // User Statistics 
        start_time = Time.time;
    }

    void Update()
    {
        // Gaze Timer logic
        if (_gvrStatus)
        {
            _gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = _gvrTimer / _totalTime;
        }

        // Accept/Reject feedback logic
        if (_gvrTimer > _totalTime && _gazeComplete != true)
        {
            gazeCompleted();
            _gazeComplete = true;
        }

    }

    public void gvrOn()
    {
        // Gaze Timer logic
        _gvrStatus = true;
    }

    public void gvrOff()
    {
        // Gaze Timer logic
        _gvrStatus = false;
        _gvrTimer = 0;
        imgGaze.fillAmount = 0f;

        // Accept/Reject feedback logic
        _gazeComplete = false;
        _accept.enabled = false;
        _reject.enabled = false;
    }

    public void gazeCompleted()
    {
        AudioManager.Instance.ObjectSound(gameObject.name);
        _gazedObjectName = gameObject.name;
        _targetObjectName = ObjectHandler.objectToShow;
        if(_gazedObjectName == _targetObjectName+"(Clone)")
        //if (_gazedObjectName == _targetObjectName)
        {
            // User statistics
            end_time = Time.time - start_time;
            start_time = Time.time;
            time_of_one_guess.Add(end_time);
            error_per_word = 0;

            // Accept/Reject feedback logic
            _accept.enabled = true;

            // Tell ObjectHandler that the right word has been found
            ObjectHandler.SetText();
        }
        else
        {
            // User statistics
            error_per_word++;
            print("target is: " + _targetObjectName);
            print("Pointer is: " + _gazedObjectName);
            Debug.Log("errors=" + error_per_word.ToString());
            end_time = Time.time - start_time;
            start_time = Time.time;
            time_of_one_guess.Add(end_time);
            num_of_mistakes++;
            list_of_mistakes.Add(ObjectHandler.objectToShow);

            // Accept/Reject feedback logic
            _reject.enabled = true;
        }
    }
}
