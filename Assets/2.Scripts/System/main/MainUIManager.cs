using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _startPanel;
    [SerializeField]
    private GameObject _optionPanel;
    [SerializeField]
    private GameObject _gameoverPanel;
    [SerializeField]
    private Slider _stageProgressSlider;
    [SerializeField]
    private Text _killCountText;
    [SerializeField]
    private Text _survivedTimeText;

    [SerializeField]
    private MainGameManager _mainGameManager;

    public void OnClickStart()
    {
        _mainGameManager.GameStart();

        _startPanel.SetActive(false);
    }

    public void ShowGameoverUI()
    {
        _gameoverPanel.SetActive(true);
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnClickOption()
    {
        _optionPanel.SetActive(true);

        MainEventManager.Instance.PauseGamePlayEvent?.Invoke();
    }

    public void OnClickOptionResume()
    {
        _optionPanel.SetActive(false);

        MainEventManager.Instance.ResumeGamePlayEvent?.Invoke();
    }

    public void OnClickOptionRestart()
    {
        _optionPanel.SetActive(false);

        OnClickRestart();
    }
}
