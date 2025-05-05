using EventBusEventData;
using TMPro;
using UnityEngine;

public class ResultScreenManager : MonoBehaviour
{
    [SerializeField] GameObject resultScreenPanel;
    [SerializeField] TextMeshProUGUI resultScreenTitle;

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

    void Start()
    {
        ShowLevelOverPanel(false);
    }

    void OnLevelCompleted(LevelCompletedEvent e)
    {
        ShowLevelOverPanel(true);

        // Set Completed UI
        SetLevelResultUI("Level Complete!");
    }

    void OnLevelFailed(LevelFailedEvent e)
    {
        ShowLevelOverPanel(true);

        // Set Failed UI
        SetLevelResultUI("Level Failed!");
    }

    void ShowLevelOverPanel(bool state)
    {
        resultScreenPanel.SetActive(state);
    }

    void SetLevelResultUI(string title)
    {
        resultScreenTitle.text = title;
    }
}
