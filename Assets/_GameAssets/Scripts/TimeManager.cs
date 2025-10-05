using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _gameTime;
    [SerializeField] private float _clockTimer = 1f;

    private int _hour = 23;
    private int _minute = 0;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > _clockTimer)
        {
            timer = 0f;
            AddTime();
        }
        if (_gameTime != null)
        {
            _gameTime.text = String.Format("{0:00}:{1:00}", _hour, _minute);
        }
    }
    void AddTime()
    {
        _minute++;
        if (_minute >= 60)
        {
            _minute = 0;
            _hour++;
            if (_hour >= 24)
            {
                _hour = 0;
            }
        }
        if (_hour == 7)
        {
            GameManager.Instance.GameOver();
        }
    }

}
