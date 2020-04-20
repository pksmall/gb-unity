using UnityEngine;
using UnityEngine.UI;


public class MyStartMenu : MonoBehaviour
{
    #region Fields
    public string level1 = "Level#1";
    public string level2 = "Level#2";
    public Button playButton;
    public Button settingsButton;
    public Button exitButton;
    public Button level1Button;
    public Button level2Button;
    public Button returnToMenu;
    public MyLoadLogic loadLogic;
    public GameObject visualChoosePart;
    public GameObject settingRoot;
    #endregion

    #region UnityMethods
    private void Awake()
    {
        settingRoot.SetActive(false);

        playButton.onClick.AddListener(PlayGame);
        settingsButton.onClick.AddListener(Settings);
        exitButton.onClick.AddListener(ExitGame);

        // choose level
        level1Button.onClick.AddListener(Level1Game);
        level2Button.onClick.AddListener(Level2Game);
        returnToMenu.onClick.AddListener(ReturnToMenu);
    }
    #endregion

    #region Methods
    private void Level1Game()
    {
        loadLogic.LoadScene(level1);
    }

    private void Level2Game()
    {
        loadLogic.LoadScene(level2);
    }

    private void ReturnToMenu()
    {
        visualChoosePart.SetActive(false);
    }
    private void PlayGame()
    {
        visualChoosePart.SetActive(true);
    }

    private void Settings()
    {
        settingRoot.SetActive(true);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
    #endregion
}
