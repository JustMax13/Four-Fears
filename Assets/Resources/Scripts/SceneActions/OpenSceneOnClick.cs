using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSceneOnClick : MonoBehaviour
{
    [SerializeField] private SceneСhanges _sceneСhanges;
    [SerializeField] private string _openSceneName;
    [Header("Залиште пустим, якщо не потрібен:")]
    [SerializeField] private string _loadScreenName;


    // нужно сделать так, чтобы при нажатии на кнопку мог вызываться метод, который открывает сцену с загрузочным экраном или без
    public void OpenScene()
    {
        if (_loadScreenName == "" || _loadScreenName == null)
            _sceneСhanges.LoadScene(_openSceneName);
        else
            _sceneСhanges.LoadScene(_openSceneName, _loadScreenName);
    }
}
