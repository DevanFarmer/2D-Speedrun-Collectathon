using EventBusEventData;
using System.Collections.Generic;
using UnityEngine;

public class CollectableComponent : MonoBehaviour
{
    [SerializeField] List<CollectableEffect> collectableEffects = new();
    [SerializeField] bool callEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        if (callEvent) EventBus.Publish(new CollectCollectableEvent());

        foreach (CollectableEffect effect in collectableEffects)
        {
            effect.OnCollected();
        }

        Destroy(gameObject);
    }
}
