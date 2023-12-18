using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tmpTime;
    //[SerializeField] private TextMeshProUGUI _halfADay;
    private float _currentTime;

    private void Start()
    {
        _currentTime = 0;
    }
    private void Update()
    {
        _currentTime += Time.deltaTime;

        _tmpTime.text = TimeInTMP(_currentTime);
    }

    private string TimeInTMP(float currentTime)
    {
        int minute = (int)(currentTime / 60);
        int second = (int)(currentTime % 60);
        string minuteInString = "";
        string secondInString = "";

        minuteInString = minute.ToString();
        //if (minute <= 9)
        //    minuteInString = "0" + minute;
        //else
        //    minuteInString = minute.ToString();
        if (second <= 9)
            secondInString = "0" + second;
        else
            secondInString = second.ToString();

        string result = minuteInString + ":" + secondInString;
        return result;
    }
}
