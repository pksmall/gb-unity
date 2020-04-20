using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MyLoadLogic : MonoBehaviour
{
    #region Field
    public Slider progresBarSlider;
    public GameObject visualPart;
    public float fakeLoadTime = 1f;
    #endregion

    #region UnityMethods
    private void Awake()
    {
        gameObject.transform.SetParent(null, false);
        DontDestroyOnLoad(this.gameObject);
        visualPart.SetActive(false);
    }
    #endregion

    #region Methods
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadGameSceneCor(sceneName));
    }

    private IEnumerator LoadGameSceneCor(string sceneName)
    {
        visualPart.SetActive(true);
        AsyncOperation asyncLoaing = SceneManager.LoadSceneAsync(sceneName);
        asyncLoaing.allowSceneActivation = false;

        float timer = 0f;

        while (timer < fakeLoadTime || asyncLoaing.progress < 0.89f)
        {
            timer += Time.deltaTime;
            SetProgressBarProgress(timer / fakeLoadTime);          
            yield return null;
        }
        
        asyncLoaing.allowSceneActivation = true;
        while (asyncLoaing.progress < 0.99f)
        {
            yield return null;
        }
        visualPart.SetActive(false);
        Destroy(gameObject);
    }

    public void LoadScene(int sceneNumber)
    {
        StartCoroutine(LoadGameSceneCor(sceneNumber));
    }
    private IEnumerator LoadGameSceneCor(int sceneNumber)
    {
        visualPart.SetActive(true);
        AsyncOperation asyncLoaing = SceneManager.LoadSceneAsync(sceneNumber);
        asyncLoaing.allowSceneActivation = false;

        float timer = 0f;

        while (timer < fakeLoadTime || asyncLoaing.progress < 0.92555f)
        {
            timer += Time.deltaTime;
            SetProgressBarProgress(timer / fakeLoadTime);

            yield return null;
        }

        asyncLoaing.allowSceneActivation = true;
        while (asyncLoaing.progress < 0.92555f)
        {
            yield return null;
        }
        visualPart.SetActive(false);
    }

    private void SetProgressBarProgress(float progress)
    {
        progresBarSlider.value = progress;
    }
    #endregion
}
