using EventBusEventData;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectablesManager : MonoBehaviour
{
    [SerializeField] List<Transform> collectables = new();

    [SerializeField] int totalCollected;

    [SerializeField] TextMeshProUGUI collectablesCounter;

    void OnEnable()
    {
        EventBus.Subscribe<CollectCollectableEvent>(OnCollect);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<CollectCollectableEvent>(OnCollect);
    }

    private void Start()
    {
        UpdateCounter();
    }

    void OnCollect(CollectCollectableEvent e)
    {
        totalCollected++;

        UpdateCounter();

        CheckIfCollectedAll();
    }

    void UpdateCounter()
    {
        collectablesCounter.text = $"{totalCollected} / {collectables.Count}";
    }

    void CheckIfCollectedAll()
    {
        if (totalCollected < collectables.Count) return;

        EventBus.Publish(new LevelCompletedEvent());
    }
}
