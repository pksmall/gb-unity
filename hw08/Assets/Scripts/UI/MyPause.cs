using TMPro;
using UnityEngine;


public class MyPause : MonoBehaviour
{
    #region Fields
    const string PAUSE_STRING = "Pause";
    public static bool GameIsPaused = false;
    public TextMeshProUGUI headerText;
    [SerializeField] private GameObject _visualGameOver;
    #endregion

    #region UnityMethods
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();

            } else
            {
                Pause();
            }
        }

    }
    #endregion

    #region Methods
    private void Resume()
    {
        _visualGameOver.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    private void Pause()
    {
        headerText.text = PAUSE_STRING;
        _visualGameOver.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
    #endregion

}
