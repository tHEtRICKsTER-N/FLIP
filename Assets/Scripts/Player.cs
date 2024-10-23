using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _speed;
    public AudioSource coinASource;
    public AudioSource jumpASource;


    [SerializeField] private float _maxTimeToBeOnALane;

    float _currentTime = 0;
    bool directionToGo=true;
    UIM obj;

    private void Start()
    {
        _currentTime = _maxTimeToBeOnALane;
        obj = UIM.obj;
    }

    void Update()
    {
        Movement();

        if(_speed <= 15f)
            _speed += Time.deltaTime * 0.25f;

        if (_currentTime > 1)
        {
            _currentTime -= Time.deltaTime;
            obj.timerText.text = "" + (int)_currentTime;
        }
        else
            GameManager.obj.gameOver = true;

    }

    void Movement()
    {       
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            _currentTime = _maxTimeToBeOnALane;

            if (transform.localPosition.x < -4f)
            {
                directionToGo = true;
                jumpASource.Play();
            }
            else if (transform.localPosition.x > -0.62f)
            {
                directionToGo = false;
                jumpASource.Play();
            }
        }
        switch (directionToGo)
        {
            case true:
                transform.localPosition = new Vector3(
                    Mathf.Lerp(transform.localPosition.x, -0.53f, 0.1f),
                    transform.localPosition.y,
                    transform.localPosition.z);
                break;

            case false:
                transform.localPosition = new Vector3(
                    Mathf.Lerp(transform.localPosition.x, -4.49f, 0.1f),
                    transform.localPosition.y,
                    transform.localPosition.z);
                break;
        }
    }
}
