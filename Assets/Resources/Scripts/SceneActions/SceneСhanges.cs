using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneСhanges : MonoBehaviour
{
    public static Action LoadScreenSetActive;
    public static Action BootSceneLoaded;

    // суть в том, что скорее всего 1н скрипт нам и не понадобиться ( другой )
    // Загрузочный экран - это просто интерфейс на текущей сцене, не запаривайся с кнопкой продолжить.
    // много концентрируешся на мелочах, так основу и не сделаешь.

    // Нужен класс, в котором будут все экраны.
    // в этих методах нужно чтобы передавали имя загружаемой сцены и загруз экран

    /// <summary>
    /// Метод асинхронно, за допомогую корутин, завантажує сцени.
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="loadScreenName">Не вказуючи параметр, сцена буде завантажена асинхронно без екрану завантаження</param>
    public void LoadScene(string sceneName, string loadScreenName = "")
    {
        if (loadScreenName == "" || loadScreenName == null)
            SceneManager.LoadSceneAsync(sceneName);
        else
        {
            var loadScreen = Instantiate(Resources.Load<GameObject>("Prefabs/LoadScreens/" + loadScreenName));
            var loadScreenCanvas = loadScreen.GetComponent<Canvas>();

            loadScreenCanvas.renderMode = RenderMode.ScreenSpaceCamera;
            loadScreenCanvas.worldCamera = Camera.main;
            loadScreen.SetActive(true);
            LoadScreenSetActive?.Invoke();

            StartCoroutine(LoadSceneAsync(sceneName, loadScreen));
        }

        return;
    }
    private IEnumerator LoadSceneAsync(string sceneName, GameObject loadScreen)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            // Пока сцена не загрузится полностью, делаем что-то (например, обновляем полосу загрузки)
            yield return null;
        }

        BootSceneLoaded?.Invoke();
    }
}
