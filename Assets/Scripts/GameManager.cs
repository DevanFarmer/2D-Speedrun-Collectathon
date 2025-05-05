using EventBusEventData;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject levelOverPanel;
    [SerializeField] TextMeshProUGUI levelOverTitle;

    private void OnEnable()
    {
        EventBus.Subscribe<LevelCompletedEvent>(OnLevelCompleted);
        EventBus.Subscribe<LevelFailedEvent>(OnLevelFailed);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<LevelCompletedEvent>(OnLevelCompleted);
        EventBus.Unsubscribe<LevelFailedEvent>(OnLevelFailed);
    }

    void SetPauseState(bool state)
    {
        EventBus.Publish(new PauseChangeEvent(state));
    }

    void OnLevelCompleted(LevelCompletedEvent e)
    {
        LevelOver();

        // Set Completed UI
        SetLevelOverUI("Level Complete!");
    }

    void OnLevelFailed(LevelFailedEvent e)
    {
        LevelOver();

        // Set Failed UI
        SetLevelOverUI("Level Failed!");
    }

    void LevelOver()
    {
        // Pause Game
        SetPauseState(true);

        // Show Level Over UI
        ShowLevelOverPanel(true);
    }

    void ShowLevelOverPanel(bool state)
    {
        levelOverPanel.SetActive(state);
    }

    void SetLevelOverUI(string title)
    {
        levelOverTitle.text = title;
    }
}
