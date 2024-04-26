using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Stopwatch : MonoBehaviour
{
    private bool _timerActive = false;
    private float _currentTime;
    [SerializeField] private TMP_Text _text;

    public void Start()
    {
        _currentTime = 0;      
    }

    public void Update()
    {
        if (_timerActive)
        {
            _currentTime = _currentTime + Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        _text.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();
    }

    public void StartStopwatch()
    {
        _timerActive = true;
    }
    public void StopStopwatch()
    {
        _timerActive = false;
    }
    public void ResetStopwatch()
    {
        _timerActive = false;
        _currentTime = 0;
    }
}
