using System;
using TMPro;
using UnityEngine;

public class StepTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeLeft;
    [Range(1,99)][SerializeField] private float _timeOnStep;

    private float _currentLeftTime;
    public Action StepEnd;

    private void Start()
    {
        _currentLeftTime = _timeOnStep;
        _timeLeft.text = _timeOnStep.ToString();
    }
    private void Update()
    {
        _currentLeftTime -= Time.deltaTime;

        if (_currentLeftTime <= 0)
        {
            StepEnd?.Invoke();
            _currentLeftTime = _timeOnStep;
        }

        _timeLeft.text = ((int)_currentLeftTime + 1).ToString();
    }
}
