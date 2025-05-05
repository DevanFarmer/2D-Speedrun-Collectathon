using EventBusEventData;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
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

    public void RestartLevel()
    {
        // Slight lag, will do it better but is fine for now
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
