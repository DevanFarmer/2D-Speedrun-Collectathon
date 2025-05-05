using EventBusEventData;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

    [SerializeField] float timeLeft;

    [SerializeField] bool paused;

    private void OnEnable()
    {
        EventBus.Subscribe<LevelCompletedEvent>(OnLevelCompleted);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<LevelCompletedEvent>(OnLevelCompleted);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (paused) return;

        UpdateTimer();

        if (timeLeft <= 0)
        {
            LevelFailed();
        }
    }

    void OnLevelCompleted(LevelCompletedEvent e)
    {
        paused = true;
    }

    void LevelFailed()
    {
        paused = true;

        EventBus.Publish(new LevelFailedEvent());
    }

    void UpdateTimer()
    {
        timeLeft -= Time.deltaTime;

        timerText.text = $"{(int)Mathf.Ceil(timeLeft)}";
    }
}
