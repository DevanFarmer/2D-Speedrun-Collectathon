using EventBusEventData;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectablesManager : MonoBehaviour
{
    [SerializeField] List<Transform> collectables = new();

    [SerializeField] int totalCollected;

    [SerializeField] TextMeshProUGUI collectedCounter;
    [SerializeField] TextMeshProUGUI totalCounter;

    void OnEnable()
    {
        EventBus.Subscribe<CollectCollectableEvent>(OnCollect);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<CollectCollectableEvent>(OnCollect);
    }

    void OnCollect(CollectCollectableEvent e)
    {
        totalCollected++;

        UpdateCounters();

        CheckIfCollectedAll();
    }

    void UpdateCounters()
    {
        collectedCounter.text = totalCollected.ToString();
        totalCounter.text = collectables.Count.ToString();
    }

    void CheckIfCollectedAll()
    {
        if (totalCollected < collectables.Count) return;

        EventBus.Publish(new LevelCompletedEvent());
    }
}
