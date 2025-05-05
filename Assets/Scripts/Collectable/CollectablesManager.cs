using EventBusEventData;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectablesManager : MonoBehaviour
{
    [SerializeField] Transform collectablesParent;
    int totalCollectables;

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
        SetTotalCollectables();
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
        collectablesCounter.text = $"{totalCollected} / {totalCollectables}";
    }

    void CheckIfCollectedAll()
    {
        if (totalCollected < totalCollectables) return;

        EventBus.Publish(new LevelCompletedEvent());
    }

    void SetTotalCollectables()
    {
        totalCollectables = collectablesParent.childCount;
    }
}
