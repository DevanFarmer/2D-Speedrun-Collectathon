using EventBusEventData;
using System.Collections.Generic;
using UnityEngine;

public class CollectableComponent : MonoBehaviour
{
    [SerializeField] List<CollectableEffect> collectablEffects = new();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        EventBus.Publish(new CollectCollectableEvent());

        foreach (CollectableEffect effect in collectablEffects)
        {
            effect.OnCollected();
        }

        Destroy(gameObject);
    }
}
