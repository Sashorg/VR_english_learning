using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    // Gaze Timer logic
    private bool _gvrStatus = false;
    private float _gvrTimer = 0;
    private float _totalTime = 1.5f;
    private Image imgGaze; //We get this image by the Tag "Gaze Image"
    private bool _gazeComplete = false;

    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        // Gaze Timer logic
        imgGaze = GameObject.FindGameObjectWithTag("Gaze Image").GetComponent<Image>();
        imgGaze.fillAmount = 0;

        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
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
    }

    public void gazeCompleted()
    {
        _player.transform.position = new Vector3(gameObject.transform.position.x, _player.transform.position.y, gameObject.transform.position.z);
    }
}
