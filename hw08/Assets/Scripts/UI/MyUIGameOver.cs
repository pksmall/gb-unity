using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MyUIGameOver : MonoBehaviour
{
    #region Fields
    public Button loadAgainButton;
    public float fakeLoadTime = 0f;
    public Button exitButton;
    public Button settingButton;
    public Button pauseButton;
    public Button cancelButton;
    public GameObject visualUICanvas;
    public GameObject visualUISetting;
    const string GAME_OVER_STRING = "Game Over!";
    public TextMeshProUGUI headerText;
    #endregion

    #region UnityMethods
    private void Awake()
    {
        visualUICanvas.SetActive(false);
        visualUISetting.SetActive(false);
        loadAgainButton.onClick.AddListener(OnLoadAgainButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
        settingButton.onClick.AddListener(OnClickSettings);
        pauseButton.onClick.AddListener(OnClickPause);
        cancelButton.onClick.AddListener(OnClickCancel);
    }
    #endregion

    #region Methods
    public void PlayerLoseMenuView()
    {
        headerText.text = GAME_OVER_STRING;
        visualUICanvas.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnClickSettings()
    {
        visualUISetting.SetActive(true);
    }
    
    private void OnClickPause()
    {
        Time.timeScale = 0;
        visualUICanvas.SetActive(true);
    }
    private void OnClickCancel()
    {
        Time.timeScale = 1;
        visualUICanvas.SetActive(false);
    }

    private void OnLoadAgainButtonClick()
    {
        Time.timeScale = 1;
        string name = SceneManager.GetActiveScene().name;
        LoadScene(name);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadGameSceneCor(sceneName));
    }

    private IEnumerator LoadGameSceneCor(string sceneName)
    {
        AsyncOperation asyncLoaing = SceneManager.LoadSceneAsync(sceneName);
        asyncLoaing.allowSceneActivation = false;

        float timer = 0f;

        while (timer < fakeLoadTime || asyncLoaing.progress < 0.9f)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        asyncLoaing.allowSceneActivation = true;
        while (asyncLoaing.progress < 0.99999f)
        {
            yield return null;
        }
    }

    public void LoadScene(int sceneNumber)
    {
        StartCoroutine(LoadGameSceneCor(sceneNumber));
    }

    private IEnumerator LoadGameSceneCor(int sceneNumber)
    {
        AsyncOperation asyncLoaing = SceneManager.LoadSceneAsync(sceneNumber);
        asyncLoaing.allowSceneActivation = false;

        float timer = 0f;

        while (timer < fakeLoadTime || asyncLoaing.progress < 0.9f)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        asyncLoaing.allowSceneActivation = true;
        while (asyncLoaing.progress < 0.99999f)
        {
            yield return null;
        }
    }
    #endregion
}
