using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tmp;
    [SerializeField] private string[] _textState;
    [SerializeField] private float _changeStateTime;

    private int _currentStateIndex;
    private float _timeToChangeState;

    private void Start()
    {
        _currentStateIndex = 0;
        _timeToChangeState = _changeStateTime;
    }
    private void Update()
    {
        if (_timeToChangeState <= 0)
        {
            _tmp.text = _textState[_currentStateIndex++];

            if (_currentStateIndex == _textState.Length)
                _currentStateIndex = 0;

            _timeToChangeState = _changeStateTime;
        }
        else
            _timeToChangeState -= Time.deltaTime;
    }
}
