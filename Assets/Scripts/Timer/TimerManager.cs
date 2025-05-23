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
        EventBus.Subscribe<PauseChangeEvent>(OnPauseChange);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<PauseChangeEvent>(OnPauseChange);
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

    void OnPauseChange(PauseChangeEvent e)
    {
        paused = e.IsPaused;
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

    public void AlterTime(float alterValue)
    {
        timeLeft += alterValue;
    }
}
