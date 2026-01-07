using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class GameUIManager : MonoBehaviour
{
    private SignalBus _signalBus;

    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private Button _restartButton;


    [Inject]
    public void Construct(SignalBus signalBus) => _signalBus = signalBus;

    private void Start()
    {
        _restartButton.onClick.AddListener(() => RestartGame());
        HideGameOverUI();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
        _signalBus.Fire(new GameSignal.OnLevelRestart());
    }
    public void ToggleGameOverUI() => _gameOverUI.SetActive(true);
    public void HideGameOverUI() => _gameOverUI.SetActive(false);
}
