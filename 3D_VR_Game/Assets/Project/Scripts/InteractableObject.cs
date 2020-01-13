using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{
    // Gaze Timer logic
    private bool _gvrStatus = false;
    private float _gvrTimer = 0;
    private float _totalTime = 2.0f;
    private Image imgGaze; //We get this image by the Tag "Gaze Image"

    // Accept/Reject feedback logic
    private bool _gazeComplete = false;
    private Image _accept; //We get this GameObject by the Tag "Accept"
    private Image _reject; //We get this GameObject by the Tag "Reject"
    private string _gazedObjectName, _targetObjectName;


    // User Statistics
    private float start_time;
    private float end_time;
    private int num_of_mistakes = 0;
    private int error_per_word = 0;
    private ArrayList list_of_mistakes = new ArrayList { };
    private ArrayList time_of_one_guess = new ArrayList { };
    private IEnumerator coroutine;

    //Delegates
    public delegate void GoodChoice();
    public static event GoodChoice goodChoice;
    public delegate void BadChoice();
    public static event BadChoice badChoice;

    //Learning Mode Objects
    [SerializeField]
    private GameObject _object, _score, _find;
    [SerializeField]
    private Text _objectText;


    private Animation anim;



    void Start()
    {
        if (gameObject.name == "door" && SettingsManager.room != "Apartment")
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            this.enabled = false;
        }
        anim = GetComponent<Animation>();
        // Gaze Timer logic
        imgGaze = GameObject.FindGameObjectWithTag("Gaze Image").GetComponent<Image>();
        imgGaze.fillAmount = 0;

        // Accept/Reject feedback logic
        _accept = GameObject.FindGameObjectWithTag("Accept").GetComponent<Image>();
        _reject = GameObject.FindGameObjectWithTag("Reject").GetComponent<Image>();
        _reject.enabled = false;
        _accept.enabled = false;

        //Learning Mode
        _objectText = GameObject.Find("UI_Object").GetComponent<Text>();

    }


    void Update()
    {
        if(imgGaze == null || _accept == null || _reject == null)
        {
            imgGaze = GameObject.FindGameObjectWithTag("Gaze Image").GetComponent<Image>();
            imgGaze.fillAmount = 0;
            _accept = GameObject.FindGameObjectWithTag("Accept").GetComponent<Image>();
            _reject = GameObject.FindGameObjectWithTag("Reject").GetComponent<Image>();
            _reject.enabled = false;
            _accept.enabled = false;
        }

        // Gaze Timer logic
        if (_gvrStatus)
        {
            _gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = _gvrTimer / _totalTime;
        }

        // Accept/Reject feedback logic
        if (_gvrTimer > _totalTime && _gazeComplete != true)
        {
            if (gameObject.name == "door")
            {

                anim.Play("open");
                coroutine = WaitAndPrint(0.5f);
                StartCoroutine(coroutine);
               
            }
            else
            {
                gazeCompleted();
                _gazeComplete = true;
            }
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
        _gazedObjectName = gameObject.transform.parent.root.name;
        if (SettingsManager.phonOrVoc == "Phonetics")
        {
            _targetObjectName = Phonetics_Object_handler.objectToShow;
            if (_gazedObjectName == _targetObjectName)
            {
                StartCoroutine(rightChoice());
            }
            else
            {
                StartCoroutine(wrongChoice());
            }
        }
        else if (SettingsManager.trainOrLearn == "Training")
        {
            _targetObjectName = ObjectHandler.objectToShow;
            if (_gazedObjectName == _targetObjectName)
            //if (_gazedObjectName == _targetObjectName)
            {
                // Accept/Reject feedback logic
                _accept.enabled = true;

                // Tell ObjectHandler that the right word has been found
                ObjectHandler.SetText();
            }
            else
            {
                AudioManager.Instance.ObjectSound(gameObject.transform.parent.root.name);
                // User statistics
                print("target is: " + _targetObjectName);
                print("Pointer is: " + _gazedObjectName);
                StatisticsManager.countMistake();
                StatisticsManager.countWordMistake(gameObject.transform.parent.root.name);
                // Accept/Reject feedback logic
                _reject.enabled = true;
            }
        }
        else if (SettingsManager.trainOrLearn == "Learning")
        {
            _objectText.text = gameObject.transform.parent.root.name;
            AudioManager.Instance.ObjectSound(gameObject.transform.parent.root.name);
        }
    }

    IEnumerator wrongChoice()
    {
        _reject.enabled = true;
        yield return new WaitForSeconds(0.5f);
        _reject.enabled = false;
        badChoice();
    }
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            GameObject[] go = changescen.GetDontDestroyOnLoadObjects();
            foreach (GameObject g in go)
            {
                print(g.name);
                for (int i = 0; i < g.transform.childCount; i++)
                {
                    g.transform.GetChild(i).gameObject.SetActive(false);
                }
                //g.SetActive(false);
            }
            SceneManager.LoadScene(gameObject.tag.ToString());
        }
    }
    IEnumerator rightChoice()
    {
        _accept.enabled = true;
        yield return new WaitForSeconds(0.5f);
        _accept.enabled = false;
        goodChoice();
    }
    
    
}
