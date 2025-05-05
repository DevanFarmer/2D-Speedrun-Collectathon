using EventBusEventData;
using UnityEngine;

public class PlayerCollisionComponent : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            // Explode player

            EventBus.Publish(new LevelFailedEvent());
        }
    }
}
