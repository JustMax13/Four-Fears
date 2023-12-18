using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StepCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _stepsTMP;
    [Range(1, 99)][SerializeField] private int _maxStepCount;
    [SerializeField] private StepTime _stepTime;

    private int _currentStep;

    private void Start()
    {
        _currentStep = 1;
        _stepsTMP.text = _currentStep + "/" + _maxStepCount;

        _stepTime.StepEnd += NextStep;
    }

    public void NextStep()
    {
        _currentStep++;

        _stepsTMP.text = _currentStep + "/" + _maxStepCount; 
    }
}
