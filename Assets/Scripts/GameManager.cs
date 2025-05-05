using EventBusEventData;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    private void Start()
    {
        EventBus.Publish(new PauseChangeEvent(false));
    }

    void SetPauseState(bool state)
    {
        EventBus.Publish(new PauseChangeEvent(state));
    }

    void OnLevelCompleted(LevelCompletedEvent e)
    {
        SetPauseState(true);
    }

    void OnLevelFailed(LevelFailedEvent e)
    {
        SetPauseState(true);
    }
}
