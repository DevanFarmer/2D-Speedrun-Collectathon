using EventBusEventData;
using UnityEngine;

public class CollectableComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        EventBus.Publish(new CollectCollectableEvent());

        Destroy(gameObject);
    }
}
